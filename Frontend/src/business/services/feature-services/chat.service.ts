import { HttpClient } from '@angular/common/http';
import { ElementRef, Injectable, OnDestroy, QueryList } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { Subject } from 'rxjs';
import { map } from 'rxjs/internal/operators/map';
import { Subscription } from 'rxjs/internal/Subscription';
import { take, tap } from 'rxjs/operators';
import { ChatParticipantStatus } from 'src/app/features/chat/models/enums/chat-participant-status.enum';
import { ChatParticipantType } from 'src/app/features/chat/models/enums/chat-participant-type.enum';
import { MessageType } from 'src/app/features/chat/models/enums/message-type.enum';
import { ScrollDirection } from 'src/app/features/chat/models/enums/scroll-direction.enum';
import { Message } from 'src/app/features/chat/models/message.model';
import { ChatUploadService } from 'src/app/features/chat/services/chat-upload.service';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';
import { isNullOrWhitespace } from 'src/business/utils/utils';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ChatConfiguration } from './../../../app/features/chat/chat.configuration';
import { IChatParticipant } from './../../../app/features/chat/models/chat-participant.model';
import { ChatTheme } from './../../../app/features/chat/models/enums/chat-theme.enum';
import { ParticipantResponse } from './../../../app/features/chat/models/participant-response.model';
import { Window } from './../../../app/features/chat/models/window.model';
import { ChatSignalrService } from './../../../app/features/chat/services/chat-signalr.service';
import { PagingModel } from './../../../app/shared/material-table/table-models/paging.model';

@Injectable()
export class ChatService implements OnDestroy {


  //chat fullscreen
  textCache: { id: string, message: string }
  noMoreData = new Subject<boolean>();


  //Chat small


  // Exposes enums
  ChatParticipantType = ChatParticipantType;
  ChatParticipantStatus = ChatParticipantStatus;
  MessageType = MessageType;

  isBootstrapped = false;

  userId: string;
  config: ChatConfiguration;

  uploadService: ChatUploadService;
  audioFile: HTMLAudioElement

  scrollYPosition = 0;
  messages: Message[] = [];
  pagingModel = new PagingModel();

  friendsResponse: ParticipantResponse[];
  friends: IChatParticipant[];
  friendsInteractedWith: IChatParticipant[] = [];

  // Defines the size of each opened window to calculate how many windows can be opened on the viewport at the same time.
  windowSizeFactor: number = 320;
  friendsListWidth: number = 262; // Total width size of the friends list section
  viewPortTotalArea: number; // Available area to render small chat
  unsupportedViewport: boolean;

  windows: Window[] = [];
  messageSections: QueryList<ElementRef>;
  messageInputs: QueryList<ElementRef>; // message inputs
  fileInputs: QueryList<ElementRef>;
  searchInput: string = '';

  fileInputsInUse: string[] = []; // Id bucket of uploaders in use

  get localStorageKey(): string {
    return `chat-users-${this.userId}`; // Appending the user id so the state is unique per user in a computer.
  };

  messagesSubscription: Subscription

  constructor(
    private httpClient: HttpClient,
    private signalrService: ChatSignalrService,
    private store: Store<AppState>,
    private dialog: MatDialog
  ) {
    this.pagingModel.pageSize = 20;

    this.messagesSubscription = this.signalrService.messages$
    .subscribe(data => this.onMessageReceived(data.friend, data.message));
  }

  ngOnDestroy() {
    this.messagesSubscription.unsubscribe();
    console.log('Destroyed chat service..');
  }

  paramsInitialized = false;
  setParams(userId: string, fileInputs: QueryList<ElementRef>, messageInputs: QueryList<ElementRef>, messageSections: QueryList<ElementRef>) {
    this.userId = userId;
    this.fileInputs = fileInputs;
    this.messageInputs = messageInputs;
    this.messageSections = messageSections;

    this.paramsInitialized = true;
  }

  setConfiguration(theme: ChatTheme) {
    this.config = new ChatConfiguration({
      fileUploadUrl: `Chat/UploadChatFile`,
      theme: theme
    });
  }

  bootstrapChatFullscreen(window: Window) {
    if(!this.config || !this.paramsInitialized) throw new Error("Chat configuration not initialized");

    let friend = window.participant;

    this.friends = [friend];
    this.windows = [window];

    this.audioFile = this.bufferAudioFile(this.config);
    this.uploadService = new ChatUploadService(this.config.fileUploadUrl, this.httpClient);

    this.getMessageHistory(window, true)
    .pipe(take(1))
    .subscribe(messages => this.onFetchMessageHistoryLoaded(messages, window, ScrollDirection.Bottom));

    this.isBootstrapped = true;
  }

