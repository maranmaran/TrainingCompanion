import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { map, take } from 'rxjs/operators';
import { UIProgressBar } from 'src/business/models/ui-progress-bars.enum';
import { SidebarService } from 'src/business/services/shared/sidebar.service';
import { logout } from 'src/ngrx/auth/auth.actions';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AuthState } from 'src/ngrx/auth/auth.state';
import { activeProgressBar, requestLoading } from 'src/ngrx/user-interface/ui.selectors';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { SettingsComponent } from '../../settings/settings.component';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent {

  @Input() fullName: string;
  @Input() loading$: Observable<boolean>;
  @Output() openSettingsEvent = new EventEmitter<string>();
  @Output() toggleSidenavEvent = new EventEmitter;
  @Output() logoutEvent = new EventEmitter;
  
}
