import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { combineLatest, Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { getThemeClass, Theme } from 'src/business/models/theme.enum';
import { UIProgressBar } from 'src/business/models/ui-progress-bars.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setMobileScreenFlag, setWebScreenFlag } from 'src/ngrx/user-interface/ui.actions';
import { activeProgressBar, activeTheme, isMobile, requestLoading } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';

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
    private overlayContainer: OverlayContainer,
  ) {
  }

  ngOnInit(): void {
    // set mobile/web screen state
    window.dispatchEvent(new Event('resize'));

    // loading of splash screen
    this.loading$ = combineLatest(
      this.store.select(requestLoading),
      this.store.select(activeProgressBar)
    ).pipe(map(([isLoading, progressBar]) => isLoading && progressBar == UIProgressBar.SplashScreen));

    // setup theme for app---> theme service ?
    this.subs.add(

      this.store.select(activeTheme)
        .subscribe(
          (theme: Theme) => {
            this.setupTheme(theme);
          },
          err => console.log(err))
    );
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  @HostListener('window:resize', ['$event'])
  onResize() {

    if (window.innerWidth <= 599) {

      // only dispatch if the value different
      this.store
        .select(isMobile)
        .pipe(take(1))
        .subscribe((isMobile: boolean) => !isMobile && this.store.dispatch(setMobileScreenFlag({isMobile: true})))

      return;
    }

    // only dispatch if the value different
    this.store
        .select(isMobile)
        .pipe(take(1))
        .subscribe((isMobile: boolean) => isMobile && this.store.dispatch(setWebScreenFlag({isWeb: true})))
  }

  private setupTheme(theme: Theme) {

    const overlayContainer = this.overlayContainer.getContainerElement();
    const documentBody = document.getElementsByTagName("BODY")[0];

    const overlayContainerClasses = overlayContainer.classList;
    const bodyClasses = documentBody.classList;

    const overlayThemeClassesToRemove = Array.from(overlayContainerClasses).filter((item: string) => item.includes('theme-'));
    const bodyThemeClassesToRemove = Array.from(bodyClasses).filter((item: string) => item.includes('theme-'));

    overlayThemeClassesToRemove.length && overlayContainerClasses.remove(...overlayThemeClassesToRemove);
    bodyThemeClassesToRemove.length && bodyClasses.remove(...bodyThemeClassesToRemove);

    var themeClass = getThemeClass(theme);
    overlayContainerClasses.add(themeClass);
    bodyClasses.add(themeClass);
  }
}
