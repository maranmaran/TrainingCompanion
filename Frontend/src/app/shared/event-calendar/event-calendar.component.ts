import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import * as moment from 'moment'
import { EventCalendar, CalendarEvent, CalendarDay } from './models/event-calendar.models';
import { getEventCalendarModel, belongsToThisMonth, populateCalendar } from './models/event.calendar.utils';
import { Observable } from 'rxjs';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-event-calendar',
  templateUrl: './event-calendar.component.html',
  styleUrls: ['./event-calendar.component.scss']
})
export class EventCalendarComponent implements OnInit {

  calendar = new EventCalendar();
  currentDay = moment(new Date());

  @Output() selectDayEvent = new EventEmitter<CalendarDay>();
  @Output() previousMonthEvent = new EventEmitter<number>();
  @Output() currentMonthEvent = new EventEmitter<number>();
  @Output() nextMonthEvent = new EventEmitter<number>();

  @Input() events$: Observable<CalendarEvent[]>;
  @Input() eventIcon: string = '';

  private subsink = new SubSink();

  constructor() { }

  ngOnInit() {
    this.calendar = getEventCalendarModel(this.currentDay);
    
    this.subsink.add(
      this.events$.subscribe(
        events => {
          console.log(events);
          this.calendar = populateCalendar(this.calendar, events);
        }
      )
    );
  }

  nextMonth() {
    this.currentDay = this.currentDay.clone().add(1, 'month');
    this.calendar = getEventCalendarModel(this.currentDay);

    this.currentMonthEvent.emit(this.currentDay.month());
  }

  previousMonth() {
    this.currentDay = this.currentDay.clone().subtract(1, 'month');
    this.calendar = getEventCalendarModel(this.currentDay);

    this.currentMonthEvent.emit(this.currentDay.month());
  }

  currentMonth() {
    this.currentDay = moment(new Date());
    this.calendar = getEventCalendarModel(this.currentDay);

    this.currentMonthEvent.emit(this.currentDay.month());
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

