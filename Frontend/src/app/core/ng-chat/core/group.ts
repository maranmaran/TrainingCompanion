import { Guid } from "guid-typescript";
import { IChatParticipant } from "./chat-participant";
import { ChatParticipantStatus } from "./chat-participant-status.enum";
import { ChatParticipantType } from "./chat-participant-type.enum";
import { User } from "./user";

export class Group implements IChatParticipant
{
    constructor(participants: User[])
    {
        this.chattingTo = participants;
        this.status = ChatParticipantStatus.Online;

        // TODO: Add some customization for this in future releases
        this.displayName = participants.map((p) => p.displayName).sort((first, second) => second > first ? -1 : 1).join(", ");
    }

    public id: string = Guid.create().toString();
    public chattingTo: User[];

    public readonly participantType: ChatParticipantType = ChatParticipantType.Group;

    public status: ChatParticipantStatus;
    public avatar: string | null;
    public displayName: string;
}
