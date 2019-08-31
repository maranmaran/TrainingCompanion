import { Component, OnInit, Output, EventEmitter, Input, HostListener, OnDestroy } from '@angular/core';
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
export class EventCalendarComponent implements OnInit, OnDestroy {

  calendar = new EventCalendar();
  currentDay = moment(new Date());

  @Output() selectDayEvent = new EventEmitter<CalendarDay>();
  @Output() previousMonthEvent = new EventEmitter<moment.Moment>();
  @Output() currentMonthEvent = new EventEmitter<moment.Moment>();
  @Output() nextMonthEvent = new EventEmitter<moment.Moment>();

  @Output() addEvent = new EventEmitter<moment.Moment>();
  @Output() openEvent = new EventEmitter<any>();

  @Input() events$: Observable<CalendarEvent[]>;
  @Input() eventIcon: string = '';

  private subsink = new SubSink();

  constructor() { }

  ngOnInit() {
    this.calendar = getEventCalendarModel(this.currentDay);
    
    this.subsink.add(
      this.events$.subscribe(
        events => {
          this.calendar = populateCalendar(this.calendar, events);
        }
      )
    );
  }

  ngOnDestroy(): void {
    this.subsink.unsubscribe();    
  }

  @HostListener('document:keydown.ArrowLeft', ['$event']) keyLeft = () => this.previousMonth();
  @HostListener('document:keydown.ArrowRight', ['$event']) keyRight = () => this.nextMonth();
  @HostListener('document:keydown.Space', ['$event']) keySpace = () => this.currentMonth();

  nextMonth() {
    this.currentDay = this.currentDay.clone().add(1, 'month');
    this.calendar = getEventCalendarModel(this.currentDay);

    this.currentMonthEvent.emit(this.currentDay);
  }

  previousMonth() {
    this.currentDay = this.currentDay.clone().subtract(1, 'month');
    this.calendar = getEventCalendarModel(this.currentDay);

    this.currentMonthEvent.emit(this.currentDay);
  }

  currentMonth() {
    this.currentDay = moment(new Date());
    this.calendar = getEventCalendarModel(this.currentDay);

    this.currentMonthEvent.emit(this.currentDay);
  }

  selectDay(day: CalendarDay) {
    this.selectDayEvent.emit(day);
  }

  add(day: moment.Moment) {
    this.addEvent.emit(day);
  }

  open(event: any) {
    this.openEvent.emit(event);
  }

  displayDateDay = (date: moment.Moment) => date.format('D');
  displayMonthAndYear = (date: moment.Moment) => date.format('MMMM, M/YY');
  
  belongsToThisMonth = belongsToThisMonth;
  isSunday = (date: moment.Moment) => moment(date).weekday() == 0;
  isToday = (date: moment.Moment) => moment(date).isSame(new Date(), 'day');
  
}

