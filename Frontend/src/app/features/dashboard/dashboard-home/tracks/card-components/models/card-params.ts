import * as moment from 'moment';
import { Theme } from 'src/business/shared/theme.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { ExerciseType } from '../../../../../../../server-models/entities/exercise-type.model';
import { CardDateSpan } from './card-date-span';
// carries all data for dashboard cards 

export class CardParameters {

  constructor(jsonParams: string) {

    if (!jsonParams)
      return; // default

    const params = JSON.parse(jsonParams);

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



    Object.assign(this, params);
  }

  dateSpanType?: CardDateSpan;
  dateFrom: Date = moment(new Date()).subtract(1, 'month').toDate();
  dateTo: Date = new Date();

  exerciseTypeIds: string[]; // server
  exerciseTypes: ExerciseType[]; // objects found by id (fresh from server)

  settings: CardSettings = new CardSettings(Theme.Light, UnitSystem.Metric, false);

  addExerciseType(type) {
    this.exerciseTypes = !this.exerciseTypes ? [type] : [...this.exerciseTypes, type];
    this.exerciseTypeIds = !this.exerciseTypeIds ? [type.id] : [...this.exerciseTypeIds, type.id];
  }
}

export class CardSettings {

  constructor(theme, unitSystem, mobile) {
    this.theme = theme;
    this.unitSystem = unitSystem;
    this.mobile = mobile;
  }

  theme: Theme;
  unitSystem: UnitSystem;
  mobile: boolean;
}