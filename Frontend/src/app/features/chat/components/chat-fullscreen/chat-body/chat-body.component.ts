import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Component, ElementRef, Input, NgZone, OnChanges, OnDestroy, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { allMessagesSeen, messageFromAnotherFriend, pushMessage } from 'src/ngrx/chat/chat.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { currentUserId } from './../../../../../../ngrx/auth/auth.selectors';
import { ChatConfiguration } from './../../../chat.configuration';
import { IChatParticipant } from './../../../models/chat-participant.model';
import { ScrollDirection } from './../../../models/enums/scroll-direction.enum';
import { Message } from './../../../models/message.model';
import { ChatSignalrService } from './../../../services/chat-signalr.service';

@Component({
  selector: 'app-chat-body',
  templateUrl: './chat-body.component.html',
  styleUrls: ['./chat-body.component.scss']
})
export class ChatBodyComponent implements OnInit, OnChanges, OnDestroy {

  @Input() config: ChatConfiguration;
  @Input() friend: IChatParticipant;

  @ViewChild('chatWindow') window: ElementRef;
  @ViewChild('autosize') autosizeTextarea: CdkTextareaAutosize;

  isBootstrapped = false;

  subs = new SubSink();
  messages: Message[];

  userId: string;
  form: FormGroup
  textCache: { id: string, message: string }
  textAreaLines: number = 1;

  private audioFile: HTMLAudioElement;

  constructor(
    private _ngZone: NgZone,
    private signalrService: ChatSignalrService,
    private store: Store<AppState>,
    private chatService: ChatService,
    private mediaObserver: MediaObserver,
  ) { }

  ngOnInit(): void {
    this.store.select(currentUserId).subscribe(id => this.userId = id);

    this.signalrService.onMessageReceivedHandlerFullscreenChat = (friend, message) => this.onMessageReceived(friend, message);
    this.createForm();

    this.subs.add(
      this.messageText.valueChanges.subscribe(val => this.onMessageChange(val))
    );

    // this.init(this.friend);
  }

  ngOnChanges(changes: SimpleChanges) {
    this.isBootstrapped = false;

    // 600 ms is default transition for tabs
    //https://material.angular.io/components/tabs/api#MatTabsConfig
    let tabsAnimationDelay = 600;
    if(changes.friend.currentValue && changes.friend.currentValue.id != changes.friend.previousValue?.id)
      setTimeout(_ => this.init(changes.friend.currentValue), this.mediaObserver.isActive('lt-md') ? tabsAnimationDelay : 0);
  }

  ngOnDestroy() {
    console.log('destroyed')
    this.subs.unsubscribe();
  }

  createForm() {
    this.form = new FormGroup({
      messageText: new FormControl(''),
    });
  }

  get messageText(): AbstractControl { return this.form.get('messageText'); }

  init(friend) {
    this.friend = friend;
    this.audioFile = this.chatService.bufferAudioFile(this.config);

    if (this.textCache?.id == this.friend.id)
      this.messageText.setValue(this.textCache.message);

    this.getMessageHistory(this.friend.id);
  }

  getMessageHistory(friendId: string) {
    this.signalrService.getMessageHistory(friendId).pipe(take(1))
      .subscribe(messages => {
        messages.forEach((message) => this.chatService.assertMessageType(message));
        this.messagesFetched(messages, ScrollDirection.Bottom);
      });
  }

  messagesFetched(messages: Message[], direction: ScrollDirection): void {
    this.messages = messages;

    this.markMessagesSeen(messages);
    this.store.dispatch(allMessagesSeen({ friendId: this.friend.id }));

    this.isBootstrapped = true;
    setTimeout(_ => this.scrollChatWindow(direction));
    // this.scrollChatWindow(direction);
  }

  onMessageReceived(friend: IChatParticipant, message: Message) {
    if (!message) return;
    if (this.friend?.id != message.fromId) {
      this.store.dispatch(messageFromAnotherFriend({ friend }))
      return;
    };

    this.chatService.assertMessageType(message);

    this.store.dispatch(pushMessage({ message }));
    // this.messages.push(message);

    this.scrollChatWindow(ScrollDirection.Bottom);

    this.audioFile.play();
  }

  markMessagesSeen(messages: Message[]) {
    const unseenMessages = messages.filter(m => !m.dateSeen);
    this.chatService.markMessagesAsRead(unseenMessages);
  }

  scrollChatWindow(direction: ScrollDirection): void {
    if (this.window) {
      let element = this.window.nativeElement;
      let position = (direction === ScrollDirection.Top) ? 0 : element.scrollHeight;
      element.scrollTop = position;
    }
  }

  onMessageChange(message) {
    this.textCache = { id: this.friend.id, message };

    const lines = message.split('\n').length + 1;
    if (lines >= 1 && lines <= 6 && this.textAreaLines != lines) {
      this.textAreaLines = lines;
      this.scrollChatWindow(ScrollDirection.Bottom);
    }
  }

  sendMessage(event) {

    // enter adds new line if mobile view
    if (this.mediaObserver.isActive('lt-sm') && event instanceof KeyboardEvent) {
      return;
    }

    event.preventDefault();

    let messageRaw = this.messageText.value;
    if (messageRaw == '') return;

    let message = new Message();
    message.fromId = this.userId;
    message.toId = this.friend.id;
    message.message = messageRaw;
    message.dateSent = new Date();

    this.store.dispatch(pushMessage({ message }));
    // this.messages.push(message);

    this.signalrService.sendMessage(message);

    this.messageText.setValue('') // Resets the new message input
    this.scrollChatWindow(ScrollDirection.Bottom);
  }

  triggerResize() {
    // Wait for changes to be applied, then trigger textarea resize.
    this._ngZone.onStable.pipe(take(1))
      .subscribe(() => (this.autosizeTextarea.resizeToFitContent(true)));
  }

  addFile(event) {

  }

}
