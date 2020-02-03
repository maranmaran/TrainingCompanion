import { Component, EventEmitter, HostListener, Input, OnDestroy, OnInit, Output } from '@angular/core';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import { SubSink } from 'subsink';
import { CalendarConfig } from '../models/calendar.config';
import { CalendarDay, CalendarEvent, CalendarMonth } from '../models/event-calendar.models';
import { belongsToThisMonth, getMonthViewModel, populateMonthViewModel } from '../models/event.calendar.utils';

@Component({
  selector: 'calendar-month-view',
  templateUrl: './month-view.component.html'
})
export class CalendarMonthViewComponent implements OnInit, OnDestroy {

  calendar = new CalendarMonth();
  currentDay = moment(new Date());

  @Output() selectDayEvent = new EventEmitter<CalendarDay>();
  @Output() previousMonthEvent = new EventEmitter<moment.Moment>();
  @Output() currentMonthEvent = new EventEmitter<moment.Moment>();
  @Output() nextMonthEvent = new EventEmitter<moment.Moment>();

  @Output() addEvent = new EventEmitter<moment.Moment>();
  @Output() openEvent = new EventEmitter<any>();

  @Input() events$: Observable<CalendarEvent[]>;
  @Input() config: CalendarConfig;

  private subsink = new SubSink();

  constructor() { }

  ngOnInit() {
    this.calendar = getMonthViewModel(this.currentDay);

    this.subsink.add(
      this.events$.subscribe(
        events => {
          populateMonthViewModel(this.calendar, events);
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
    this.calendar = getMonthViewModel(this.currentDay);

    this.currentMonthEvent.emit(this.currentDay);
  }

  previousMonth() {
    this.currentDay = this.currentDay.clone().subtract(1, 'month');
    this.calendar = getMonthViewModel(this.currentDay);

    this.currentMonthEvent.emit(this.currentDay);
  }

  currentMonth() {
    this.currentDay = moment(new Date());
    this.calendar = getMonthViewModel(this.currentDay);

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

