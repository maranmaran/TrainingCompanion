import { Component, ContentChild, ElementRef, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { defer, fromEvent, Observable, Subject, timer } from 'rxjs';
import { concat, map, merge, repeat, startWith, switchMap, take, takeUntil, takeWhile, tap } from 'rxjs/operators';
import { SubSink } from 'subsink';
import { RefreshConfig } from './pull-to-refresh.config';

@Component({
  selector: 'app-pull-to-refresh',
  templateUrl: './pull-to-refresh.component.html',
  styleUrls: ['./pull-to-refresh.component.scss']
})
export class PullToRefreshComponent implements OnInit, OnDestroy {

  @ContentChild('spinner') spinner: ElementRef;
  @Input() config = new RefreshConfig();
  @Output('onRefresh') onRefreshEvent = new EventEmitter();

  subs = new SubSink();

  constructor() {
  }

  ngOnInit() {
    this.subs.add(
      this.drag$.subscribe()
    );
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  };

  position = 0;

  touchStart$ = fromEvent<TouchEvent>(window, 'touchstart');
  touchMove$ = fromEvent<TouchEvent>(window, 'touchmove');
  touchEnd$ = fromEvent<TouchEvent>(window, 'touchend');

  drag$ = this.touchStart$.pipe(
    switchMap(start => {
      let curPos = 0;
      return this.touchMove$.pipe(
        map(move => move.touches[0].pageY - start.touches[0].pageY),
        tap(pos => curPos = pos as number),
        takeUntil(this.touchEnd$),
        concat(defer(() => this.tweenObservable(curPos, 0, 200)))
      )
    }),
    tap(pos => {
      if(pos >= window.innerHeight / this.config.indicatorRelativeHeight)
        this.onRefresh();
    }),
    takeWhile(pos => pos < window.innerHeight / this.config.indicatorRelativeHeight),
    repeat()
  );

  loadComplete$ = new Subject();

  completeAnimation$ = this.loadComplete$
  .pipe(
    map(() => this.position),
    switchMap(currentPos => this.tweenObservable(currentPos, 0 , 200))
  )

  position$: Observable<number> = this.drag$
    .pipe(
      merge(this.completeAnimation$),
      startWith(0),
      tap(pos => this.position = pos)
    )

  positionTranslate3d$ = this.position$.pipe(map(p => `translate3d(0, ${p - 70}px, 0)`))

  private tweenObservable(start, end, time) {
    const emissions = time / 10
    const step = (start - end) / emissions

    return timer(0, 10).pipe(
      map(x => start - step * (x + 1)),
      take(emissions)
    )
  }

  onRefresh() {
    if(!this.config.windowReload) {
      this.onRefreshEvent.emit();
    } else {
      this.reloadWindow();
    }
  }

  reloadWindow() {
    setTimeout(() => {
      this.loadComplete$.next();
      setTimeout(_ => window.location.reload(), 200);
    }, 500);
  }
}
