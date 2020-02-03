import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { ReplaySubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { CalendarConfig } from 'src/app/shared/event-calendar/models/calendar.config';
import { CalendarEvent } from 'src/app/shared/event-calendar/models/event-calendar.models';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTraining, trainingCreated, trainingsFetched } from 'src/ngrx/training-log/training/training.actions';
import { trainings } from 'src/ngrx/training-log/training/training.selectors';
import { CreateTrainingRequest } from 'src/server-models/cqrs/training/requests/create-training.request';
import { Training } from 'src/server-models/entities/training.model';
import { SubSink } from 'subsink';
import { TrainingMonthViewDayComponent } from './training-month-view-day/training-month-view-day.component';

@Component({
  selector: 'app-training-month',
  templateUrl: './training-month.component.html',
  styleUrls: ['./training-month.component.scss']
})
export class TrainingMonthComponent implements OnInit, OnDestroy {

  protected inputData = new ReplaySubject<CalendarEvent[]>();
  private userId: string;
  private subsink = new SubSink();
  protected calendarConfig: CalendarConfig;

  constructor(
    private trainingService: TrainingService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {

    this.calendarConfig = this.getConfig();

    // current user id for request
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);

    // INIT - (fetch for today)
    setTimeout(() => {
      this.onMonthChange(moment(new Date()));
    });

    // subscribe to changes
    this.subsink.add(this.store.select(trainings).subscribe(
      (trainings: Training[]) => {
        this.inputData.next(this.parseTrainingsForCalendar(trainings));
      }
    ));

  }

  getConfig(): CalendarConfig {
    const config = new CalendarConfig();
    config.eventIcon = 'fas fa-dumbbell'
    config.useComponent = true;
    config.component = TrainingMonthViewDayComponent;
    config.componentInputs = (calendarEventModel: CalendarEvent) => {
      return {
         training: calendarEventModel.event
        }
    }

    return config;
  }

  ngOnDestroy() {
    this.subsink.unsubscribe();
  }

  // GET BY MONTH
  // TODO: Fetch only if you need to.. (Something has been updated.. no need to refetch data that you already loaded)
  onMonthChange(date: moment.Moment) {

    const month = date.month() + 1; // because it starts from 0
    const year = date.year();

    this.trainingService.getAllByMonth(this.userId, month, year).pipe(take(1))
      .subscribe((trainings: Training[]) => {
        this.store.dispatch(trainingsFetched({ entities: trainings }));

        this.inputData.next(this.parseTrainingsForCalendar(trainings));
        // this.store.dispatch(normalizeTrainings({entities: trainings, action: CRUD.Read}))
      });
  }

  // PARSE TO CALENDAR DATA (EVENT CALENDAR CAN READ THIS)
  parseTrainingsForCalendar(trainings: Training[]): CalendarEvent[] {

    if (!trainings) { return []; }

    const events = trainings.map(training => {
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
        (training: Training) => this.store.dispatch(trainingCreated({ entity: training })),
        err => console.log(err)
      );
  }

  onOpenEvent(trainingEvent: CalendarEvent) {
    const training = trainingEvent.event;
    this.store.dispatch(setSelectedTraining({ entity: training }));
  }

}
