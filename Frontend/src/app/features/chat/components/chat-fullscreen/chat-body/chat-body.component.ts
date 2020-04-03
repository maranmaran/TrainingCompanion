import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Component, ElementRef, NgZone, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { combineLatest, Subject } from 'rxjs';
import { distinctUntilKeyChanged, map, take } from 'rxjs/operators';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { Theme } from 'src/business/shared/theme.enum';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';
import { ChatTheme } from '../../../models/enums/chat-theme.enum';
import { selectedFriendWindow } from './../../../../../../ngrx/chat/chat.selectors';
import { IChatParticipant } from './../../../models/chat-participant.model';

@Component({
  selector: 'app-chat-body',
  templateUrl: './chat-body.component.html',
  styleUrls: ['./chat-body.component.scss']
})
// export class ChatBodyComponent implements OnInit, OnChanges, OnDestroy {
export class ChatBodyComponent  {

  friend: IChatParticipant;

  @ViewChildren('chatWindow') messageSection: QueryList<ElementRef>;
  @ViewChildren('messageInput') messageInput: QueryList<ElementRef>;
  // @ViewChild('fileInput') fileInputs: QueryList<ElementRef>;
  @ViewChild('autosize') autosizeTextarea: CdkTextareaAutosize;

  subs = new SubSink();

  form: FormGroup
  textAreaLines: number = 1;

  scrollEvent = new Subject<any>();

  constructor(
    private _ngZone: NgZone,
    private store: Store<AppState>,
    public chat: ChatService
  ) { }

  ngOnInit(): void {
    this.createForm();

    this.subs.add(
      // this.messageText.valueChanges.subscribe(val => this.onMessageChange(val)),

      // this.onScroll().subscribe(messages => {

      //   if (!messages || messages.length == 0)
      //     return this.noMoreData.next(false);

      //   this.messageSection.nativeElement.scrollTop = 5;

      //   this.chatService.pagingModel.page += 1;
      //   this.chat.messages = [...messages, ...this.chat.messages]
      // }),

      combineLatest(
        this.store.select(selectedFriendWindow).pipe(distinctUntilKeyChanged('id')),
        this.store.select(currentUserId).pipe(take(1)),
        this.store.select(activeTheme).pipe(map(theme => theme == Theme.Light ? ChatTheme.Light : ChatTheme.Dark))
      ).subscribe(([window, userId, theme]) => {

        setTimeout(_ => {
          if(!this.chat.paramsInitialized)
            this.chat.setParams(userId, null, this.messageInput, this.messageSection);

          this.chat.setConfiguration(theme)
          this.chat.bootstrapChatFullscreen(window);
        })
      })
    );
  }

  // ngOnChanges(changes: SimpleChanges) {
  //   this.isBootstrapped = false;

  //   // 600 ms is default transition for tabs
  //   //https://material.angular.io/components/tabs/api#MatTabsConfig
  //   let tabsAnimationDelay = 600;
  //   if (changes.friend.currentValue && changes.friend.currentValue.id != changes.friend.previousValue?.id)
  //     setTimeout(_ => this.chatService.bootstrapChat(changes.friend.currentValue), this.mediaObserver.isActive('lt-md') ? tabsAnimationDelay : 0);
  // }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  createForm() {
    this.form = new FormGroup({
      messageText: new FormControl(''),
    });
  }

  get messageText(): AbstractControl { return this.form.get('messageText'); }


  // onMessageChange(message) {
  //   this.textCache = { id: this.friend.id, message };

  //   const lines = message.split('\n').length + 1;
  //   if (lines >= 1 && lines <= 6 && this.textAreaLines != lines) {
  //     this.textAreaLines = lines;
  //     this.scrollChatWindow(ScrollDirection.Bottom);
  //   }
  // }

  triggerResize() {
    // Wait for changes to be applied, then trigger textarea resize.
    this._ngZone.onStable.pipe(take(1))
      .subscribe(() => (this.autosizeTextarea.resizeToFitContent(true)));
  }

  // private scrollYPosition = 0;
  // private upScroll: boolean;
  // onScroll() {
  //   return this.scrollEvent
  //     .pipe(
  //       map(event => event?.target?.scrollTop),
  //       tap(scrollTop => this.upScroll = scrollTop - this.scrollYPosition < 0),
  //       map(scrollTop => this.scrollYPosition = scrollTop),
  //       filter(scrollTop => scrollTop <= 50 && this.upScroll),
  //       takeUntil(this.noMoreData),
  //       exhaustMap(_ => this.chatService.getMessageHistory(this.friend.id).pipe(delay(500))),
  //     );
  // }


}
