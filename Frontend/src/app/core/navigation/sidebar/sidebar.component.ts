import { UISidenavAction } from './../../../../business/models/ui-sidenavs.enum';
import { UIService } from 'src/business/services/shared/ui.service';
import { Component, OnInit } from '@angular/core';
import { UISidenav } from 'src/business/models/ui-sidenavs.enum';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  constructor(
    private uiService: UIService
  ) { }

  ngOnInit() {
  }

  //TODO: Event source this out
  public close() {
    this.uiService.doSidenavAction(UISidenav.App, UISidenavAction.Close);
  }
}
