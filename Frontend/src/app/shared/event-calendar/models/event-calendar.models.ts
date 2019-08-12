import * as moment from 'moment'

export class EventCalendar {
    weeks: CalendarWeek[] = []
  }
  
  export class CalendarWeek {
    days: moment.Moment[]

    constructor(days: moment.Moment[]) {
      this.days = days;
    }

    
  }