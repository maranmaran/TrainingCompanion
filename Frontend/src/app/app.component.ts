import { Component, OnDestroy, OnInit } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setMobileScreenFlag } from 'src/ngrx/user-interface/ui.actions';
import { activeTheme, getLoadingState } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';
import { UIService } from '../business/services/shared/ui.service';
import { Theme } from './../business/shared/theme.enum';
import { UIProgressBar } from './../business/shared/ui-progress-bars.enum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  public loading$: Observable<boolean>;

  constructor(
    private store: Store<AppState>,
    private uiService: UIService,
    private mediaObserver: MediaObserver
  ) {
  }

  ngOnInit(): void {

    window.dispatchEvent(new Event('resize')); // set mobile/web screen state
    this.loading$ = getLoadingState(this.store, UIProgressBar.SplashScreen); // loading of splash screen

    // subscribe for eventual theme changing of app
    this.subs.add(
      this.store.select(activeTheme)
      .subscribe(
        (theme: Theme) => {
          this.uiService.setupTheme(theme);
        },
        err => console.log(err)),
        this.mediaObserver.media$.subscribe(
          (change: MediaChange) => {
            if ( change.mqAlias == 'xs') {
              this.store.dispatch(setMobileScreenFlag({ isMobile: true }));
            } else {
              this.store.dispatch(setMobileScreenFlag({ isMobile: false }));
           }
          },
          err => console.log(err)
        )
    );
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

}
