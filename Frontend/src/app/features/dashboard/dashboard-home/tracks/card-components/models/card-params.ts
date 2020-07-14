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

    this.dateSpanType = params.dateSpanType;
    this.dateFrom = params.dateFrom;
    this.dateTo = params.dateTo;
    this._exerciseTypeIds = params.exerciseTypeIds;
  }

  dateSpanType: CardDateSpan = CardDateSpan.Week;
  dateFrom: Date = moment(new Date()).subtract(1, 'month').toDate();
  dateTo: Date = new Date();

  _exerciseTypeIds: string[]; // server
  public get exerciseTypeIds(): string[] {
    return this._exerciseTypeIds;
  }

  _exerciseTypes: ExerciseType[]; // objects found by id (fresh from server)
  public get exerciseTypes(): ExerciseType[] {
    return this._exerciseTypes;
  }

  settings: CardSettings = new CardSettings(Theme.Light, UnitSystem.Metric, false);

  setExerciseTypes(exerciseTypes: ExerciseType[]) {
    this._exerciseTypes = exerciseTypes;
  }

  addExerciseType(type) {
    this._exerciseTypes = !this._exerciseTypes ? [type] : [...this._exerciseTypes, type];
    this._exerciseTypeIds = !this._exerciseTypeIds ? [type.id] : [...this._exerciseTypeIds, type.id];
  }

  removeExerciseType(type) {

    // get index of item to remove
    let index = this._exerciseTypes.findIndex(x => x.id == type.id);

    // remove
    this._exerciseTypes.splice(index, 1);
    this._exerciseTypeIds.splice(index, 1);
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