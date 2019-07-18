import { distinctUntilChanged, map } from 'rxjs/operators';
import { ThemeService } from './../business/services/shared/theme.service';
import { Component, HostListener, OnDestroy, OnInit, HostBinding } from '@angular/core';
import { UIService } from 'src/business/services/shared/ui.service';
import { SidebarService } from 'src/business/services/shared/sidebar.service';
import { SubSink } from 'subsink';
import { OverlayContainer, Overlay } from '@angular/cdk/overlay';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Theme, getThemeClass } from 'src/business/models/theme.enum';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {


  private subs = new SubSink();
  public showSplash: boolean = true;


  constructor(
    private themeService: ThemeService,
    private overlayContainer: OverlayContainer,
    private UIService: UIService,
    private sidebarService: SidebarService,
    private store: Store<AppState>
  ) {
  }

  ngOnInit(): void {
    window.dispatchEvent(new Event('resize'));

    this.subs.add(

      this.UIService.loading$
        .pipe(
          map((res: boolean) =>  res && this.UIService.showSplash),
          distinctUntilChanged())
        .subscribe(
          (showSplash: boolean) => { 
            this.showSplash = showSplash;
          },
          err => console.log(err)
      ),

      this.store.select(activeTheme)
        .subscribe(
          (theme: Theme) => {
            console.log(theme);
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
    //mobile
    if (window.innerWidth <= 600) {
      this.sidebarService.isMobile.next(true);
      return;
    }

    this.sidebarService.isMobile.next(false);
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
