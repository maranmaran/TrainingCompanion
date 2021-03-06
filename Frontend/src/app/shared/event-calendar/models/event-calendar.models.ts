import * as moment from 'moment';

export class CalendarMonth {
  weeks: CalendarWeek[] = []
}

export class CalendarWeek {
  days: CalendarDay[];

  constructor(days: moment.Moment[]) {
    this.days = days.map(day => new CalendarDay(day));
  }

}

export class CalendarDay {
  day: moment.Moment;
  events: any[];

  constructor(day: moment.Moment) {
    this.day = day;
    this.events = [];
  }
}

export class CalendarEvent {
  day: moment.Moment;
  event: any;

  constructor(day: moment.Moment) {
    this.day = day;
  }
}
