import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import * as moment from 'moment'
import { EventCalendar } from './models/event-calendar.models';
import { getEventCalendarModel, belongsToThisMonth } from './models/event.calendar.utils';

@Component({
  selector: 'app-event-calendar',
  templateUrl: './event-calendar.component.html',
  styleUrls: ['./event-calendar.component.scss']
})
export class EventCalendarComponent implements OnInit {

  calendar = new EventCalendar();
  currentDay = moment(new Date());

  @Output() addEvent = new EventEmitter<moment.Moment>();

  constructor() { }

  ngOnInit() {
    this.calendar = getEventCalendarModel(this.currentDay);     
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

  selectDay(day: moment.Moment) {
    console.log(day);
    console.log(this.isSunday(day));
    this.addEvent.emit(day);
  }

  displayDateDay = (date: moment.Moment) => date.format('D');
  displayMonthAndYear = (date: moment.Moment) => date.format('MMMM, YY');
  
  belongsToThisMonth = belongsToThisMonth;
  isSunday = (date: moment.Moment) => moment(date).weekday() == 0;
  isToday = (date: moment.Moment) => moment(date).isSame(new Date(), 'day');
  
}

