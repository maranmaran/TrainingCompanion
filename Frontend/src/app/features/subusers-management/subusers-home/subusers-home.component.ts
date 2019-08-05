import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
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

  
  deleteDialogConfig =  new ConfirmDialogConfig({ title: 'Delete action',  confirmLabel: 'Delete' });

  onDelete(subuser: ApplicationUser) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete user ${subuser.firstName} ${subuser.lastName} ?</p>
     <p>All data will be lost if you delete this user.</p>`;

    this.deleteDialogConfig.action = () => {
      // delete all selected
    }

    this.uiService.openConfirmDialog(this.deleteDialogConfig);
  }

  onDeleteSelection(subusers: ApplicationUser[]) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete all (${subusers.length}) selected users ?</p>
     <p>All data will be lost if you delete these users.</p>`;

    this.deleteDialogConfig.action = () => {
      // delete all selected
    }

    this.uiService.openConfirmDialog(this.deleteDialogConfig)
  }
}
