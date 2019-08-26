import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs/typings';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { selectedTraining } from 'src/ngrx/training/training.selectors';
import { Training } from 'src/server-models/entities/training.model';

@Component({
  selector: 'app-training-log-home',
  templateUrl: './training-log-home.component.html',
  styleUrls: ['./training-log-home.component.scss']
})
export class TrainingLogHomeComponent implements OnInit, AfterViewInit {

  @ViewChild('group1', {static: true}) tabGroup1;
  @ViewChild('group2', {static: true}) tabGroup2;

  private subsink = new SubSink();
  protected selectedTraining: Training;

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.subsink.add(
      this.store.select(selectedTraining).subscribe(
        (training: Training) => {
          if(training) {
            this.selectedTraining = training;
            this.selectTab1(TrainingCalendarTab1.Training); // TRAINING DETAILS
          }
      })
    );
  }
  
  ngAfterViewInit() {
    setTimeout(() => {
      this.selectedTab2 = this.tabGroup2.selectedIndex;
    });
  }
  
  onSelectTab1(tab: MatTabChangeEvent) {
    this.selectedTab1 = tab.index as unknown as TrainingCalendarTab1
  }
  onSelectTab2(tab: MatTabChangeEvent) {
    this.selectedTab2 = tab.index as unknown as TrainingCalendarTab2
  }

  selectTab1(index: TrainingCalendarTab1) {
    this.tabGroup1.selectedIndex = index;
    this.selectedTab1 = index;
  }
  selectTab2(index: TrainingCalendarTab2) {
    this.tabGroup2.selectedIndex = index;
    this.selectedTab2 = index;
  }
  
  selectedTab1: TrainingCalendarTab1; 
  selectedTab2: TrainingCalendarTab2; 

  
  public get hideTab1() : boolean { // if training is NOT selected
    return !this.selectedTraining;
  }
  public get hideTab2() : boolean { // if training selected
    return this.selectedTraining != undefined || this.selectedTraining != null;
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
    return this.selectedTab1 == TrainingCalendarTab1.Training;
  }
  public get showExercise() : boolean { // exercise detailsa nd NO training
    return this.selectedTab1 == TrainingCalendarTab1.Exercise;
  }
  
}

export enum TrainingCalendarTab1 {
  Training = 0,
  Exercise = 1
}

export enum TrainingCalendarTab2 {
  Calendar = 0,
  Week = 1,
  List = 2
}
