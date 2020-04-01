import { Component, OnInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { Router } from '@angular/router';
import { from, Observable, of } from 'rxjs';
import { BottomNavigation } from 'src/ngrx/navigation/navigation.state';

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
  styleUrls: ['./tabs.component.scss']
})
export class TabsComponent implements OnInit {

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
      route: '/app/chat',
      icon: 'fas fa-comments',
      label: 'Chat',
    }),
  ]

  // chatLinks: NavigationLink[] = [
  //   new NavigationLink({
  //     returnToMain: true,
  //     icon: 'fas fa-arrow-circle-left',
  //     label: 'Back',
  //   }),
  //   new NavigationLink({
  //     route: '/app/chat/messages',
  //     icon: 'fas fa-comments',
  //     label: 'Messages',
  //   }),
  //   new NavigationLink({
  //     route: '/app/chat/friends',
  //     label: 'Friends',
  //     icon: 'fas fa-user-friends',
  //   }),
  // ]

  navigation = BottomNavigation;
  activeNavigation: BottomNavigation;

  previousRoute: string;

  mainIndex: number;
  chatIndex: number;

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.activeNavigation = BottomNavigation.Main;
    this.mainIndex = 0;
    this.chatIndex = 2;
  }

  onMainChange(event: MatTabChangeEvent) {
    let link = this.mainLinks[event.index];

    if(link.activateTabGroup != BottomNavigation.Main) {
      this.activeNavigation = link.activateTabGroup;
    } else {
      this.mainIndex = event.index;
    }

    this.previousRoute = this.router.url;
    this.route(link);
  }

  // onChatChange(event: MatTabChangeEvent) {
  //   let link = this.chatLinks[event.index];

  //   if(link.returnToMain) {
  //     this.activeNavigation = BottomNavigation.Main;
  //     link.route = this.previousRoute;
  //     this.chatIndex = 2;
  //     console.log(this.mainIndex);
  //   } else {
  //     this.chatIndex = event.index;
  //   }

  //   this.route(link);
  // }

  route(link: NavigationLink): Observable<boolean> {
    if(!link.canNavigate) return of(false);

    return from(this.router.navigate([link.route]));
  }

}
