import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import * as moment from 'moment'
import { EventCalendar, CalendarEvent, CalendarDay } from './models/event-calendar.models';
import { getEventCalendarModel, belongsToThisMonth, populateCalendar } from './models/event.calendar.utils';

@Component({
  selector: 'app-event-calendar',
  templateUrl: './event-calendar.component.html',
  styleUrls: ['./event-calendar.component.scss']
})
export class EventCalendarComponent implements OnInit {

  calendar = new EventCalendar();
  currentDay = moment(new Date());

  @Output() selectDayEvent = new EventEmitter<CalendarDay>();

  @Input() events: CalendarEvent[];
  @Input() eventIcon: string = '';

  constructor() { }

  ngOnInit() {
    this.calendar = getEventCalendarModel(this.currentDay);     
    this.calendar = populateCalendar(this.calendar, this.events);     
  }


  nextMonth() {
    this.currentDay = this.currentDay.clone().add(1, 'month');
    this.calendar = getEventCalendarModel(this.currentDay);
  }

  previousMonth() {
    this.currentDay = this.currentDay.clone().subtract(1, 'month');
    this.calendar = getEventCalendarModel(this.currentDay);
  }

  currentMonth() {
    this.currentDay = moment(new Date());
    this.calendar = getEventCalendarModel(this.currentDay);
  }

  selectDay(day: CalendarDay) {
    this.selectDayEvent.emit(day);
  }

  displayDateDay = (date: moment.Moment) => date.format('D');
  displayMonthAndYear = (date: moment.Moment) => date.format('MMMM, YY');
  
  belongsToThisMonth = belongsToThisMonth;
  isSunday = (date: moment.Moment) => moment(date).weekday() == 0;
  isToday = (date: moment.Moment) => moment(date).isSame(new Date(), 'day');
  
}

