import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { ReplaySubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { CalendarConfig } from 'src/app/shared/event-calendar/models/calendar.config';
import { CalendarEvent } from 'src/app/shared/event-calendar/models/event-calendar.models';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { AppState } from 'src/ngrx/app/app.state';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { setSelectedTraining, trainingCreated, trainingsFetched } from 'src/ngrx/training-log/training/training.actions';
import { trainings } from 'src/ngrx/training-log/training/training.selectors';
import { CreateTrainingRequest } from 'src/server-models/cqrs/training/create-training.request';
import { Training } from 'src/server-models/entities/training.model';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-training-week',
  templateUrl: './training-week.component.html',
  styleUrls: ['./training-week.component.scss']
})
export class TrainingWeekComponent implements OnInit {

  private subsink = new SubSink();
  private userId: string;

  config: CalendarConfig;
  inputData = new ReplaySubject<CalendarEvent[]>();

  constructor(
    private trainingService: TrainingService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {

    this.config = this.getConfig();

    // current user id for request
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);

    // INIT - (fetch for today)
    setTimeout(() => {
      this.onWeekChange(moment(new Date()));
    });

    // subscribe to changes
    this.subsink.add(
      this.store.select(trainings)
        .subscribe((trainings: Training[]) => this.inputData.next(this.parseTrainingsForCalendar(trainings))
    ));

  }

  getConfig(): CalendarConfig {
    const config = new CalendarConfig();
    config.eventIcon = 'fas fa-dumbbell'
    config.useComponent = true;
    // config.component = TrainingWeekViewDayComponent;
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

  onWeekChange(date: moment.Moment) {

    this.trainingService.getAllByWeek(this.userId, date.startOf('week').toDate(), date.endOf('week').toDate()).pipe(take(1))
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
    // request.dateTrained = day.utc().format();
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
