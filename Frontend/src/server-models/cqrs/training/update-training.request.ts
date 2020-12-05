
export class UpdateTrainingRequest {
    id: string;
    trainingBlockDayId: string;
    note: string;
    noteRead: boolean;
    dateTrained: Date;

    constructor(data?: Partial<UpdateTrainingRequest>) {
        Object.assign(this, data);
    }
}