  bootstrapChatSmall(window: globalThis.Window): void {
    if(this.config == null || !this.paramsInitialized) throw Error("Chat configuration or parameters are not set");
    let initializationException = null;

    if (this.signalrService != null && this.userId != null) {
      try {
        this.viewPortTotalArea = window.innerWidth;

        this.fetchFriendsList(true);

        this.audioFile = this.bufferAudioFile(this.config);
        this.uploadService = new ChatUploadService(this.config.fileUploadUrl, this.httpClient);

        this.isBootstrapped = true;
      }
      catch (ex) {
        initializationException = ex;
      }
    }

    // error handle
    if (!this.isBootstrapped) {
      console.error("chat component couldn't be bootstrapped.");

      if (this.userId == null) {
        console.error("chat can't be initialized without an user id. Please make sure you've provided an userId as a parameter of the chat component.");
      }
      if (this.signalrService == null) {
        console.error("chat can't be bootstrapped without ChatService. Please make sure you've provided a ChatAdapter implementation as a parameter of the chat component.");
      }
      if (initializationException) {
        console.error(`An exception has occurred while initializing chat. Details: ${initializationException.message}`);
        console.error(initializationException);
      }
    }
  }

  // Sends a request to load the friends list
  fetchFriendsList(isBootstrapping: boolean): void {
    this.signalrService.listFriends()
      .pipe(take(1), map(response => this.onFriendsListChanged(response))
      ).subscribe(_ => {

        if (isBootstrapping) {
          this.restoreWindowsState();
        }

      });
  }

  restoreWindowsState(): void {
    try {
      if (!this.config.persistWindowsState) return;

      let friendIdsStr = localStorage.getItem(this.localStorageKey);
      if (isNullOrWhitespace(friendIdsStr)) return;

      let friendIds = <number[]>JSON.parse(friendIdsStr);
      let friendsToRestore = this.friends.filter(u => friendIds.indexOf(u.id) >= 0);

      friendsToRestore.forEach(friend => {
        const window = this.openChatWindow(friend)[0];
        window.isCollapsed = localStorage.getItem(`chat-window-${friend.id}`) == 'true' ? true : false;
      });
    }
    catch (ex) {
      console.error(`An error occurred while restoring chat windows state. Details: ${ex}`);
    }
  }

  // Opens a new chat whindow. Takes care of available viewport
  // Returns => [Window: Window object reference, boolean: Indicates if this window is a new chat window]
  openChatWindow(participant: IChatParticipant, focusOnNewWindow: boolean = false, invokedByUserClick: boolean = false): [Window, boolean] {

    // Is this window opened?
    let openedWindow = this.windows.find(x => x.participant.id == participant.id);
    if (openedWindow) return [openedWindow, false]; // already open

    // Refer to issue #58 on Github
    let collapseWindow = invokedByUserClick ? false : !this.config.maximizeWindowOnNewMessage;
    let newChatWindow = new Window(participant, this.config.historyEnabled, collapseWindow);

    // Loads the chat history via an RxJs Observable
    this.getMessageHistory(newChatWindow).subscribe(messages =>this.onFetchMessageHistoryLoaded(messages, newChatWindow, ScrollDirection.Bottom));

    this.windows.unshift(newChatWindow);

    // Is there enough space left in the view port ?
    if (this.windows.length * this.windowSizeFactor >= this.viewPortTotalArea - (!this.config.hideFriendsList ? this.friendsListWidth : 0)) {
      this.windows.pop();
    }

    this.updateWindowsState(this.windows);

    if (focusOnNewWindow && !collapseWindow) {
      this.focusOnWindow(newChatWindow);
    }

    this.friendsInteractedWith.push(participant);

    return [newChatWindow, true];

  }

  getMessageHistory(window: Window, init = true) {
    window.isLoadingHistory = true;

    return this.signalrService.getMessageHistory(window.participant.id, this.pagingModel)
      .pipe(
        take(1),
        tap(messages => messages.forEach(message => this.assertMessageType(message))),
      );
  }

