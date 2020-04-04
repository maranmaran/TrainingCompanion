import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { MatTabChangeEvent, MatTabGroup } from '@angular/material/tabs';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { from, Observable, of, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { setFullscreenChatActive } from 'src/ngrx/chat/chat.actions';
import { selectedFriend } from 'src/ngrx/chat/chat.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { BottomNavigation } from 'src/ngrx/navigation/navigation.state';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { SubSink } from 'subsink';

export class NavigationLink {
  canNavigate = true;
  active = false;
  returnToMain = false;

  activateTabGroup = BottomNavigation.Main;

  route: string;
  label: string;
  icon: string;

  constructor(data: Partial<NavigationLink>) {
    Object.assign(this, data);
  }
}

@Component({
  selector: 'app-tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.scss'],
})
export class TabsComponent implements OnInit, OnDestroy {

  mainLinks: NavigationLink[] = [
    new NavigationLink({
      route: '/app/dashboard',
      icon: 'fas fa-home',
      label: 'Dashboard',
    }),
    new NavigationLink({
      route: '/app/training-log',
      label: 'Training',
      icon: 'fas fa-calendar-alt',
    }),
    new NavigationLink({
      route: '/app/bodyweight',
      icon: 'fas fa-weight',
      label: 'Bodyweight',
    }),
    new NavigationLink({
      activateTabGroup: BottomNavigation.Chat,
      route: '/app/chat/friends',
      icon: 'fas fa-comments',
      label: 'Chat',
    }),
  ]

  chatLinks: NavigationLink[] = [
    new NavigationLink({
      returnToMain: true,
      icon: 'fas fa-arrow-circle-left',
      label: 'Back',
    }),
    new NavigationLink({
      route: '/app/chat/messages',
      icon: 'fas fa-comments',
      label: 'Messages',
    }),
    new NavigationLink({
      route: '/app/chat/friends',
      label: 'Friends',
      icon: 'fas fa-user-friends',
    }),
  ]

  navigation = BottomNavigation;
  activeNavigation: BottomNavigation;

  previousRoute: string;

  subs = new SubSink();

  @ViewChild('main') mainTabs: MatTabGroup;
  mainIndex: number;

  @ViewChild('chat') chatTabs: MatTabGroup;
  chatIndex: number;
  chatSubscriptions: Subscription[];

  constructor(
    private router: Router,
    private mediaObserver: MediaObserver,
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    this.activeNavigation = BottomNavigation.Main;
    this.mainIndex = 0;
    this.chatIndex = 2;

    this.mainLinks.forEach(mLink => {
      // contains
      if (this.router.url.includes(mLink.route)) {
        this.mainIndex = this.mainLinks.indexOf(mLink);
      }
    });
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  onMainChange(event: MatTabChangeEvent) {
    let link = this.mainLinks[event.index];

    switch (link.activateTabGroup) {
      case BottomNavigation.Chat:
        this.activeNavigation = link.activateTabGroup;
        this.chatSubscriptions = this.getChatObservables().map(obs => obs.subscribe());
        break;
      case BottomNavigation.Main:
        this.mainIndex = event.index;
        break;
    }

    this.previousRoute = this.router.url;
    this.route(link);
  }

  onChatChange(event: MatTabChangeEvent) {
    let link = this.chatLinks[event.index];

    if (link.returnToMain) {
      this.activeNavigation = BottomNavigation.Main;
      link.route = this.previousRoute;
      this.chatIndex = 2;
      this.chatSubscriptions.forEach(sub => sub.unsubscribe());
      this.store.dispatch(setFullscreenChatActive({active: false}));
      this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.MainAppScreen }));
    } else {
      this.chatIndex = event.index;
    }

    // remove classic progress bar and inform app that full screen CHAT is active..
    this.store.dispatch(setFullscreenChatActive({active: true}));
    this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.None }));

    this.route(link);
  }

  getChatObservables(): Observable<any>[] {
    let observables: Observable<any>[] = [];

    // listen to friend list selection and handle tab change
    observables.push(
      this.store.select(selectedFriend).pipe(tap(_ => {

        // new friend
        if (!this.mediaObserver.isActive('lt-md')) return; // do nothing if tabs are not active

        setTimeout(_ => {
          this.chatTabs.selectedIndex = 1;
          this.chatTabs.realignInkBar()
        });
      }))
    )

    return observables;
  }

  route(link: NavigationLink): Observable<boolean> {
    if (!link.canNavigate) return of(false);

    return from(this.router.navigate([link.route]));
  }

}
