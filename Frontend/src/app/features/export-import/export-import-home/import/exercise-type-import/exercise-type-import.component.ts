import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { ImportExerciseTypeRequest } from 'src/server-models/cqrs/import/request/import.request';
import { ImportService } from './../../../../../../business/services/feature-services/import.service';
import { currentUserId } from './../../../../../../ngrx/auth/auth.selectors';
import { AppState } from './../../../../../../ngrx/global-setup.ngrx';
import { ImportResponse } from './../../../../../../server-models/cqrs/import/response/import.response';

@Component({
  selector: 'app-exercise-type-import',
  templateUrl: './exercise-type-import.component.html',
  styleUrls: ['./exercise-type-import.component.scss']
})
export class ExerciseTypeImportComponent implements OnInit {

  _userId: string;

  constructor(
    private store: Store<AppState>,
    private importService: ImportService
  ) { }

  ngOnInit() {
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this._userId = id);
  }

  import(file: File) {
    var request = new ImportExerciseTypeRequest(this._userId, file);
    this.importService.importExerciseType(request)
      .subscribe(
        (response: ImportResponse) => console.log(response),
        err => console.log(err)
      );
  }

}
