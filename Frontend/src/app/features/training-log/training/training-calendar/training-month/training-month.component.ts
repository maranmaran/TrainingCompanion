import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import * as moment from 'moment';
import { BehaviorSubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { CalendarConfig } from 'src/app/shared/event-calendar/models/calendar.config';
import { CalendarEvent } from 'src/app/shared/event-calendar/models/event-calendar.models';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTraining, trainingsFetched } from 'src/ngrx/training-log/training.actions';
import { trainings } from 'src/ngrx/training-log/training.selectors';
import { Training } from 'src/server-models/entities/training.model';
import { SubSink } from 'subsink';
import { TrainingCreateEditComponent } from '../../training-create-edit/training-create-edit.component';
import { UIService } from './../../../../../../business/services/shared/ui.service';
import { TrainingMonthViewDayComponent } from './training-month-view-day/training-month-view-day.component';

@Component({
  selector: 'app-training-month',
  templateUrl: './training-month.component.html',
  styleUrls: ['./training-month.component.scss']
})
export class TrainingMonthComponent implements OnInit, OnDestroy {

  inputData = new BehaviorSubject<CalendarEvent[]>([]);
  private userId: string;
  private subsink = new SubSink();
  calendarConfig: CalendarConfig;

  constructor(
    private UIService: UIService,
    private trainingService: TrainingService,
    private store: Store<AppState>,
    private translateService: TranslateService
  ) { }

  ngOnInit() {
    setTimeout(() => this.store.dispatch(setSelectedTraining(null))); // undo selected training for certain

    this.calendarConfig = this.getConfig();

    // current user id for request
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);

    // INIT - (fetch for today)
    setTimeout(() => {
      this.onMonthChange(moment(new Date()));
    });

    // subscribe to changes
    this.subsink.add(this.store.select(trainings)
    .subscribe((trainings: Training[]) => this.inputData.next(this.parseTrainingsForCalendar(trainings))));
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
      let date = moment(training.dateTrained);

      const calendarEvent = new CalendarEvent(date);
      calendarEvent.event = training;

      return calendarEvent;
    });

    return events;
  }

  onAddEvent(day: moment.Moment) {

    const dialogRef = this.UIService.openDialogFromComponent(TrainingCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '18rem',
      autoFocus: false,
      data: { title: this.translateService.instant('TRAINING_LOG.ADD_TRAINING_TITLE', { date: day.utc().format("DD, MMM")}), action: CRUD.Create, day, timeOnly: true },
      panelClass: []
    });

    dialogRef.afterClosed().pipe(take(1))
      .subscribe(_ => {});
  }


  onOpenEvent(trainingEvent: CalendarEvent) {
    const training = trainingEvent.event;
    this.store.dispatch(setSelectedTraining({ entity: training }));
  }

}
