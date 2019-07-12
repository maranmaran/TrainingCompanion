import { distinctUntilChanged, map } from 'rxjs/operators';
import { ThemeService } from './../business/services/shared/theme.service';
import { Component, HostListener, OnDestroy, OnInit, HostBinding } from '@angular/core';
import { NotificationService } from 'src/business/services/shared/notification.service';
import { SidebarService } from 'src/business/services/shared/sidebar.service';
import { SubSink } from 'subsink';
import { OverlayContainer, Overlay } from '@angular/cdk/overlay';

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
    private notificationService: NotificationService,
    private sidebarService: SidebarService
  ) {
  }

  ngOnInit(): void {
    window.dispatchEvent(new Event('resize'));

    this.subs.add(this.notificationService.loading$
      .pipe(
        map((res: boolean) =>  res && this.notificationService.showSplash),
        distinctUntilChanged())
      .subscribe(
        (showSplash: boolean) => { 
          this.showSplash = showSplash;
        },
        err => console.log(err)
      ));

    this.subs.add(this.themeService.theme$
      .subscribe(
        (theme: string) => this.setupTheme(theme),
        err => console.log(err)
      ));
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

  private setupTheme(theme: string) {

    const overlayContainer = this.overlayContainer.getContainerElement();
    const documentBody = document.getElementsByTagName("BODY")[0];

    const overlayContainerClasses = overlayContainer.classList;
    const bodyClasses = documentBody.classList;

    const overlayThemeClassesToRemove = Array.from(overlayContainerClasses).filter((item: string) => item.includes('theme-'));
    const bodyThemeClassesToRemove = Array.from(bodyClasses).filter((item: string) => item.includes('theme-'));

    overlayThemeClassesToRemove.length && overlayContainerClasses.remove(...overlayThemeClassesToRemove);
    bodyThemeClassesToRemove.length && bodyClasses.remove(...bodyThemeClassesToRemove);

    overlayContainerClasses.add(theme);
    bodyClasses.add(theme);
  }
}
