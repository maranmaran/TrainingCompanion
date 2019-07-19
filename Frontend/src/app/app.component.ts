import { Theme } from './../business/shared/theme.enum';
import { UIProgressBar } from './../business/shared/ui-progress-bars.enum';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme, getLoadingState } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';
import { UIService } from './../business/services/shared/ui.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  public loading$: Observable<boolean>;

  constructor(
    private store: Store<AppState>,
    private uiService: UIService,
  ) {
  }

  ngOnInit(): void {
    
    window.dispatchEvent(new Event('resize')); // set mobile/web screen state
    this.loading$ = getLoadingState(this.store, UIProgressBar.SplashScreen); // loading of splash screen

    // subscribe for eventual theme changing of app
    this.subs.add(this.store.select(activeTheme)
      .subscribe(
        (theme: Theme) => {
          this.uiService.setupTheme(theme);
        },
        err => console.log(err))
    );
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

 
}
