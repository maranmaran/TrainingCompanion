import { Component, OnInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.scss']
})
export class TabsComponent implements OnInit {

  links = [
    {
      canNavigate: true,
      route: '/app/dashboard',
      label: 'Dashboard',
      routeActive: false
    },
    {
      canNavigate: true,
      route: '/app/training-log',
      label: 'Training log',
      routeActive: false
    },
    {
      canNavigate: true,
      route: '/app/bodyweight',
      label: 'Bodyweight',
      routeActive: false
    },
  ]

  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  tabChange(event: MatTabChangeEvent) {
    let link = this.links[event.index];

    if(this.onRoute(link.route, link.canNavigate)) {
       link.routeActive = true;
    }
  }

  onRoute(route: string, canNavigate: boolean) {
    if(!canNavigate) return false;

    this.router.navigate([route]);
    return true;
  }

}
