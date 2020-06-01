import { Component, EventEmitter, HostListener, Input, OnInit, Output } from '@angular/core';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import { SubSink } from 'subsink';
import { CalendarConfig } from '../models/calendar.config';
import { CalendarDay, CalendarEvent, CalendarWeek } from '../models/event-calendar.models';
import { belongsToThisWeek, getWeekViewModel, populateWeekViewModel } from '../models/event.calendar.utils';

@Component({
  selector: 'calendar-week-view',
  templateUrl: './week-view.component.html'
})
export class CalendarWeekViewComponent implements OnInit {

  week = new CalendarWeek([]);
  currentDay = moment(new Date());
  hours = [...Array(24).keys()];
  minutes = [...Array(60).keys()];

  @Output('onDaySelect') selectDayEvent = new EventEmitter<CalendarDay>();
  @Output('previousWeek') previousWeekEvent = new EventEmitter<moment.Moment>();
  @Output('currentWeek') currentWeekEvent = new EventEmitter<moment.Moment>();
  @Output('nextWeek') nextWeekEvent = new EventEmitter<moment.Moment>();

  @Output() addEvent = new EventEmitter<moment.Moment>();
  @Output() openEvent = new EventEmitter<any>();

  @Input('events') events$: Observable<CalendarEvent[]>;
  @Input() config: CalendarConfig;

  private subsink = new SubSink();

  constructor() { }

  ngOnInit() {
    this.week = getWeekViewModel(this.currentDay);

    this.subsink.add(
      this.events$.subscribe(events => populateWeekViewModel(this.week, events))
    );
  }

  ngOnDestroy(): void {
    this.subsink.unsubscribe();
  }

  @HostListener('document:keydown.ArrowLeft', ['$event']) keyLeft = () => this.previousWeek();
  @HostListener('document:keydown.ArrowRight', ['$event']) keyRight = () => this.nextWeek();
  @HostListener('document:keydown.Space', ['$event']) keySpace = () => this.currentWeek();

  nextWeek() {
    this.currentDay = this.currentDay.clone().add(1, 'week');
    this.week = getWeekViewModel(this.currentDay);

    this.currentWeekEvent.emit(this.currentDay);
  }

  previousWeek() {
    this.currentDay = this.currentDay.clone().subtract(1, 'week');
    this.week = getWeekViewModel(this.currentDay);

    this.currentWeekEvent.emit(this.currentDay);
  }

  currentWeek() {
    this.currentDay = moment(new Date());
    this.week = getWeekViewModel(this.currentDay);

    this.currentWeekEvent.emit(this.currentDay);
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
  displayWeek = (date: moment.Moment) => `${date.startOf('week').clone().add(1, 'day').format('DD/MM/YY')} - ${date.endOf('week').clone().add(1, 'day').format('DD/MM/YY')}`;

  belongsToThisWeek = belongsToThisWeek;
  isSunday = (date: moment.Moment) => moment(date).weekday() == 0;
  isToday = (date: moment.Moment) => (console.log('today', date), moment(date).isSame(new Date(), 'day'));

}
