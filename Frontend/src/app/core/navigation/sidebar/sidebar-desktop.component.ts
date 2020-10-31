import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-sidebar-desktop',
    templateUrl: './sidebar-desktop.component.html',
    styleUrls: ['./sidebar.component.scss']
})
export class SidebarDesktopComponent {

    @Input() isCoach$: Observable<boolean>;

    @Output() close = new EventEmitter();
    @Output() route = new EventEmitter<string>();

    constructor(
        public router: Router
    ) { }
}
