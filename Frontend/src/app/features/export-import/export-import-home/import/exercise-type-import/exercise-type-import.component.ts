import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { map } from 'rxjs/operators';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { activeImportJobs } from 'src/ngrx/export-import/export-import.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { ImportExerciseTypeRequest } from 'src/server-models/cqrs/import/import.request';
import { ImportEntities } from 'src/server-models/enums/import-entities.enum';
import { ImportService } from './../../../../../../business/services/feature-services/import.service';
import { lastImportResponse } from './../../../../../../ngrx/export-import/export-import.selectors';

@Component({
  selector: 'app-exercise-type-import',
  templateUrl: './exercise-type-import.component.html',
  styleUrls: ['./exercise-type-import.component.scss']
})
export class ExerciseTypeImportComponent implements OnInit, OnDestroy {

  constructor(
    private store: Store<AppState>,
    private importService: ImportService
  ) { }

  isUploading$ = combineLatest(
    this.store.select(activeImportJobs).pipe(map(getJobsFn => getJobsFn(ImportEntities.ExerciseTypes).length > 0 ? true : false)),
    this.store.select(lastImportResponse)
  ).pipe(
    map(([uploading, response]) => ({uploading, response}))
  )


  ngOnInit() {
    this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.None }))
  }

  ngOnDestroy() {
    this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.MainAppScreen }))
  }

  import = (file: File, userId: string) => {
    var request = new ImportExerciseTypeRequest(userId, file);
    this.importService.importExerciseType(request);
  }

}