  onFetchMessageHistoryLoaded(messages: Message[], window: Window, direction: ScrollDirection, forceMarkMessagesAsSeen: boolean = false): void {
    window.isLoadingHistory = false;
    window.messages = [...messages, ...window.messages];

    this.scrollChatWindow(window, direction)

    if (!window.hasFocus && !forceMarkMessagesAsSeen) return;

    const unseenMessages = messages.filter(m => !m.dateSeen);
    this.markMessagesAsRead(unseenMessages);
    this.signalrService.sendOnMessagesSeenEvent(unseenMessages);
  }

  // Updates the friends list via the event handler
  onFriendsListChanged(friendsResponse: ParticipantResponse[]): void {
    if (!friendsResponse) return;

    this.friendsResponse = friendsResponse;

    this.friends = friendsResponse.map(res => res.participant);
    this.friendsInteractedWith = [];
  }

  markMessagesAsRead(messages: Message[]): void {
    let currentDate = new Date();

    messages.forEach((msg) => {
      msg.dateSeen = currentDate;
    });
  }

  assertMessageType(message: Message) {

    if (!message.type) {
      message.type = MessageType.Text;
    }

    return message;
  }

  scrollChatWindow(window: Window, direction: ScrollDirection): void {
    if (window.isCollapsed) return;

    let windowIdx = this.windows.indexOf(window);
    let element = this.messageSections.toArray()[windowIdx].nativeElement;
    if (!element) return;

    setTimeout(_ => {
      this.scrollYPosition = element.scrollHeight;
      let position = (direction === ScrollDirection.Top) ? 0 : element.scrollHeight;
      element.scrollTop = position;
    })
  }

  // Saves current windows state into local storage if persistence is enabled
  updateWindowsState(windows: Window[]): void {
    if (this.config.persistWindowsState) {
      let participantIds = windows.map((w) => {
        return w.participant.id;
      });

      localStorage.setItem(this.localStorageKey, JSON.stringify(participantIds));
    }
  }

  // Focus on the input element of the supplied window
  focusOnWindow(window: Window, callback: Function = () => { }): void {
    let windowIndex = this.windows.indexOf(window);
    if (windowIndex >= 0) {
      setTimeout(() => {
        if (this.messageInputs.toArray()) {
          let messageInputToFocus = this.messageInputs.toArray()[windowIndex];

          messageInputToFocus.nativeElement.focus();
        }

        callback();
      });
    }
  }

  // Checks if there are more opened windows than the view port can display
  normalizeWindows(): void {
    let maxSupportedOpenedWindows = Math.floor((this.viewPortTotalArea - (!this.config.hideFriendsList ? this.friendsListWidth : 0)) / this.windowSizeFactor);
    let difference = this.windows.length - maxSupportedOpenedWindows;

    if (difference >= 0) {
      this.windows.splice(this.windows.length - difference);
    }

    this.updateWindowsState(this.windows);

    // Viewport should have space for at least one chat window.
    this.unsupportedViewport = this.config.hideFriendsListOnUnsupportedViewport && maxSupportedOpenedWindows < 1;
  }

  get filteredFriends(): IChatParticipant[] {
    if (this.searchInput.length > 0) {
      // Searches in the friend list by the inputted search string
      return this.friends.filter(x => x.displayName.toUpperCase().includes(this.searchInput.toUpperCase()));
    }

    return this.friends;
  }

  enlargeImage(message: Message) {
    this.dialog.open(MediaDialogComponent, {
      height: 'auto',
      width: 'auto',
      maxWidth: '58rem',
      maxHeight: '40rem',
      autoFocus: false,
      data: { type: message.type, sourceUrl: message.downloadUrl },
      panelClass: 'media-dialog-container'
    });
  }

  // Gets closest open window if any. Most recent opened has priority (Right)
  getClosestWindow(window: Window): Window | undefined {
    let index = this.windows.indexOf(window);

    if (index > 0) {
      return this.windows[index - 1];
    }
    else if (index == 0 && this.windows.length > 1) {
      return this.windows[index + 1];
    }
  }

  // Returns the total unread messages from a chat window. TODO: Could use some Angular pipes in the future
  unreadMessagesTotal(window: Window): string {
    let totalUnreadMessages = 0;

    if (window) {
      totalUnreadMessages = window.messages.filter(x => x.fromId != this.userId && !x.dateSeen).length;
    }

    return this.formatUnreadMessagesTotal(totalUnreadMessages);
  }

