import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent {

  @Input() fullName: string;
  @Input() loading$: Observable<boolean>;
  @Output() openSettingsEvent = new EventEmitter<string>();
  @Output() toggleSidenavEvent = new EventEmitter<void>();
  @Output() logoutEvent = new EventEmitter<void>();
  
}
