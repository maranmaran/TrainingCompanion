import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-sidebar-mobile',
    templateUrl: './sidebar-mobile.component.html',
    styleUrls: ['./sidebar.component.scss']
})
export class SidebarMobileComponent implements OnInit {

    @Input() isCoach$: Observable<boolean>;

    @Output() close = new EventEmitter();
    @Output() route = new EventEmitter<string>();

    constructor(
    ) { }

    ngOnInit(): void {
    }
}
