import { CreateTrainingRequest } from 'src/server-models/cqrs/training/requests/create-training.request';
import { CalendarEvent } from '../../../../shared/event-calendar/models/event-calendar.models';
import { Component, OnInit, OnDestroy } from '@angular/core';
import * as moment from 'moment'
import { Subject } from 'rxjs/internal/Subject';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Store } from '@ngrx/store';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { take } from 'rxjs/operators';
import { Training } from 'src/server-models/entities/training.model';
import { SubSink } from 'subsink';
import { ReplaySubject } from 'rxjs';
import { allTrainings } from 'src/ngrx/training-log/training/training.selectors';
import { trainingsFetched, trainingCreated, setSelectedTraining, normalizeTrainings } from 'src/ngrx/training-log/training/training.actions';

@Component({
  selector: 'app-training-calendar',
  templateUrl: './training-calendar.component.html',
  styleUrls: ['./training-calendar.component.scss']
})
export class TrainingCalendarComponent implements OnInit, OnDestroy {

  protected inputData = new ReplaySubject<CalendarEvent[]>();
  private userId: string;
  private subsink = new SubSink();

  constructor(
    private trainingService: TrainingService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {

    // current user id for request
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);

    // INIT - (fetch for today)
    setTimeout(() => {
      this.onMonthChange(moment(new Date()));
    });

    // subscribe to changes
    this.subsink.add(this.store.select(allTrainings).subscribe(
      (trainings: Training[]) => {
        this.inputData.next(this.parseTrainingsForCalendar(trainings));
      }
    ));

  }

  ngOnDestroy() {
    this.subsink.unsubscribe();
  }

  // GET BY MONTH
  onMonthChange(date: moment.Moment) {

    const month = date.month() + 1 // because it starts from 0
    const year = date.year();

    this.trainingService.getAllByMonth(this.userId, month, year).pipe(take(1))
      .subscribe((trainings: Training[]) => {
        // this.store.dispatch(trainingsFetched({trainings}));
        this.store.dispatch(normalizeTrainings({trainings}))
      });
  }

  // PARSE TO CALENDAR DATA (EVENT CALENDAR CAN READ THIS)
  parseTrainingsForCalendar(trainings: Training[]): CalendarEvent[] {
    
    if(!trainings) return [];
    
    const events = trainings.map(training =>  {

      const calendarEvent = new CalendarEvent(moment(training.dateTrained));
      calendarEvent.event = training;

      return calendarEvent;
    });

    return events;
  }

  onAddEvent(day: moment.Moment) {
    const request = new CreateTrainingRequest();
    request.dateTrained = day.utc().format();
    request.applicationUserId = this.userId;

    this.trainingService.create(request).pipe(take(1))
      .subscribe(
        (training: Training) => this.store.dispatch(trainingCreated({training})),
        err => console.log(err)
      );
  }

  onOpenEvent(trainingEvent: CalendarEvent) {
    const training = trainingEvent.event;
    this.store.dispatch(setSelectedTraining({training}));
  }

}
