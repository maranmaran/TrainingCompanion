import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Component, ElementRef, Input, NgZone, ViewChild } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Subject } from 'rxjs';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { ChatConfiguration } from './../../../chat.configuration';
import { IChatParticipant } from './../../../models/chat-participant.model';
import { Message } from './../../../models/message.model';
import { ChatSignalrService } from './../../../services/chat-signalr.service';

@Component({
  selector: 'app-chat-body',
  templateUrl: './chat-body.component.html',
  styleUrls: ['./chat-body.component.scss']
})
// export class ChatBodyComponent implements OnInit, OnChanges, OnDestroy {
export class ChatBodyComponent  {

  @Input() config: ChatConfiguration;
  @Input() friend: IChatParticipant;

  @ViewChild('chatWindow') window: ElementRef;
  @ViewChild('autosize') autosizeTextarea: CdkTextareaAutosize;

  isBootstrapped = false;

  subs = new SubSink();
  messages: Message[];
  noMoreData = new Subject<boolean>();

  userId: string;
  form: FormGroup
  textCache: { id: string, message: string }
  textAreaLines: number = 1;

  scrollEvent = new Subject<any>();

  private audioFile: HTMLAudioElement;

  constructor(
    private _ngZone: NgZone,
    private signalrService: ChatSignalrService,
    private store: Store<AppState>,
    private chatService: ChatService,
    private mediaObserver: MediaObserver,
  ) { }

  // ngOnInit(): void {
  //   this.store.select(currentUserId).subscribe(id => this.userId = id);

  //   this.signalrService.onMessageReceivedHandlerFullscreenChat = (friend, message) => this.onMessageReceived(friend, message);
  //   this.createForm();

  //   this.subs.add(
  //     this.messageText.valueChanges.subscribe(val => this.onMessageChange(val))
  //   );
  // }

  // ngOnChanges(changes: SimpleChanges) {
  //   this.isBootstrapped = false;

  //   // 600 ms is default transition for tabs
  //   //https://material.angular.io/components/tabs/api#MatTabsConfig
  //   let tabsAnimationDelay = 600;
  //   if (changes.friend.currentValue && changes.friend.currentValue.id != changes.friend.previousValue?.id)
  //     setTimeout(_ => this.chatService.init(changes.friend.currentValue), this.mediaObserver.isActive('lt-md') ? tabsAnimationDelay : 0);
  // }

  // ngOnDestroy() {
  //   this.subs.unsubscribe();
  // }

  // createForm() {
  //   this.form = new FormGroup({
  //     messageText: new FormControl(''),
  //   });
  // }

  // get messageText(): AbstractControl { return this.form.get('messageText'); }


  // onMessageChange(message) {
  //   this.textCache = { id: this.friend.id, message };

  //   const lines = message.split('\n').length + 1;
  //   if (lines >= 1 && lines <= 6 && this.textAreaLines != lines) {
  //     this.textAreaLines = lines;
  //     this.scrollChatWindow(ScrollDirection.Bottom);
  //   }
  // }

  // triggerResize() {
  //   // Wait for changes to be applied, then trigger textarea resize.
  //   this._ngZone.onStable.pipe(take(1))
  //     .subscribe(() => (this.autosizeTextarea.resizeToFitContent(true)));
  // }

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
