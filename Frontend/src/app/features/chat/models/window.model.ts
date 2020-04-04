import { Guid } from 'guid-typescript';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { IChatParticipant } from './chat-participant.model';
import { Message } from './message.model';

export class Window
{
    constructor(participant: IChatParticipant, isLoadingHistory: boolean, isCollapsed: boolean)
    {
        this.id = Guid.create().toString();
        this.participant = participant;
        this.messages =  [];
        this.isLoadingHistory = isLoadingHistory;
        this.hasFocus = false; // This will be triggered when the 'newMessage' input gets the current focus
        this.isCollapsed = isCollapsed;
        this.hasMoreMessages = false;
        this.pagingModel = new PagingModel({pageSize: 20});
    }

    id: string;
    participant: IChatParticipant;
    messages: Message[] = [];
    newMessage?: string = "";

    // UI Behavior properties
    isCollapsed?: boolean = false;
    isLoadingHistory: boolean = false;
    hasFocus: boolean = false;
    hasMoreMessages: boolean = true;
    pagingModel: PagingModel;

    reset() {
      this.pagingModel = new PagingModel({pageSize: 20});
    }
}
