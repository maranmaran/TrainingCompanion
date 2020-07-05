// Types of options for moving window date spans
import * as moment from 'moment';

export enum CardDateSpan {
  Week,
  Month,
  ThreeMonths,
  FiveMonths
}

// Options to choose from when on dashboard graph - fixed moving window date intervals
// TODO: i18n
export const dateSpansDict = {
  0: { label: 'Last week', dateFrom: moment((new Date())).subtract(1, 'week').toDate() },
  1: { label: 'Last month', dateFrom: moment((new Date())).subtract(1, 'month').toDate() },
  2: { label: 'Last 3 months', dateFrom: moment((new Date())).subtract(3, 'month').toDate() },
  3: { label: 'Last 5 months', dateFrom: moment((new Date())).subtract(5, 'month').toDate() },
}