  unreadMessagesTotalByFriend(friend: IChatParticipant): string {
    let openedWindow = this.windows.find(x => x.participant.id == friend.id);

    if (openedWindow) {
      return this.unreadMessagesTotal(openedWindow);
    }
    else {
      let totalUnreadMessages = this.friendsResponse
      .filter(x => x.participant.id == friend.id && !this.friendsInteractedWith
      .find(u => u.id == friend.id) && x.metadata && x.metadata.totalUnreadMessages > 0)
      .map(res => res.metadata.totalUnreadMessages)[0];

      return this.formatUnreadMessagesTotal(totalUnreadMessages);
    }
  }

  formatUnreadMessagesTotal(totalUnreadMessages: number): string {
    if (totalUnreadMessages > 0) {

      if (totalUnreadMessages > 99)
        return "99+";
      else
        return String(totalUnreadMessages);
    }

    // Empty fallback.
    return "";
  }

  /*  Monitors pressed keys on a chat window
    - Dispatches a message when the ENTER key is pressed
    - Tabs between windows on TAB or SHIFT + TAB
    - Closes the current focused window on ESC
*/
  onChatInputTyped(event: any, window: Window): void {
    switch (event.keyCode) {
      case 13:
        if (window.newMessage && window.newMessage.trim() != "") {
          let message = new Message();

          message.fromId = this.userId;
          message.toId = window.participant.id;
          message.message = window.newMessage;
          message.dateSent = new Date();

          window.messages.push(message);
          this.signalrService.sendMessage(message);

          window.newMessage = ""; // Resets the new message input

          this.scrollChatWindow(window, ScrollDirection.Bottom);
        }
        break;
      case 9:
        event.preventDefault();

        let currentWindowIndex = this.windows.indexOf(window);
        let messageInputToFocus = this.messageInputs.toArray()[currentWindowIndex + (event.shiftKey ? 1 : -1)]; // Goes back on shift + tab

        if (!messageInputToFocus) {
          // Edge windows, go to start or end
          messageInputToFocus = this.messageInputs.toArray()[currentWindowIndex > 0 ? 0 : this.messageInputs.toArray().length - 1];
        }

        messageInputToFocus.nativeElement.focus();

        break;
      case 27:
        let closestWindow = this.getClosestWindow(window);

        if (closestWindow) {
          this.focusOnWindow(closestWindow, () => { this.onCloseChatWindow(window); });
        }
        else {
          this.onCloseChatWindow(window);
        }
    }
  }

  // Closes a chat window via the close 'X' button
  onCloseChatWindow(window: Window): void {
    let index = this.windows.indexOf(window);

    this.windows.splice(index, 1);

    this.updateWindowsState(this.windows);
  }

  // Toggle friends list visibility
  onChatTitleClicked(): void {
    this.config.isCollapsed = !this.config.isCollapsed;
    localStorage.setItem('chat-collapsed', this.config.isCollapsed.toString());
  }

  // Toggles a chat window visibility between maximized/minimized
  onChatWindowClicked(window: Window): void {
    window.isCollapsed = !window.isCollapsed;
    this.scrollChatWindow(window, ScrollDirection.Bottom);
    var key = 'chat-window-' + window.participant.id;
    localStorage.setItem(key, window.isCollapsed.toString());
  }

  // Toggles a window focus on the focus/blur of a 'newMessage' input
  toggleWindowFocus(window: Window): void {
    window.hasFocus = !window.hasFocus;
    if (window.hasFocus) {
      const unreadMessages = window.messages
        .filter(message => message.dateSeen == null
          && (message.toId == this.userId || window.participant.participantType === ChatParticipantType.Group));

      if (unreadMessages && unreadMessages.length > 0) {
        this.markMessagesAsRead(unreadMessages);
        this.signalrService.sendOnMessagesSeenEvent(unreadMessages);
      }
    }
  }




  // Generates a unique file uploader id for each participant
  getUniqueFileUploadInstanceId(window: Window): string {
    if (window && window.participant) {
      return `chat-file-upload-${window.participant.id}`;
    }

    return 'chat-file-upload';
  }

  // Triggers native file upload for file selection from the user
  triggerNativeFileUpload(window: Window): void {
    if (window) {
      const fileUploadInstanceId = this.getUniqueFileUploadInstanceId(window);
      const uploadElementRef = this.fileInputs.toArray().filter(x => x.nativeElement.id === fileUploadInstanceId)[0];

      if (uploadElementRef)
        uploadElementRef.nativeElement.click();
    }
  }

