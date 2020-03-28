import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Component, ElementRef, Input, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { noop } from 'rxjs';
import { take } from 'rxjs/operators';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { currentUserId } from './../../../../../../ngrx/auth/auth.selectors';
import { selectedFriend } from './../../../../../../ngrx/chat/chat.selectors';
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
export class ChatBodyComponent implements OnInit, OnDestroy {

  @Input() config: ChatConfiguration;
  @ViewChild('chatWindow') window: ElementRef;
  @ViewChild('autosize') autosizeTextarea: CdkTextareaAutosize;

  isBootstrapped = false;

  subs = new SubSink();
  friend: IChatParticipant;
  messages: Message[]

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
    private mediaObserver: MediaObserver
  ) { }

  ngOnInit(): void {
    this.store.select(currentUserId).subscribe(id => this.userId = id);

    this.createForm();

    this.subs.add(
      this.store.select(selectedFriend).subscribe(friend => friend ? this.init(friend) : noop()),

      this.messageText.valueChanges.subscribe(val => this.onMessageChange(val))
    );
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  init(friend) {
    this.friend = friend;
    this.audioFile = this.chatService.bufferAudioFile(this.config);

    this.signalrService.onMessageReceivedHandler = (friend, message) => this.onMessageReceived(friend, message);

    if (this.textCache?.id == this.friend.id)
      this.messageText.setValue(this.textCache.message);

    this.fetchMessageHistory(this.friend.id);
  }

  createForm() {
    this.form = new FormGroup({
      messageText: new FormControl(''),
    });
  }

  get messageText(): AbstractControl { return this.form.get('messageText'); }

  fetchMessageHistory(friendId: string) {
    this.signalrService.getMessageHistory(friendId)
      .pipe(take(1))
      .subscribe((result: Message[]) => {
        result.forEach((message) => this.chatService.assertMessageType(message));
        this.messages = result;
        setTimeout(() => this.onFetchMessageHistoryLoaded(result, ScrollDirection.Bottom));
      });
  }

  private onMessageReceived(friend: IChatParticipant, message: Message) {
    if (!friend || !message) return;

    this.chatService.assertMessageType(message);

    this.messages.push(message);

    this.scrollChatWindow(ScrollDirection.Bottom);

    this.chatService.markMessagesAsRead([message]);
    this.signalrService.sendOnMessagesSeenEvent([message]);

    this.audioFile.play();
  }

  private onFetchMessageHistoryLoaded(messages: Message[], direction: ScrollDirection, forceMarkMessagesAsSeen: boolean = false): void {

    this.scrollChatWindow(direction)
    const unseenMessages = messages.filter(m => !m.dateSeen);

    this.chatService.markMessagesAsRead(unseenMessages);
    setTimeout(() => this.isBootstrapped = true);
  }

  scrollChatWindow(direction: ScrollDirection): void {
    if (this.window) {
      setTimeout(() => {
        let element = this.window.nativeElement;
        let position = (direction === ScrollDirection.Top) ? 0 : element.scrollHeight;
        element.scrollTop = position;
      })
    }
  }

  onMessageChange(message) {
    this.textCache = { id: this.friend.id, message };

    const lines = message.split('\n').length + 1;
    if(lines >= 1 && lines <= 6 && this.textAreaLines != lines) {
      this.textAreaLines = lines;
      this.scrollChatWindow(ScrollDirection.Bottom);
    }
  }

  sendMessage(event) {

    // enter adds new line if mobile view
    if(this.mediaObserver.isActive('lt-sm') && event instanceof KeyboardEvent) {
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

    this.messages.push(message);
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
