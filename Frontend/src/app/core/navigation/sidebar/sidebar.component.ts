import { SidebarService } from 'src/business/services/shared/sidebar.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  constructor(
    private sidebarService: SidebarService
  ) { }

  ngOnInit() {
  }

  public close() {
    this.sidebarService.toggleApp();
  }
}
