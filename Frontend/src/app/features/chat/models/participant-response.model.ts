import { IChatParticipant } from "./chat-participant.model";
import { ParticipantMetadata } from "./participant-metadata.model";

export class ParticipantResponse
{
    public participant: IChatParticipant;
    public metadata: ParticipantMetadata;
}
