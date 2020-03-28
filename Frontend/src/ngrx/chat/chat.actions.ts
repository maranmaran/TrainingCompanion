import { createAction, props } from '@ngrx/store';
import { IChatParticipant } from './../../app/features/chat/models/chat-participant.model';
import { ParticipantResponse } from './../../app/features/chat/models/participant-response.model';

export const friendsFetched = createAction('[Chat] Friends fetched', props<{response: ParticipantResponse[]}>());
export const setFullscreenChatActive = createAction('[Chat] Set fullscreen chat active state', props<{active: boolean}>());
export const setSelectedFriend = createAction('[Chat] Friend selected', props<{friend: IChatParticipant}>());
