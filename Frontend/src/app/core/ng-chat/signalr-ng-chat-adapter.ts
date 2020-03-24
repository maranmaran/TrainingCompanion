import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { Store } from '@ngrx/store';
import { Observable, throwError } from 'rxjs';
import { catchError, map, take, tap } from 'rxjs/operators';
import { ChatAdapter } from 'src/app/core/ng-chat/core/chat-adapter';
import { Message } from 'src/app/core/ng-chat/core/message';
import { ParticipantResponse } from 'src/app/core/ng-chat/core/participant-response';
import { environment } from 'src/environments/environment';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { AuthService } from '../../../business/services/feature-services/auth.service';
import { currentUser } from './../../../ngrx/auth/auth.selectors';
import { AccountType } from './../../../server-models/enums/account-type.enum';

@Injectable()
export class SignalrNgChatAdapter extends ChatAdapter implements OnDestroy {

  params: { userId: string; userAccountType: AccountType };

  hubConnection: signalR.HubConnection;
  subs = new SubSink();

  constructor(
    private authService: AuthService,
    private store: Store<AppState>,
    private http: HttpClient) {
    super();
    this.subs.add(this.authService.signOutEvent.subscribe(() => this.stopConnection()));
  }

  init() {
    this.store.select(currentUser)
    .pipe(take(1), map(user => ({ userId: user.id, userAccountType: user.accountType }) ))
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
      .withUrl(environment.chatHubUrl)
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
    this.hubConnection.on("messageReceived", (participant, message) => {
      // Handle the received message to ng-chat
      this.onMessageReceived(participant, message);
    });

    this.hubConnection.on("friendsListChanged", () => {
      // Handle the received response to ng-chat
      this.listFriends();
    });
  }

  listFriends(): Observable<ParticipantResponse[]> {
    // List connected users to show in the friends list
    return this.http
      .get('chat/GetFriendsList/' + this.params.userId + '/' + this.params.userAccountType)
      .pipe(
        tap(res => console.log(res)),
        map((res: any) => res),
        catchError((error: any) => throwError(error.error || 'Server error'))
      );
  }

  getMessageHistory(destinataryId: any): Observable<Message[]> {
    // This could be an API call to your web application that would go to the database
    // and retrieve a N amount of history messages between the users.
    return this.http
      .get('chat/GetChatHistory/' + this.params.userId + "/" + destinataryId)
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
