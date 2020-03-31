import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { UIService } from 'src/business/services/shared/ui.service';
import { UISidenav } from 'src/business/shared/ui-sidenavs.enum';
import { isCoachOrSoloAthlete } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UISidenavAction } from '../../../../business/shared/ui-sidenavs.enum';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  isCoach$: Observable<boolean>;

  constructor(
    private uiService: UIService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.isCoach$ = this.store.select(isCoachOrSoloAthlete);
  }

  //TODO: Event source this out
  public close() {
    this.uiService.doSidenavAction(UISidenav.App, UISidenavAction.Close);
  }

  public onRoute() {
    this.uiService.doSidenavAction(UISidenav.App, UISidenavAction.Toggle);
  }
}
