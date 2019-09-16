import { Exercise } from 'src/server-models/entities/exercise.model';
import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { Training } from 'src/server-models/entities/training.model';
import { MatTabGroup } from '@angular/material/tabs';
import { selectedTraining } from 'src/ngrx/training-log/training/training.selectors';
import { setSelectedTraining } from 'src/ngrx/training-log/training/training.actions';
import { Router } from '@angular/router';
import { selectedExercise } from 'src/ngrx/training-log/exercise/exercise.selectors';
import { setSelectedExercise } from 'src/ngrx/training-log/exercise/exercise.actions';

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
    private router: Router,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.subsink.add(
      this.store.select(selectedTraining).subscribe(
        (training: Training) => {
          this.selectedTraining = training;
          training && this.changeTab1(TrainingLogTabGroup1.TrainingDetails); // TRAINING DETAILS
      }),
      this.store.select(selectedExercise).subscribe(
        (exercise: Exercise) => {
          this.selectedExercise = exercise;
          exercise && this.changeTab1(TrainingLogTabGroup1.ExerciseDetails); // EXERCISE DETAILS
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
      case TrainingLogTabGroup1.List:
        return this.goBackToList();
      case TrainingLogTabGroup1.TrainingDetails:
        this.store.dispatch(setSelectedExercise(null));
        this.router.navigate(['/app/training-log/training-details']);
        break;
      case TrainingLogTabGroup1.ExerciseDetails:
        this.router.navigate(['/app/training-log/exercise-details']);
        break;
      default:
        throw new Error("No tab index like this");
    }
  }
  changeTab2(index: number) {    
    this.selectedTab2 = index;

    this.store.dispatch(setSelectedExercise(null));
    this.store.dispatch(setSelectedTraining(null));

    // bug when transitioning from display: none to inherit
    // group must be visible for inkbar to adjust
    setTimeout(() => this.tabGroup2.realignInkBar()); 

    switch(index) {
      case TrainingLogTabGroup2.Calendar:
        this.router.navigate(['/app/training-log/calendar']);
        break;
      case TrainingLogTabGroup2.Week:
        this.router.navigate(['/app/training-log/week']);
        break;
      case TrainingLogTabGroup2.List:
        this.router.navigate(['/app/training-log/list']);
        break;
      default:
        throw new Error("No tab index like this");
    }
  }

  selectedTab1 = TrainingLogTabGroup1.TrainingDetails; 
  selectedTab2 = TrainingLogTabGroup2.Calendar; 
  
  public get hideTab1() : boolean { // if training is NOT selected
    return !this.selectedTraining && !this.selectedExercise;
  }
  public get hideTab2() : boolean { // if training selected
    return !this.hideTab1;
  }

  public get showCalendar() : boolean { // if calendar and NO training
    return this.selectedTab2 == TrainingLogTabGroup2.Calendar && !this.hideTab2;
  }
  public get showWeek() : boolean { // if week list and NO training
    return this.selectedTab2 == TrainingLogTabGroup2.Week && !this.hideTab2;;
  }
  public get showList() : boolean { // if list and NO training
    return this.selectedTab2 == TrainingLogTabGroup2.List && !this.hideTab2;;
  }

  public get showTraining() : boolean { // training details and NO training
    return this.selectedTab1 == TrainingLogTabGroup1.TrainingDetails && !this.hideTab1;
  }
  public get showExercise() : boolean { // exercise detailsa nd NO training
    return this.selectedTab1 == TrainingLogTabGroup1.ExerciseDetails && !this.hideTab1;
  }

  goBackToList() {
    this.changeTab2(TrainingLogTabGroup2.Calendar);
  }
  
}

export enum TrainingLogTab {
  TabGroup1 = 0,
  TabGroup2 = 0
}

export enum TrainingLogTabGroup1 {
  List = 0,
  TrainingDetails = 1,
  ExerciseDetails = 2
}

export enum TrainingLogTabGroup2 {
  Calendar = 0,
  Week = 1,
  List = 2
}
