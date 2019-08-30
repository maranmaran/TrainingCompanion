import { Exercise } from 'src/server-models/entities/exercise.model';
import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { selectedTraining, selectedExercise } from 'src/ngrx/training/training.selectors';
import { Training } from 'src/server-models/entities/training.model';
import { setSelectedTraining } from 'src/ngrx/training/training.actions';
import { FormControl } from '@angular/forms';
import { MatTabGroup, MatTabChangeEvent, MatTab } from '@angular/material/tabs';

@Component({
  selector: 'app-training-log-home',
  templateUrl: './training-log-home.component.html',
  styleUrls: ['./training-log-home.component.scss']
})
export class TrainingLogHomeComponent implements OnInit, OnDestroy {

  @ViewChild('group1', {static: true}) tabGroup1: MatTabGroup;
  @ViewChild('group2', {static: true}) tabGroup2: MatTabGroup;

  private subsink = new SubSink();
  protected selectedTraining: Training;
  protected selectedExercise: Exercise;

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.subsink.add(
      this.store.select(selectedTraining).subscribe(
        (training: Training) => {
          this.selectedTraining = training;
          training && this.changeTab1(TrainingCalendarTab1.TrainingDetails); // TRAINING DETAILS
      }),
      this.store.select(selectedExercise).subscribe(
        (exercise: Exercise) => {
          this.selectedExercise = exercise;
          exercise && this.changeTab1(TrainingCalendarTab1.ExerciseDetails); // EXERCISE DETAILS
        }
      )
    );
  }

  ngOnDestroy() {
    this.subsink.unsubscribe();
  }
  
  changeTab1(index: number) {
    this.selectedTab1 = index;

    // bug when transitioning from display: none to inherit
    // group must be visible for inkbar to adjust
    setTimeout(() => this.tabGroup1.realignInkBar()); 

    switch(index) {
      case TrainingCalendarTab1.List:
        return this.goBackToList();
      case TrainingCalendarTab1.TrainingDetails:
        break;
      case TrainingCalendarTab1.ExerciseDetails:
        break;
      default:
        throw new Error("No tab index like this");
    }
  }
  changeTab2(index: number) {    
    this.selectedTab2 = index;

    // bug when transitioning from display: none to inherit
    // group must be visible for inkbar to adjust
    setTimeout(() => this.tabGroup2.realignInkBar()); 

    switch(index) {
      case TrainingCalendarTab2.Calendar:
        break;
      case TrainingCalendarTab2.Week:
        break;
      case TrainingCalendarTab2.List:
        break;
      default:
        throw new Error("No tab index like this");
    }
  }

  selectedTab1 = TrainingCalendarTab1.TrainingDetails; 
  selectedTab2 = TrainingCalendarTab2.Calendar; 
  
  public get hideTab1() : boolean { // if training is NOT selected
    return !this.selectedTraining;
  }
  public get hideTab2() : boolean { // if training selected
    return !this.hideTab1;
  }

  public get showCalendar() : boolean { // if calendar and NO training
    return this.selectedTab2 == TrainingCalendarTab2.Calendar && !this.hideTab2;
  }
  public get showWeek() : boolean { // if week list and NO training
    return this.selectedTab2 == TrainingCalendarTab2.Week && !this.hideTab2;;
  }
  public get showList() : boolean { // if list and NO training
    return this.selectedTab2 == TrainingCalendarTab2.List && !this.hideTab2;;
  }

  public get showTraining() : boolean { // training details and NO training
    return this.selectedTab1 == TrainingCalendarTab1.TrainingDetails && !this.hideTab1;
  }
  public get showExercise() : boolean { // exercise detailsa nd NO training
    return this.selectedTab1 == TrainingCalendarTab1.ExerciseDetails && !this.hideTab1;
  }

  goBackToList() {
    this.store.dispatch(setSelectedTraining(null));
    this.changeTab2(TrainingCalendarTab2.Calendar);
  }
  
}

export enum TrainingCalendarTab1 {
  List = 0,
  TrainingDetails = 1,
  ExerciseDetails = 2
}

export enum TrainingCalendarTab2 {
  Calendar = 0,
  Week = 1,
  List = 2
}
