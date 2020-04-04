import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Component, ElementRef, NgZone, OnDestroy, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { combineLatest, Subject } from 'rxjs';
import { delay, distinctUntilChanged, distinctUntilKeyChanged, exhaustMap, filter, map, take, takeUntil, tap } from 'rxjs/operators';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { Theme } from 'src/business/shared/theme.enum';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';
import { ChatTheme } from '../../../models/enums/chat-theme.enum';
import { ScrollDirection } from '../../../models/enums/scroll-direction.enum';
import { selectedFriendWindow } from './../../../../../../ngrx/chat/chat.selectors';
import { IChatParticipant } from './../../../models/chat-participant.model';

@Component({
  selector: 'app-chat-body',
  templateUrl: './chat-body.component.html',
  styleUrls: ['./chat-body.component.scss']
})
// export class ChatBodyComponent implements OnInit, OnChanges, OnDestroy {
export class ChatBodyComponent implements OnInit, OnDestroy {

  friend: IChatParticipant;

  @ViewChildren('chatWindow') messageSection: QueryList<ElementRef>;
  @ViewChildren('messageInput') messageInput: QueryList<ElementRef>;
  // @ViewChild('fileInput') fileInputs: QueryList<ElementRef>;
  @ViewChild('autosize') autosizeTextarea: CdkTextareaAutosize;

  subs = new SubSink();

  form: FormGroup
  textAreaLines: number = 1;

  scrollEvent = new Subject<any>();
  noMoreData = new Subject<boolean>();

  constructor(
    private _ngZone: NgZone,
    private store: Store<AppState>,
    public chat: ChatService,
    private mediaObserver: MediaObserver
  ) { }

  ngOnInit(): void {

    this.subs.add(

      this.onScroll().subscribe(messages => {

        if (!messages || messages.length == 0)
          return this.noMoreData.next(false);

        this.messageSection.toArray()[0].nativeElement.scrollTop = 5;

        this.chat.windows[0].pagingModel.page += 1;
        this.chat.windows[0].messages = [...messages, ...this.chat.windows[0].messages]
      }),

      combineLatest(
        this.store.select(selectedFriendWindow).pipe(distinctUntilKeyChanged('id'), tap(_ => (this.chat.isBootstrapped = false, this.chat.paramsInitialized = false))),
        this.store.select(currentUserId).pipe(take(1)),
        this.store.select(activeTheme).pipe(distinctUntilChanged(), map(theme => theme == Theme.Light ? ChatTheme.Light : ChatTheme.Dark))
      ).subscribe(([window, userId, theme]) => {

        this.chat.setConfiguration(theme)

        setTimeout(_ => {
          if(!this.chat.paramsInitialized)
            this.chat.setParams(userId, null, this.messageInput, this.messageSection);
          if(!this.chat.isBootstrapped)
            this.chat.bootstrapChatFullscreen(window);

          this.createForm();
        })
      })
    );
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  get cachedMessage() : string {
    if(!this.chat.textCache) return '';

    let friendId = this.chat.friends[0].id;
    if(this.chat.textCache.id != friendId) return '';

    return this.chat.textCache.message;
  }

  createForm() {
    this.form = new FormGroup({
      messageText: new FormControl(this.cachedMessage),
    });

    this.subs.add(this.messageText.valueChanges.subscribe(val => this.onMessageChange(val)))
  }

  get messageText(): AbstractControl { return this.form.get('messageText'); }

  onMessageChange(message) {
    this.chat.textCache = { id: this.chat.friends[0].id, message };

    const lines = message.split('\n').length + 1;
    if (lines >= 1 && lines <= 6 && this.textAreaLines != lines) {
      this.textAreaLines = lines;
      this.chat.scrollChatWindow(this.chat.windows[0], ScrollDirection.Bottom);
    }
  }

  triggerResize() {
    // Wait for changes to be applied, then trigger textarea resize.
    this._ngZone.onStable.pipe(take(1))
      .subscribe(() => (this.autosizeTextarea.resizeToFitContent(true)));
  }

  private scrollYPosition = 0;
  private upScroll: boolean;
  onScroll() {
    return this.scrollEvent
      .pipe(
        map(event => event?.target?.scrollTop),
        tap(scrollTop => this.upScroll = scrollTop - this.scrollYPosition < 0),
        map(scrollTop => this.scrollYPosition = scrollTop),
        filter(scrollTop => scrollTop <= 50 && this.upScroll),
        takeUntil(this.noMoreData),
        exhaustMap(_ => this.chat.getMessageHistory(this.chat.windows[0], false).pipe(delay(500))),
      );
  }

  onSendMessage(event: any) {
    // enter triggers new line in mobile view
    if(this.mediaObserver.isActive('lt-md') && event instanceof KeyboardEvent) return;

    this.chat.windows[0].newMessage = this.messageText.value;
    this.chat.onSendMessage(event, this.chat.windows[0]);
    this.messageText.setValue('');
  }

}
