import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activateSubuser, deactivateSubuser } from 'src/ngrx/subusers/subuser.actions';
import { selectedSubuser } from 'src/ngrx/subusers/subuser.selectors';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

@Component({
  selector: 'app-subuser-details',
  templateUrl: './subuser-details.component.html',
  styleUrls: ['./subuser-details.component.scss']
})
export class SubuserDetailsComponent implements OnInit {

  protected subuser$: Observable<ApplicationUser>;
  
  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.subuser$ = this.store.select(selectedSubuser);
  }

  onSetActive(value: boolean) {
    value && this.store.dispatch(activateSubuser());
    !value && this.store.dispatch(deactivateSubuser());
  }

}
