import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { AppState } from 'src/ngrx/app/app.state';
import { activeImportJobs } from 'src/ngrx/export-import/export-import.selectors';
import { ImportExerciseTypeRequest } from 'src/server-models/cqrs/import/request/import.request';
import { ImportResponse } from 'src/server-models/cqrs/import/response/import.response';
import { ImportEntities } from 'src/server-models/enums/import-entities.enum';
import { SubSink } from 'subsink';
import { ImportService } from './../../../../../../business/services/feature-services/import.service';
import { lastImportResponse } from './../../../../../../ngrx/export-import/export-import.selectors';
import { ImportJob } from './../../../models/import-job.model';

@Component({
  selector: 'app-exercise-type-import',
  templateUrl: './exercise-type-import.component.html',
  styleUrls: ['./exercise-type-import.component.scss']
})
export class ExerciseTypeImportComponent implements OnInit {

  constructor(
    private store: Store<AppState>,
    private importService: ImportService
  ) { }

  activeImportJob: ImportJob;
  response: ImportResponse;

  private _subs = new SubSink();


  public get isUploading(): Observable<{uploading: boolean, response: ImportResponse}> {
    const obj = { uploading: !!this.activeImportJob, response: this.response };
    return of(obj);
  }


  ngOnInit() {
    this._subs.add(
      this.getActiveJob()
    )
  }

  public getActiveJob() {
    return  this.store
    .select(activeImportJobs)
    .pipe(
      map(fn => fn(ImportEntities.ExerciseTypes))
    ).subscribe(jobs => this.activeImportJob = jobs ? jobs[0] : null);
  }


  public getResponses() {
    return  this.store
    .select(lastImportResponse)
    .subscribe(response => this.response = response);
  }


  import = (file: File, userId: string) => {
    var request = new ImportExerciseTypeRequest(userId, file);
    this.importService.importExerciseType(request);
  }

}
