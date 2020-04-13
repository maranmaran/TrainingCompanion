import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { take } from 'rxjs/operators';
import { language } from 'src/ngrx/user-interface/ui.selectors';
import { UIState } from './../../../../ngrx/user-interface/ui.state';

@Component({
  selector: 'app-athletes-home',
  templateUrl: './athletes-home.component.html',
  styleUrls: ['./athletes-home.component.scss']
})
export class AthletesHomeComponent implements OnInit {

  constructor(
    private translateService: TranslateService,
    private store: Store<UIState>
  ) {
    this.store.select(language).pipe(take(1)).subscribe(lang => this.translateService.use("hr"));
  }

  ngOnInit() {
  }
}
