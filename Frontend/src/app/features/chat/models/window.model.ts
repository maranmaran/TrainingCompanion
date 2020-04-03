import { Guid } from 'guid-typescript';
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
        this.historyPage = 0;
    }

    public id: string;
    public participant: IChatParticipant;
    public messages: Message[] = [];
    public newMessage?: string = "";

    // UI Behavior properties
    public isCollapsed?: boolean = false;
    public isLoadingHistory: boolean = false;
    public hasFocus: boolean = false;
    public hasMoreMessages: boolean = true;
    public historyPage: number = 0;
}
