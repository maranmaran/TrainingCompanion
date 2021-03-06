import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { Store } from '@ngrx/store';
import { Observable, Subject, throwError } from 'rxjs';
import { catchError, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { AuthService } from '../../../../business/services/feature-services/auth.service';
import { currentUser } from '../../../../ngrx/auth/auth.selectors';
import { AccountType } from '../../../../server-models/enums/account-type.enum';
import { AppSettingsService } from './../../../../business/services/shared/app-settings.service';
import { PagingModel } from './../../../shared/material-table/table-models/paging.model';
import { IChatParticipant } from './../models/chat-participant.model';
import { Message } from './../models/message.model';
import { ParticipantResponse } from './../models/participant-response.model';

@Injectable()
export class ChatSignalrService implements OnDestroy {

  params: { userId: string; userAccountType: AccountType };

  hubConnection: signalR.HubConnection;
  subs = new SubSink();

  private messagesSubject = new Subject<({ friend: IChatParticipant, message: Message })>()
  messages$ = this.messagesSubject.asObservable();

  constructor(
    private authService: AuthService,
    private store: Store<AppState>,
    private http: HttpClient,
    private appSettings: AppSettingsService
  ) {
    this.subs.add(this.authService.signOutEvent.subscribe(() => this.stopConnection()));
  }

  init() {
    this.store.select(currentUser)
      .pipe(take(1), map(user => ({ userId: user.id, userAccountType: user.accountType })))
      .subscribe(
        params => {
          this.params = params;
          this.initializeConnection()
        },
        _ => console.error("Couldn't resolve parameters for signalr chat connection")
      );
  }

  stopConnection() {
    console.log('Stopping chat hub connection');
    this.params = null;
    this.hubConnection.stop();
  }

  ngOnDestroy(): void {
    this.hubConnection.stop();
    this.subs.unsubscribe();
  }

  initializeConnection(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.appSettings.chatHubUrl)
      .build();

    this.hubConnection.serverTimeoutInMilliseconds = 100000; // 100 sec
    this.hubConnection
      .start()
      .then(() => {
        this.initializeListeners();
      })
      .catch(err => console.log(`Error while starting SignalR connection: ${err}`));
  }

  initializeListeners(): void {
    this.hubConnection.on("messageReceived", (friend: IChatParticipant, message: Message) => {
      this.messagesSubject.next({ friend, message });
    });

    this.hubConnection.on("friendsListChanged", () => {
      // Handle the received response to chat
      this.listFriends();
    });
  }

  listFriends(): Observable<ParticipantResponse[]> {
    // List connected users to show in the friends list
    return this.http
      .get('chat/GetFriendsList/' + this.params.userId + '/' + this.params.userAccountType)
      .pipe(
        map((res: any) => res),
        catchError((error: any) => throwError(error.error || 'Server error'))
      );
  }

  getMessageHistory(receiverId: string, pagingModel: PagingModel = null): Observable<Message[]> {

    let endpoint = 'GetChatHistoryFull';
    let request: any = {
      userId: this.params.userId,
      receiverId: receiverId
    }

    if (pagingModel) {
      endpoint = 'GetChatHistoryPaged';
      request.page = pagingModel.page;
      request.pageSize = pagingModel.pageSize;
    }

    return this.http
      .post(`chat/${endpoint}`, request)
      .pipe(
        map((res: any) => res),
        catchError((error: any) => throwError(error.error || 'Server error'))
      );
  }

  sendMessage(message: Message): void {
    if (this.hubConnection && this.hubConnection.state == signalR.HubConnectionState.Connected) {
      this.hubConnection.send('sendMessage', message);
    }
  }

  sendOnMessagesSeenEvent(messages: Message[]): void {
    if (this.hubConnection && this.hubConnection.state == signalR.HubConnectionState.Connected)
      this.hubConnection.send("messagesSeen", messages);
  }

}
