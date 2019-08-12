import { CalendarEvent } from './../../../shared/event-calendar/models/event-calendar.models';
import { Component, OnInit } from '@angular/core';
import * as moment from 'moment'

@Component({
  selector: 'app-training-calendar',
  templateUrl: './training-calendar.component.html',
  styleUrls: ['./training-calendar.component.scss']
})
export class TrainingCalendarComponent implements OnInit {

  inputData: CalendarEvent[] = [
    {day: moment(new Date()), event: 'event1'},
    {day: moment(new Date()).add(1, 'day'), event: 'event2'},
    {day: moment(new Date()).subtract(1, 'day'), event: 'event3'},
  ] 

  constructor() { }

  ngOnInit() {
  }

}
