import { Component, OnInit } from '@angular/core';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ReportService } from 'src/business/services/feature-services/report.service';

@Component({
  selector: 'app-max-card',
  templateUrl: './max-card.component.html',
  providers: [ExerciseTypeService, ReportService,
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] }]
})
export class MaxCardComponent implements OnInit {

  constructor(

  ) { }

  ngOnInit() {

  }


}
