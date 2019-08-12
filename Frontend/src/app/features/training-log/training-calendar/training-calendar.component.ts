import { CalendarEvent } from './../../../shared/event-calendar/models/event-calendar.models';
import { Component, OnInit } from '@angular/core';
import * as moment from 'moment'
import { Subject } from 'rxjs/internal/Subject';
import { timeout } from 'q';

@Component({
  selector: 'app-training-calendar',
  templateUrl: './training-calendar.component.html',
  styleUrls: ['./training-calendar.component.scss']
})
export class TrainingCalendarComponent implements OnInit {

  month1: CalendarEvent[] = [
    {day: moment(new Date()).subtract(1, 'month'), event: 'event1'},
    {day: moment(new Date()).subtract(1, 'month').add(1, 'day'), event: 'event2'},
    {day: moment(new Date()).subtract(1, 'month').subtract(1, 'day'), event: 'event3'},
  ] 
  month2: CalendarEvent[] = [
    {day: moment(new Date()), event: 'event1'},
    {day: moment(new Date()).add(1, 'day'), event: 'event2'},
    {day: moment(new Date()).subtract(1, 'day'), event: 'event3'},
  ] 
  month3: CalendarEvent[] = [
    {day: moment(new Date()).add(1, 'month'), event: 'event1'},
    {day: moment(new Date()).add(1, 'month').add(1, 'day'), event: 'event2'},
    {day: moment(new Date()).add(1, 'month').subtract(1, 'day'), event: 'event3'},
  ] 

  inputData = new Subject<CalendarEvent[]>();

  constructor() { }

  ngOnInit() {
    setTimeout(() => {
      this.onMonthChange(moment(new Date()).month());
    });
  }

  onMonthChange(month: number) {
    if(month == 7) {
      this.inputData.next(this.month2);
    }
    if(month > 7) {
      this.inputData.next(this.month3);
    }
    if(month < 7) {
      this.inputData.next(this.month1);
    }
  }

}
