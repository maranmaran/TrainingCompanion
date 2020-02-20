import { Set } from 'src/server-models/entities/set.model';
export class UpdateManySetsRequest {
    sets: Set[];
    exerciseId: string;
}