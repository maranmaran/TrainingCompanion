import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Component, ElementRef, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { noop } from 'rxjs';
import { take } from 'rxjs/operators';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { selectedFriend } from './../../../../../../ngrx/chat/chat.selectors';
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

  @ViewChild('chatWindow') window: ElementRef;
  @ViewChild('autosize') autosizeTextarea: CdkTextareaAutosize;

  subs = new SubSink();
  friend: IChatParticipant;
  messages: Message[]

  form: FormGroup
  textCache: { id: string, message: string }
  textAreaLines: number = 1;

  constructor(
    private _ngZone: NgZone,
    private signalrService: ChatSignalrService,
    private store: Store<AppState>,
    private chatService: ChatService
  ) { }

  ngOnInit(): void {
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

  private onFetchMessageHistoryLoaded(messages: Message[], direction: ScrollDirection, forceMarkMessagesAsSeen: boolean = false): void {

    this.scrollChatWindow(direction)
    const unseenMessages = messages.filter(m => !m.dateSeen);

    this.chatService.markMessagesAsRead(unseenMessages);
  }

  private scrollChatWindow(direction: ScrollDirection): void {
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
    if(lines >= 1 && lines <= 5 && this.textAreaLines != lines) {
      this.textAreaLines = lines;
      this.scrollChatWindow(ScrollDirection.Bottom);
    }
  }

  sendMessage(event) {
    event.preventDefault();
    let message = this.messageText.value;
    if (message == '') return;
  }

  triggerResize() {
    // Wait for changes to be applied, then trigger textarea resize.
    this._ngZone.onStable.pipe(take(1))
      .subscribe(() => (this.autosizeTextarea.resizeToFitContent(true)));
  }

}
