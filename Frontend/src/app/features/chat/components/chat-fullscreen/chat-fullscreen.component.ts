import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { MatTabGroup } from '@angular/material/tabs';
import { Store } from '@ngrx/store';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { setFullscreenChatActive } from 'src/ngrx/chat/chat.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { selectedFriend } from './../../../../../ngrx/chat/chat.selectors';
import { setActiveProgressBar } from './../../../../../ngrx/user-interface/ui.actions';

@Component({
  selector: 'app-chat-fullscreen',
  templateUrl: './chat-fullscreen.component.html',
  styleUrls: ['./chat-fullscreen.component.scss'],
  providers: [ChatService]
})
export class ChatFullscreenComponent implements OnInit, OnDestroy {

  @ViewChild('tabs') tabs: MatTabGroup;
  private subs = new SubSink();

  constructor(
    public mediaObserver: MediaObserver,
    private store: Store<AppState>,
  ) { }

  ngOnInit(): void {
    // remove classic progress bar and inform app that full screen CHAT is active..
    this.store.dispatch(setActiveProgressBar({progressBar: UIProgressBar.None}));
    setTimeout(() => this.store.dispatch(setFullscreenChatActive({ active: true })))

    // listen to friend list selection and handle tab change
    this.subs.add(
      this.store.select(selectedFriend)
      .subscribe(_ => {
        // new friend
        if(!this.mediaObserver.isActive('lt-md')) return; // do nothing if tabs are not active
        this.tabs.selectedIndex = 0;
        this.tabs.realignInkBar()
      })
    )
  }

  ngOnDestroy() {
    this.store.dispatch(setActiveProgressBar({progressBar: UIProgressBar.MainAppScreen}));
    this.store.dispatch(setFullscreenChatActive({ active: false }));
    this.subs.unsubscribe();
  }

}
