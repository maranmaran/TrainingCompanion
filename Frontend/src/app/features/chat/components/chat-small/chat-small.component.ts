import { Component, ElementRef, HostListener, OnInit, QueryList, ViewChildren, ViewEncapsulation } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Store } from '@ngrx/store';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { map, take } from 'rxjs/operators';
import { Theme } from 'src/business/shared/theme.enum';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { ChatService } from './../../../../../business/services/feature-services/chat.service';
import { activeTheme } from './../../../../../ngrx/user-interface/ui.selectors';
import { ChatTheme } from './../../models/enums/chat-theme.enum';

@Component({
  selector: 'app-chat-small',
  templateUrl: './chat-small.component.html',
  styleUrls: [
    'chat-small.component.scss',
    'assets/icons.scss',
    'assets/loading-spinner.scss',
    'assets/themes/chat-dark.theme.scss',
    'assets/themes/chat-light.theme.scss'
  ],
  encapsulation: ViewEncapsulation.None,
  providers: [ChatService]
})
export class ChatSmallComponent implements OnInit {

  constructor(
    public sanitizer: DomSanitizer,
    private store: Store<AppState>,
    public chat: ChatService,
  ) { }

  private subs = new SubSink();
  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    if(!this.chat.isBootstrapped) return;

    this.chat.viewPortTotalArea = event.target.innerWidth;

    setTimeout(_ => {
      this.chat.normalizeWindows();
    });
  }

  @ViewChildren('messageSection') messageSections: QueryList<ElementRef>;
  @ViewChildren('messageInput') messageInputs: QueryList<ElementRef>;
  @ViewChildren('fileInput') fileInputs: QueryList<ElementRef>;

  ngOnInit() {

    this.subs.add(

      combineLatest(
        this.store.select(currentUserId).pipe(take(1)),
        this.store.select(activeTheme).pipe(map(theme => theme == Theme.Light ? ChatTheme.Light : ChatTheme.Dark))
      ).subscribe(([userId, theme]) => {

        setTimeout(_ => {
          if(!this.chat.paramsInitialized)
            this.chat.setParams(userId, this.fileInputs, this.messageInputs, this.messageSections);

          this.chat.setConfiguration(theme)

          this.chat.bootstrapChatSmall(window);
        })
      })
    )

  }

  ngOnDestroy(): void {
    localStorage.removeItem(this.chat.localStorageKey);
    this.subs.unsubscribe();
  }

}
