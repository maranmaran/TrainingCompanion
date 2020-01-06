import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { ImportService } from 'src/business/services/feature-services/import.service';
import { AppState } from 'src/ngrx/app/app.state';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { ImportTrainingRequest } from 'src/server-models/cqrs/import/request/import.request';
import { ImportResponse } from 'src/server-models/cqrs/import/response/import.response';

@Component({
  selector: 'app-training-import',
  templateUrl: './training-import.component.html',
  styleUrls: ['./training-import.component.scss']
})
export class TrainingImportComponent implements OnInit {
  _userId: string;

  constructor(
    private store: Store<AppState>,
    private importService: ImportService
  ) { }

  ngOnInit() {
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this._userId = id);
  }

  import(file: File) {
    var request = new ImportTrainingRequest(this._userId, file);
    this.importService.importTraining(request)
      .subscribe(
        (response: ImportResponse) => console.log(response),
        err => console.log(err)
      );
  }

}
