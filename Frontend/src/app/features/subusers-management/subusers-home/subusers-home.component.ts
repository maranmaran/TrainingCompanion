import { ApplicationUser } from '../../../../server-models/entities/application-user.model';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { subusers } from 'src/ngrx/subusers/subuser.selectors';
import { UIService } from 'src/business/services/shared/ui.service';

@Component({
  selector: 'app-subusers-home',
  templateUrl: './subusers-home.component.html',
  styleUrls: ['./subusers-home.component.scss']
})
export class SubusersHomeComponent implements OnInit {

  protected subusers$: Observable<ApplicationUser[]>;
  protected selectedSubuser: ApplicationUser;

  constructor(
    private uiService: UIService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.subusers$ = this.store.select(subusers);
  }

  onSelect(subuser: ApplicationUser) {
    this.selectedSubuser = subuser;
  }

  onDelete(subuser: ApplicationUser) {

    const message = 
    `<p>Are you sure you wish to delete user ${subuser.firstName} ${subuser.lastName} ?</p>
     <p>All data will be lost if you delete this user.</p>`;

    this.uiService.openConfirmDialog(message,
       () => {
         // delete
       }, true, true, 'Delete', `Delete action`)

  }

  onDeleteSelection(subusers: ApplicationUser[]) {

    const message = 
    `<p>Are you sure you wish to delete all (${subusers.length}) selected users ?</p>
     <p>All data will be lost if you delete these users.</p>`;

    this.uiService.openConfirmDialog(message,
       () => {
         // delete all selected
       }, true, true, 'Delete', `Delete action`)

  }


}
