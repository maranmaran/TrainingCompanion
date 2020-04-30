import { Component, OnDestroy, OnInit } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setMobileScreenFlag } from 'src/ngrx/user-interface/ui.actions';
import { activeTheme, getLoadingState, language } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';
import { UIService } from '../business/services/shared/ui.service';
import { Theme } from './../business/shared/theme.enum';
import { UIProgressBar } from './../business/shared/ui-progress-bars.enum';

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
    private mediaObserver: MediaObserver,
    private translateService: TranslateService) {
    this.translationSetup();
  }

  ngOnInit(): void {

    this.loading$ = getLoadingState(this.store, UIProgressBar.SplashScreen); // loading of splash screen

    // handle viewport size for css
    // We listen to the resize event
    window.addEventListener('resize', this.handleViewportHeightOnMobileDevices);

    window.dispatchEvent(new Event('resize'));

    // subscribe for eventual theme changing of app
    this.subs.add(

      // theme
      this.store.select(activeTheme)
        .subscribe(
          (theme: Theme) => {
            this.uiService.setupTheme(theme);
          },
          err => console.log(err)),

      // mobile screen
      this.mediaObserver.media$.subscribe(
        (change: MediaChange) => {

          if (change.mqAlias == 'xs') {
            this.store.dispatch(setMobileScreenFlag({ isMobile: true }));
          } else {
            this.store.dispatch(setMobileScreenFlag({ isMobile: false }));
          }
        },
        err => console.log(err)
      )

    );
  }

  handleViewportHeightOnMobileDevices() {
    let vh = window.innerHeight * 0.01;
    document.documentElement.style.setProperty('--vh', `${vh}px`);
  }

  ngOnDestroy(): void {
    window.removeEventListener('resize', this.handleViewportHeightOnMobileDevices);
    this.subs.unsubscribe();
  }

  translationSetup() {
    console.log('Setting up translation...');
    this.translateService.setDefaultLang('en');
    this.subs.add(
      this.store.select(language).pipe(filter(lang => !!lang)).subscribe(lang => this.translateService.use(lang))
    )
    // this.translateService.addLangs(['en', 'hr']);
    // const browserLang = this.translateService.getBrowserLang();
    // this.translateService.use(browserLang.match(/en | hr/) ? browserLang : 'en');
  }

}
