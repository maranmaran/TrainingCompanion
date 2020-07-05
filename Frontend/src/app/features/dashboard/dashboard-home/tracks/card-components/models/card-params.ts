import * as moment from 'moment';
import { ExerciseType } from '../../../../../../../server-models/entities/exercise-type.model';
import { CardDateSpan } from './card-date-span';
// carries all data for dashboard cards 

export class CardParameters {

  constructor(jsonParams: string, setSpan: boolean) {

    if (!jsonParams)
      return; // default

    const params = JSON.parse(jsonParams);

    if (setSpan) {

      if (moment(params.dateTo).diff(moment(params.dateFrom), 'days') == 7) {
        params.dateSpanType = CardDateSpan.Week;
      }
      else {
        switch (moment(params.dateTo).diff(moment(params.dateFrom), 'months')) {
          case 1:
            params.dateSpanType = CardDateSpan.Month;
            break;
          case 3:
            params.dateSpanType = CardDateSpan.ThreeMonths;
            break;
          case 5:
            params.dateSpanType = CardDateSpan.FiveMonths;
            break;
          default:
            throw new Error("No date span found");
        }
      }

    }

    Object.assign(this, params);
  }

  dateSpanType?: CardDateSpan;
  dateFrom: Date = moment(new Date()).subtract(1, 'month').toDate();
  dateTo: Date = new Date();
  exerciseType: ExerciseType;

}
