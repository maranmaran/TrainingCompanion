import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { BehaviorSubject, Observable } from 'rxjs';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { AppState } from 'src/ngrx/app/app.state';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { ImportExerciseTypeRequest } from 'src/server-models/cqrs/import/request/import.request';
import { ImportService } from './../../../../../../business/services/feature-services/import.service';
import { ImportResponse } from './../../../../../../server-models/cqrs/import/response/import.response';

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

  ngOnInit() {
  }


  public get isUploadingObs() : Observable<{uploading: boolean, response: ImportResponse}> {
    return this._isUploading.asObservable()
  }

  _isUploading = new BehaviorSubject<{uploading: boolean, response: ImportResponse}>({uploading: false, response: null});

  import = (file: File, userId: string) => {

    this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.None }))
    this._isUploading.next({uploading: true, response: null});

    var request = new ImportExerciseTypeRequest(userId, file);
    this.importService.importExerciseType(request)
      .subscribe(
        (response: ImportResponse) => {
          console.log(response);
          this._isUploading.next({uploading: false, response})
        },
        err => {
          console.log(err);
          this._isUploading.next({uploading: false, response: null})
        },
        () => this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.MainAppScreen }))
      );
  }

}
