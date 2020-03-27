import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, EventEmitter, HostListener, Input, OnInit, Output, ViewChildren, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DomSanitizer } from '@angular/platform-browser';
import { map, take } from 'rxjs/operators';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';
import { ChatConfiguration } from '../../chat.configuration';
import { IChatParticipant } from '../../models/chat-participant.model';
import { ChatParticipantStatus } from '../../models/enums/chat-participant-status.enum';
import { ChatParticipantType } from '../../models/enums/chat-participant-type.enum';
import { MessageType } from '../../models/enums/message-type.enum';
import { ScrollDirection } from '../../models/enums/scroll-direction.enum';
import { Message } from '../../models/message.model';
import { ParticipantResponse } from '../../models/participant-response.model';
import { User } from '../../models/user.model';
import { Window } from '../../models/window.model';
import { ChatSignalrService } from '../../services/chat-signalr.service';
import { ChatUploadService } from '../../services/chat-upload.service';

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
  encapsulation: ViewEncapsulation.None
})
export class ChatSmallComponent implements OnInit {

  constructor(
    public sanitizer: DomSanitizer,
    private _httpClient: HttpClient,
    private dialog: MatDialog,
    private signalrService: ChatSignalrService
  ) { }

  private uploadService: ChatUploadService;

  // Exposes enums for the ng-template
  ChatParticipantType = ChatParticipantType;
  ChatParticipantStatus = ChatParticipantStatus;
  MessageType = MessageType;

  @Input() config: ChatConfiguration;
  @Input() userId: string;

  @Output()
  onMessagesSeen: EventEmitter<Message[]> = new EventEmitter<Message[]>();

  browserNotificationsBootstrapped: boolean = false;
  hasPagedHistory: boolean = true;

  private audioFile: HTMLAudioElement;

  public searchInput: string = '';

  participants: IChatParticipant[];
  participantsResponse: ParticipantResponse[];
  private participantsInteractedWith: IChatParticipant[] = [];

  selectedUsersFromFriendsList: User[] = [];

  private get localStorageKey(): string {
    return `chat-users-${this.userId}`; // Appending the user id so the state is unique per user in a computer.
  };

  // Defines the size of each opened window to calculate how many windows can be opened on the viewport at the same time.
  public windowSizeFactor: number = 320;

  // Total width size of the friends list section
  public friendsListWidth: number = 262;

  // Available area to render the plugin
  private viewPortTotalArea: number;

  // Set to true if there is no space to display at least one chat window and 'hideFriendsListOnUnsupportedViewport' is true
  public unsupportedViewport: boolean = false;

  // File upload state
  public fileUploadersInUse: string[] = []; // Id bucket of uploaders in use

  windows: Window[] = [];

  isBootstrapped: boolean = false;

  @ViewChildren('chatMessages') chatMessageClusters: any;

  @ViewChildren('chatWindowInput') chatWindowInputs: any;

  @ViewChildren('nativeFileInput') nativeFileInputs: ElementRef[];


  // TODO: Add media observer for this
  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.viewPortTotalArea = event.target.innerWidth;