  clearInUseFileUploader(fileUploadInstanceId: string): void {
    const uploaderInstanceIdIndex = this.fileInputsInUse.indexOf(fileUploadInstanceId);

    if (uploaderInstanceIdIndex > -1) {
      this.fileInputsInUse.splice(uploaderInstanceIdIndex, 1);
    }
  }

  isUploadingFile(window: Window): boolean {
    const fileUploadInstanceId = this.getUniqueFileUploadInstanceId(window);

    return this.fileInputsInUse.indexOf(fileUploadInstanceId) > -1;
  }

  // Handles file selection and uploads the selected file using the file upload adapter
  onFileChosen(window: Window): void {
    const fileUploadInstanceId = this.getUniqueFileUploadInstanceId(window);
    const uploadElementRef = this.fileInputs.toArray().filter(x => x.nativeElement.id === fileUploadInstanceId)[0];

    if (uploadElementRef) {
      const file: File = uploadElementRef.nativeElement.files[0];

      this.fileInputsInUse.push(fileUploadInstanceId);

      this.uploadService.uploadFile(file, window.participant.id)
        .subscribe(fileMessage => {
          this.clearInUseFileUploader(fileUploadInstanceId);

          fileMessage.fromId = this.userId;

          // Push file message to current user window
          window.messages.push(fileMessage);

          this.signalrService.sendMessage(fileMessage);

          this.scrollChatWindow(window, ScrollDirection.Bottom);

          // Resets the file upload element
          uploadElementRef.nativeElement.value = '';
        }, error => {
          this.clearInUseFileUploader(fileUploadInstanceId);

          // Resets the file upload element
          uploadElementRef.nativeElement.value = '';

          // TODO: Invoke a file upload adapter error here
        });
    }
  }

  // messagesFetched(messages: Message[], direction: ScrollDirection): void {
  //   this.messages = messages;
  //   this.pagingModel.page += 1;

  //   this.markMessagesSeen(messages);
  //   this.store.dispatch(allMessagesSeen({ friendId: this.friend.id }));

  //   this.isBootstrapped = true;
  //   setTimeout(_ => this.scrollChatWindow(this.window, direction));
  // }

  markMessagesSeen(messages: Message[]) {
    const unseenMessages = messages.filter(m => !m.dateSeen);
    this.markMessagesAsRead(unseenMessages);
  }

  onMessageReceived(friend: IChatParticipant, message: Message) {
    if (!message) return;
    if (friend?.id != message.fromId) {
      // this.store.dispatch(messageFromAnotherFriend({ friend }))
      return;
    };

    let chatWindow = this.openChatWindow(friend);

    this.assertMessageType(message);

    // this.store.dispatch(pushMessage({ message }));
    chatWindow[0].messages.push(message);

    setTimeout(_ => {
      this.scrollChatWindow(chatWindow[0], ScrollDirection.Bottom);
      this.audioFile.play();
    })
  }

  // sendMessage(event) {

  //   // enter adds new line if mobile view
  //   if (this.mediaObserver.isActive('lt-sm') && event instanceof KeyboardEvent) {
  //     return;
  //   }

  //   event.preventDefault();

  //   let messageRaw = this.messageText.value;
  //   if (messageRaw == '') return;

  //   let message = new Message();
  //   message.fromId = this.userId;
  //   message.toId = this.friend.id;
  //   message.message = messageRaw;
  //   message.dateSent = new Date();

  //   // this.store.dispatch(pushMessage({ message }));
  //   this.messages.push(message);

  //   this.signalrService.sendMessage(message);

  //   this.messageText.setValue('') // Resets the new message input
  //   this.scrollChatWindow(ScrollDirection.Bottom);
  // }

  addFile(event) {

  }

  // Asserts if a user avatar is visible in a chat cluster
  isAvatarVisible(userId: string, messages: Message[], message: Message, index: number): boolean {

    // if i'm sending the message... don't show my avatar to me
    if (message.fromId == userId) return false;

    // ========= other person is only relevant for avatar showing ==========

    // last message
    if (index >= messages?.length) return true;

    // if I sent more messages... i want avatar to show on last one
    // so if my streak is done... ie next message is from other user.. show avatar
    if (messages[index + 1]?.fromId != message?.fromId)
      return true;

    // otherwise don't
    return false
  }

  // Buffers audio file (For component's bootstrapping)
  bufferAudioFile(config: ChatConfiguration) {
    if (config.audioSource && config.audioSource.length > 0) {
      let audioFile = new Audio();
      audioFile.src = config.audioSource;
      audioFile.load();

      return audioFile;
    }
  }

}

