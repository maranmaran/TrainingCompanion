import * as moment from 'moment';
import { CalendarEvent, CalendarMonth, CalendarWeek } from './event-calendar.models';

export function getMonthViewModel(today: moment.Moment): CalendarMonth {

  const eventCalendar = new CalendarMonth();

  const startDay = getStartDayOfMonth(today);
  const endDay = getEndDayOfMonth(today);

  const date = startDay.clone().add(1, 'day') // this is +1 because of sundays
  while (date.isBefore(endDay, 'day')) {

    eventCalendar.weeks.push(
      new CalendarWeek(
        Array(7).fill(0).map( () => date.add(1, 'day').clone().utc() )
      )
    )
  }

  return eventCalendar;
}

export function getWeekViewModel(today: moment.Moment): CalendarWeek {

  const startDay = getStartDayOfWeek(today);
  const endDay = getEndDayOfWeek(today).add(1, 'day');

  let days = [];
  const date = startDay.clone(); // this is +1 because of sundays
  while (!isEqual(date, endDay)) {
    days.push(date.add(1, 'day').clone().utc());
  }

  return new CalendarWeek(days);
}

export function populateMonthViewModel(model: CalendarMonth, events: CalendarEvent[]) {

  if(!events) return model;

  model.weeks.forEach(calWeek => populateWeekViewModel(calWeek, events));
}

export function populateWeekViewModel(model: CalendarWeek, events: CalendarEvent[]) {
  if(!events) return model;

  model.days.forEach((calDay, i) => {
    let calEvents = events.filter(x => isEqual(x.day, calDay.day));
    model.days[i].events = [...calEvents]; // ordering of sorted items..
  });
}

export const getStartDayOfMonth = (date: moment.Moment) => date.clone().startOf('month').startOf('week');
export const getEndDayOfMonth = (date: moment.Moment) => date.clone().endOf('month').endOf('week');

export const getStartDayOfWeek = (date: moment.Moment) => date.clone().startOf('week');
export const getEndDayOfWeek = (date: moment.Moment) => date.clone().endOf('week');

export const isBefore = (date: moment.Moment, dateToCompareTo: moment.Moment) => dateToCompareTo.isBefore(date, 'date');
export const isEqual = (date: moment.Moment, dateToCompareTo: moment.Moment) => dateToCompareTo.isSame(date, 'date');
export const isAfter = (date: moment.Moment, dateToCompareTo: moment.Moment) => dateToCompareTo.isAfter(date, 'date');

export const belongsToThisMonth = (date: moment.Moment, currentDate: moment.Moment) => moment(date).isSame(currentDate, 'month')
export const belongsToThisWeek = (date: moment.Moment, currentDate: moment.Moment) => moment(date).isSame(currentDate, 'week')
