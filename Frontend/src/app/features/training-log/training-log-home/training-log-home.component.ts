import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs/typings';

@Component({
  selector: 'app-training-log-home',
  templateUrl: './training-log-home.component.html',
  styleUrls: ['./training-log-home.component.scss']
})
export class TrainingLogHomeComponent implements OnInit, AfterViewInit {

  @ViewChild('group1', {static: true}) tabGroup1;
  @ViewChild('group2', {static: true}) tabGroup2;


  constructor() { }

  ngOnInit() {
  }
  
  ngAfterViewInit() {
    setTimeout(() => {
      this.selectedTab1 = this.tabGroup1.selectedIndex;
      this.selectedTab2 = this.tabGroup2.selectedIndex;
    });
  }
  
  onSelectTab1(tab: MatTabChangeEvent) {
    this.selectedTab1 = tab.index as unknown as 0 | 1
  }
  onSelectTab2(tab: MatTabChangeEvent) {
    this.selectedTab2 = tab.index as unknown as 0 | 1 | 2
  }
  
  selectedTab1: 0 | 1; // Training | Exercise
  selectedTab2: 0 | 1 | 2; //Calendar | Week | List
}
