import { CalendarWeek, EventCalendar, CalendarEvent } from './event-calendar.models';
import * as moment from 'moment'
import { format } from 'src/business/utils/moment.format';

export function getEventCalendarModel(today: moment.Moment): EventCalendar {

  const eventCalendar = new EventCalendar();

  const startDay = getStartDayOfMonth(today);
  const endDay = getEndDayOfMonth(today);

  const date = startDay.clone().add(1, 'day') // this is +1 because of sundays
  while (date.isBefore(endDay, 'day')) {

    eventCalendar.weeks.push(
      new CalendarWeek(Array(7).fill(0).map(() => date.add(1, 'day').clone().utc()))
    )
  }

  return eventCalendar;
}

export function populateCalendar(calendar: EventCalendar, events: CalendarEvent[]) {
  if(!events) return calendar;

  calendar.weeks.forEach((calWeek, i) => {
    calWeek.days.forEach((calDay, j) => {
      let calEvent = events.find(x => isEqual(x.day, calDay.day));
      if(calEvent) calendar.weeks[i].days[j].event = calEvent;
    });
  });

  return calendar;
}


export const getStartDayOfMonth = (date: moment.Moment) => date.clone().startOf('month').startOf('week');
export const getEndDayOfMonth = (date: moment.Moment) => date.clone().endOf('month').endOf('week');

export const isBefore = (date: moment.Moment, dateToCompareTo: moment.Moment) => dateToCompareTo.isBefore(date, 'date');
export const isEqual = (date: moment.Moment, dateToCompareTo: moment.Moment) => dateToCompareTo.isSame(date, 'date');
export const isAfter = (date: moment.Moment, dateToCompareTo: moment.Moment) => dateToCompareTo.isAfter(date, 'date');

export const belongsToThisMonth = (date: moment.Moment, currentDate: moment.Moment) => moment(date).isSame(currentDate, 'month')
