import { CalendarWeek, EventCalendar } from './event-calendar.models';
import * as moment from 'moment'
import { format } from 'src/business/utils/moment.format';

export function getEventCalendarModel(today: moment.Moment): EventCalendar {

    const eventCalendar = new EventCalendar();
    
    const startDay = getStartDayOfMonth(today);
    const endDay = getEndDayOfMonth(today);
    
    // THIS IS REMOVED BECAUSE IT DOESN'T RESPECT ORDER OF DAYS... SUNDAYS CAN BE ON EITHER COLUMN
    // more than 5 weeks - reduce to 35 days so we can get 5 weeks in calendar
    // const differenceInDays = endDay.diff(startDay, 'days', false);
    // const daysInCalendarWanted = 35;
    
    // if(differenceInDays > daysInCalendarWanted) {
      
    //   var valuesToRemove = differenceInDays - daysInCalendarWanted;
      
    //   // remove excess days
    //   while(valuesToRemove > 0) {
        
    //     if(!belongsToThisMonth(startDay, today)) {
    //       startDay.add(1, 'day');
    //       valuesToRemove -= 1;
    //     } else {
    //       if(!belongsToThisMonth(endDay, today)) {
    //         endDay.subtract(1,'day');
    //         valuesToRemove -= 1;
    //       }
    //     }
        
    //   }
    // }
    
    const date = startDay.clone(); // this is +1 because of sundays
    while (date.isBefore(endDay, 'day')) {

      eventCalendar.weeks.push(
          new CalendarWeek( Array(7).fill(0).map(() => date.add(1, 'day').clone().utc() ))
        )
    }

    return eventCalendar;
  }

  
export const getStartDayOfMonth = (date: moment.Moment) => date.clone().startOf('month').startOf('week');
export const getEndDayOfMonth = (date: moment.Moment) => date.clone().endOf('month').endOf('week');

export const isBefore = (date: moment.Moment, dateToCompareTo: moment.Moment) => dateToCompareTo.isBefore(date, 'date');
export const isEqual = (date: moment.Moment, dateToCompareTo: moment.Moment) =>  dateToCompareTo.isSame(date, 'date');
export const isAfter = (date: moment.Moment, dateToCompareTo: moment.Moment) => dateToCompareTo.isAfter(date, 'date');

export const belongsToThisMonth = (date: moment.Moment, currentDate: moment.Moment) => moment(date).isSame(currentDate, 'month')