    this.NormalizeWindows();
  }

  ngOnInit() {
    setTimeout(() => this.bootstrapChat())
  }

  ngOnDestroy(): void {
    localStorage.removeItem(this.localStorageKey);
  }

  // Initializes the chat plugin and the messaging adapter
  private bootstrapChat(): void {
    let initializationException = null;

    if (this.signalrService != null && this.userId != null) {
      try {
        this.viewPortTotalArea = window.innerWidth;

        this.initializeBrowserNotifications();

        // Binding event listeners
        this.signalrService.onMessageReceivedHandler = (participant, msg) => this.onMessageReceived(participant, msg);
        this.signalrService.onFriendsListChangedHandler = (participantsResponse) => this.onFriendsListChanged(participantsResponse);

        // Loading current users list
        if (this.config.pollFriendsList) {
          // Setting a long poll interval to update the friends list
          this.fetchFriendsList(true);
          setInterval(() => this.fetchFriendsList(false), this.config.pollingInterval);
        }
        else {
          // Since polling was disabled, a friends list update mechanism will have to be implemented in the ChatAdapter.
          this.fetchFriendsList(true);
        }

        this.bufferAudioFile();


        if (this.config.fileUploadUrl && this.config.fileUploadUrl !== "") {
          this.uploadService = new ChatUploadService(this.config.fileUploadUrl, this._httpClient);
        }

        this.isBootstrapped = true;
      }
      catch (ex) {
        initializationException = ex;
      }
    }

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

  get filteredParticipants(): IChatParticipant[] {
    if (this.searchInput.length > 0) {
      // Searches in the friend list by the inputted search string
      return this.participants.filter(x => x.displayName.toUpperCase().includes(this.searchInput.toUpperCase()));
    }

    return this.participants;
  }

  // Checks if there are more opened windows than the view port can display
  private NormalizeWindows(): void {
    let maxSupportedOpenedWindows = Math.floor((this.viewPortTotalArea - (!this.config.hideFriendsList ? this.friendsListWidth : 0)) / this.windowSizeFactor);
    let difference = this.windows.length - maxSupportedOpenedWindows;

    if (difference >= 0) {
      this.windows.splice(this.windows.length - difference);
    }

    this.updateWindowsState(this.windows);

    // Viewport should have space for at least one chat window.
    this.unsupportedViewport = this.config.hideFriendsListOnUnsupportedViewport && maxSupportedOpenedWindows < 1;
  }

  // Initializes browser notifications
  private async initializeBrowserNotifications() {
    if (this.config.browserNotificationsEnabled && ("Notification" in window)) {
      if (await Notification.requestPermission()) {
        this.browserNotificationsBootstrapped = true;
      }
    }
  }

  // Sends a request to load the friends list
  private fetchFriendsList(isBootstrapping: boolean): void {
    this.signalrService.listFriends()
      .pipe(
        map((participantsResponse: ParticipantResponse[]) => {
          this.participantsResponse = participantsResponse;

          this.participants = participantsResponse.map((response: ParticipantResponse) => {
            return response.participant;
          });
        }),
        take(1)
      ).subscribe(() => {
        if (isBootstrapping) {
          this.restoreWindowsState();
        }
      });
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

  fetchMessageHistory(window: Window) {
    // PAGED MESSAGE HISTORY RETRIEVAL
    // Not ideal but will keep this until we decide if we are shipping pagination with the default adapter
    // if (this.signalrService ) {
    //   window.isLoadingHistory = true;

    //   this.signalrService.getMessageHistoryByPage(window.participant.id, this.historyPageSize, ++window.historyPage)
    //     .pipe(
    //       map((result: Message[]) => {
    //         result.forEach((message) => this.assertMessageType(message));

    //         window.messages = result.concat(window.messages);
    //         window.isLoadingHistory = false;

    //         const direction: ScrollDirection = (window.historyPage == 1) ? ScrollDirection.Bottom : ScrollDirection.Top;
    //         window.hasMoreMessages = result.length == this.historyPageSize;

    //         setTimeout(() => this.onFetchMessageHistoryLoaded(result, window, direction, true));
    //       })
    //     ).subscribe();
    // }
    // else {

    // ALL MESSAGE HISTORY RETRIEVAL
    this.signalrService.getMessageHistory(window.participant.id)
      .pipe(
        map((result: Message[]) => {
          result.forEach((message) => this.assertMessageType(message));

          window.messages = result.concat(window.messages);
          window.isLoadingHistory = false;

          setTimeout(() => this.onFetchMessageHistoryLoaded(result, window, ScrollDirection.Bottom));
        })
      ).subscribe();
  }

  private onFetchMessageHistoryLoaded(messages: Message[], window: Window, direction: ScrollDirection, forceMarkMessagesAsSeen: boolean = false): void {
    this.scrollChatWindow(window, direction)

    if (window.hasFocus || forceMarkMessagesAsSeen) {
      const unseenMessages = messages.filter(m => !m.dateSeen);

      this.markMessagesAsRead(unseenMessages);
      this.onMessagesSeen.emit(unseenMessages);
    }
  }

  // Updates the friends list via the event handler
  private onFriendsListChanged(participantsResponse: ParticipantResponse[]): void {
    if (participantsResponse) {
      this.participantsResponse = participantsResponse;

      this.participants = participantsResponse.map((response: ParticipantResponse) => {
        return response.participant;
      });

      this.participantsInteractedWith = [];
    }
  }

  // Handles received messages by the adapter
  private onMessageReceived(participant: IChatParticipant, message: Message) {
    if (participant && message) {
      let chatWindow = this.openChatWindow(participant);

      this.assertMessageType(message);

      if (!chatWindow[1] || !this.config.historyEnabled) {
        chatWindow[0].messages.push(message);

        this.scrollChatWindow(chatWindow[0], ScrollDirection.Bottom);

        if (chatWindow[0].hasFocus) {
          this.markMessagesAsRead([message]);
          this.onMessagesSeen.emit([message]);
        }
      }

      this.emitMessageSound(chatWindow[0]);

      // Github issue #58
      // Do not push browser notifications with message content for privacy purposes if the 'maximizeWindowOnNewMessage' setting is off and this is a new chat window.
      if (this.config.maximizeWindowOnNewMessage || (!chatWindow[1] && !chatWindow[0].isCollapsed)) {
        // Some messages are not pushed because they are loaded by fetching the history hence why we supply the message here
        this.emitBrowserNotification(chatWindow[0], message);
      }
    }
  }

  // Opens a new chat whindow. Takes care of available viewport
  // Works for opening a chat window for an user or for a group
  // Returns => [Window: Window object reference, boolean: Indicates if this window is a new chat window]
  public openChatWindow(participant: IChatParticipant, focusOnNewWindow: boolean = false, invokedByUserClick: boolean = false): [Window, boolean] {
    // Is this window opened?
    let openedWindow = this.windows.find(x => x.participant.id == participant.id);

    if (!openedWindow) {
      // Refer to issue #58 on Github
      let collapseWindow = invokedByUserClick ? false : !this.config.maximizeWindowOnNewMessage;
      let newChatWindow = new Window(participant, this.config.historyEnabled, collapseWindow);

      // Loads the chat history via an RxJs Observable
      if (this.config.historyEnabled) {
        this.fetchMessageHistory(newChatWindow);
      }

      this.windows.unshift(newChatWindow);

      // Is there enough space left in the view port ?
      if (this.windows.length * this.windowSizeFactor >= this.viewPortTotalArea - (!this.config.hideFriendsList ? this.friendsListWidth : 0)) {
        this.windows.pop();
      }

      this.updateWindowsState(this.windows);

      if (focusOnNewWindow && !collapseWindow) {
        this.focusOnWindow(newChatWindow);
      }

      this.participantsInteractedWith.push(participant);

      return [newChatWindow, true];
    }
    else {
      // Returns the existing chat window
      return [openedWindow, false];
    }
  }

  // Focus on the input element of the supplied window
  private focusOnWindow(window: Window, callback: Function = () => { }): void {
    let windowIndex = this.windows.indexOf(window);
    if (windowIndex >= 0) {
      setTimeout(() => {
        if (this.chatWindowInputs) {
          let messageInputToFocus = this.chatWindowInputs.toArray()[windowIndex];

          messageInputToFocus.nativeElement.focus();
        }

        callback();
      });
    }
  }

  // Scrolls a chat window message flow to the bottom
  private scrollChatWindow(window: Window, direction: ScrollDirection): void {
    if (!window.isCollapsed) {
      let windowIndex = this.windows.indexOf(window);
      setTimeout(() => {
        if (this.chatMessageClusters) {
          let targetWindow = this.chatMessageClusters.toArray()[windowIndex];

          if (targetWindow) {
            let element = this.chatMessageClusters.toArray()[windowIndex].nativeElement;
            let position = (direction === ScrollDirection.Top) ? 0 : element.scrollHeight;
            element.scrollTop = position;
          }
        }
      });
    }
  }

  // Marks all messages provided as read with the current time.
  public markMessagesAsRead(messages: Message[]): void {
    let currentDate = new Date();

    messages.forEach((msg) => {
      msg.dateSeen = currentDate;
    });
  }

  // Buffers audio file (For component's bootstrapping)
  private bufferAudioFile(): void {
    if (this.config.audioSource && this.config.audioSource.length > 0) {
      this.audioFile = new Audio();
      this.audioFile.src = this.config.audioSource;
      this.audioFile.load();
    }
  }

  // Emits a message notification audio if enabled after every message received
  private emitMessageSound(window: Window): void {
    if (this.config.audioEnabled && !window.hasFocus && this.audioFile) {
      this.audioFile.play();
    }
  }

  // Emits a browser notification
  private emitBrowserNotification(window: Window, message: Message): void {
    if (this.browserNotificationsBootstrapped && !window.hasFocus && message) {
      let notification = new Notification(`${this.config.localization.browserNotificationTitle} ${window.participant.displayName}`, {
        'body': message.message,
        'icon': this.config.browserNotificationIconSource
      });

      setTimeout(() => {
        notification.close();
      }, message.message.length <= 50 ? 5000 : 7000); // More time to read longer messages
    }
  }

  // Saves current windows state into local storage if persistence is enabled
  private updateWindowsState(windows: Window[]): void {
    if (this.config.persistWindowsState) {
      let participantIds = windows.map((w) => {
        return w.participant.id;
      });

      localStorage.setItem(this.localStorageKey, JSON.stringify(participantIds));
    }
  }

  private restoreWindowsState(): void {
    try {
      if (this.config.persistWindowsState) {
        let stringfiedParticipantIds = localStorage.getItem(this.localStorageKey);

        if (stringfiedParticipantIds && stringfiedParticipantIds.length > 0) {
          let participantIds = <number[]>JSON.parse(stringfiedParticipantIds);

          let participantsToRestore = this.participants.filter(u => participantIds.indexOf(u.id) >= 0);

          participantsToRestore.forEach((participant) => {
            const window = this.openChatWindow(participant)[0];
            window.isCollapsed = localStorage.getItem(`chat-window-${participant.id}`) == 'true' ?
              true : false;
          });
        }
      }
    }
    catch (ex) {
      console.error(`An error occurred while restoring chat windows state. Details: ${ex}`);
    }
  }

  // Gets closest open window if any. Most recent opened has priority (Right)
  private getClosestWindow(window: Window): Window | undefined {
    let index = this.windows.indexOf(window);

    if (index > 0) {
      return this.windows[index - 1];
    }
    else if (index == 0 && this.windows.length > 1) {
      return this.windows[index + 1];
    }
  }

  private assertMessageType(message: Message): void {
    // Always fallback to "Text" messages to avoid rendenring issues
    if (!message.type) {
      message.type = MessageType.Text;
    }
  }

  private formatUnreadMessagesTotal(totalUnreadMessages: number): string {
    if (totalUnreadMessages > 0) {

      if (totalUnreadMessages > 99)
        return "99+";
      else
        return String(totalUnreadMessages);
    }

    // Empty fallback.
    return "";
  }

  // Returns the total unread messages from a chat window. TODO: Could use some Angular pipes in the future
  unreadMessagesTotal(window: Window): string {
    let totalUnreadMessages = 0;

    if (window) {
      totalUnreadMessages = window.messages.filter(x => x.fromId != this.userId && !x.dateSeen).length;
    }

    return this.formatUnreadMessagesTotal(totalUnreadMessages);
  }

  unreadMessagesTotalByParticipant(participant: IChatParticipant): string {
    let openedWindow = this.windows.find(x => x.participant.id == participant.id);

    if (openedWindow) {
      return this.unreadMessagesTotal(openedWindow);
    }
    else {
      let totalUnreadMessages = this.participantsResponse
        .filter(x => x.participant.id == participant.id &&
                    !this.participantsInteractedWith
                              .find(u => u.id == participant.id) && x.metadata && x.metadata.totalUnreadMessages > 0)
        .map((participantResponse) => {
          return participantResponse.metadata.totalUnreadMessages
        })[0];

      return this.formatUnreadMessagesTotal(totalUnreadMessages);
    }
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
        let messageInputToFocus = this.chatWindowInputs.toArray()[currentWindowIndex + (event.shiftKey ? 1 : -1)]; // Goes back on shift + tab

        if (!messageInputToFocus) {
          // Edge windows, go to start or end
          messageInputToFocus = this.chatWindowInputs.toArray()[currentWindowIndex > 0 ? 0 : this.chatWindowInputs.length - 1];
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
  onChatTitleClicked(event: any): void {
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

  // Asserts if a user avatar is visible in a chat cluster
  isAvatarVisible(window: Window, message: Message, index: number): boolean {

    // if i'm sending the message... don't show my avatar to me
    if(message.fromId == this.userId) return false;

    // ========= other person is only relevant for avatar showing ==========

    // last message
    if(index >= window.messages?.length) return true;

    // if I sent more messages... i want avatar to show on last one
    // so if my streak is done... ie next message is from other user.. show avatar
    if(window.messages[index + 1].fromId != message.fromId)
      return true;

    // otherwise don't
    return false
  }

  getChatWindowAvatar(participant: IChatParticipant, message: Message): string | null {
    return participant.avatar;
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
        this.onMessagesSeen.emit(unreadMessages);
      }
    }
  }

  // [Localized] Returns the status descriptive title
  getStatusTitle(status: ChatParticipantStatus): any {
    let currentStatus = status.toString().toLowerCase();

    return this.config.localization.statusDescription[currentStatus];
  }

  triggerOpenChatWindow(user: User): void {
    if (user) {
      this.openChatWindow(user);
    }
  }

  triggerCloseChatWindow(userId: any): void {
    let openedWindow = this.windows.find(x => x.participant.id == userId);

    if (openedWindow) {
      this.onCloseChatWindow(openedWindow);
    }
  }

  triggerToggleChatWindowVisibility(userId: any): void {
    let openedWindow = this.windows.find(x => x.participant.id == userId);

    if (openedWindow) {
      this.onChatWindowClicked(openedWindow);
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
      const uploadElementRef = this.nativeFileInputs.filter(x => x.nativeElement.id === fileUploadInstanceId)[0];

      if (uploadElementRef)
        uploadElementRef.nativeElement.click();
    }
  }

  private clearInUseFileUploader(fileUploadInstanceId: string): void {
    const uploaderInstanceIdIndex = this.fileUploadersInUse.indexOf(fileUploadInstanceId);

    if (uploaderInstanceIdIndex > -1) {
      this.fileUploadersInUse.splice(uploaderInstanceIdIndex, 1);
    }
  }

  isUploadingFile(window: Window): boolean {
    const fileUploadInstanceId = this.getUniqueFileUploadInstanceId(window);

    return this.fileUploadersInUse.indexOf(fileUploadInstanceId) > -1;
  }

  // Handles file selection and uploads the selected file using the file upload adapter
  onFileChosen(window: Window): void {
    const fileUploadInstanceId = this.getUniqueFileUploadInstanceId(window);
    const uploadElementRef = this.nativeFileInputs.filter(x => x.nativeElement.id === fileUploadInstanceId)[0];

    if (uploadElementRef) {
      const file: File = uploadElementRef.nativeElement.files[0];

      this.fileUploadersInUse.push(fileUploadInstanceId);

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

  // TODO: Figure this out.....
  isCoachSelectedFromFriendsList(user: User): boolean {
    return (this.selectedUsersFromFriendsList.filter(item => item.id == user.id)).length > 0
  }

}
