import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { CurrentUserStore } from 'src/business/stores/current-user.store';
import { environment } from 'src/environments/environment';
import { SubSink } from 'subsink';
import { AuthService } from '../services/auth.service';
import { ChatAdapter } from 'src/app/core/ng-chat/core/chat-adapter';
import { ParticipantResponse } from 'src/app/core/ng-chat/core/participant-response';
import { Message } from 'src/app/core/ng-chat/core/message';

Injectable()
export class SignalrNgChatAdapter extends ChatAdapter implements OnDestroy {

  public userId: string;
  private hubConnection: signalR.HubConnection;
  private subs = new SubSink();

  constructor(
    private authService: AuthService,
    private currentUserStore: CurrentUserStore,
    private http: HttpClient) {
    super();

    this.subs.add(this.authService.signOutEvent.subscribe(
      () => this.stopConnection()
    ));

    this.userId = this.currentUserStore.state.id;
    this.initializeConnection();
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  private initializeConnection(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.chatHubUrl)
      .build();

    this.hubConnection.serverTimeoutInMilliseconds = 100000; // 100 sec
    this.hubConnection
      .start()
      .then(() => {
        //this.joinRoom();

        this.initializeListeners();
      })
      .catch(err => console.log(`Error while starting SignalR connection: ${err}`));
  }

  private initializeListeners(): void {
    this.hubConnection.on("generatedUserId", (userId) => {
      // With the userId set the chat will be rendered
      this.userId = userId;
    });

    this.hubConnection.on("messageReceived", (participant, message) => {
      // Handle the received message to ng-chat
      this.onMessageReceived(participant, message);
    });

    this.hubConnection.on("friendsListChanged", () => {
      // Handle the received response to ng-chat
      this.listFriends();
    });
  }

  // joinRoom(): void {
  //   if (this.hubConnection && this.hubConnection.state == signalR.HubConnectionState.Connected) {
  //     this.hubConnection.send("join", this.userId);
  //   }
  // }

  listFriends(): Observable<ParticipantResponse[]> {
    // List connected users to show in the friends list
    // Sending the userId from the request body as this is just a demo 
    return this.http
      .get('/chat/GetFriendsList/' + this.userId)
      .pipe(
        map((res: any) => res),
        catchError((error: any) => throwError(error.error || 'Server error'))
      );
  }

  getMessageHistory(destinataryId: any): Observable<Message[]> {
    // This could be an API call to your web application that would go to the database
    // and retrieve a N amount of history messages between the users.
    return this.http
      .get('/chat/GetChatHistory/' + this.userId + "/" + destinataryId)
      .pipe(
        map((res: any) => res),
        catchError((error: any) => throwError(error.error || 'Server error'))
      );
  }

  sendMessage(message: Message): void {
    if (this.hubConnection && this.hubConnection.state == signalR.HubConnectionState.Connected)
      this.hubConnection.send("sendMessage", message);
  }

  public stopConnection() {
    this.hubConnection.stop();
  }

  public sendOnMessagesSeenEvent(messages: Message[]): void {
    if (this.hubConnection && this.hubConnection.state == signalR.HubConnectionState.Connected)
      this.hubConnection.send("messagesSeen", messages);
  }
}
