import { IChatParticipant } from "./chat-participant.model";
import { ChatParticipantStatus } from "./enums/chat-participant-status.enum";
import { ChatParticipantType } from "./enums/chat-participant-type.enum";

export class User implements IChatParticipant
{
    public readonly participantType: ChatParticipantType = ChatParticipantType.User;
    public id: any;
    public displayName: string;
    public status: ChatParticipantStatus;
    public avatar: string;
}
