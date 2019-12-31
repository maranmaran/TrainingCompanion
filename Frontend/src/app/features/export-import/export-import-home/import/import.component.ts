import { ImportTrainingRequest } from './../../../../../server-models/cqrs/import/request/import.request';
import { FormGroup, AbstractControl, Validators, FormControl } from '@angular/forms';
import { ImportEntities } from './../../../../../server-models/enums/import-entities.enum';
import { ImportResponse } from './../../../../../server-models/cqrs/import/response/import.response';
import { Component, OnInit, createPlatformFactory } from '@angular/core';
import { Store } from '@ngrx/store';
import { ImportService } from 'src/business/services/feature-services/import.service';
import { AppState } from 'src/ngrx/app/app.state';
import { UIService } from './../../../../../business/services/shared/ui.service';
import { ImportExerciseTypeRequest, ImportRequest } from 'src/server-models/cqrs/import/request/import.request';
import { TypeofExpr } from '@angular/compiler';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss']
})
export class ImportComponent implements OnInit {

  protected importEntities = ImportEntities;
  protected form: FormGroup;

  constructor(
    private importService: ImportService,
    private store: Store<AppState>,
    private UIService: UIService,
  ) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.form = new FormGroup({
      importType: new FormControl(ImportEntities.Training, Validators.required),
      // importType: new FormControl(ImportEntities.Training, Validators.required),
    });
  }

  import() {
    var requestObj = this.getRequest();
    this.importService.import<ImportRequest, ImportResponse>(requestObj.request, requestObj.entity);
  }

  getRequest() {

    let type = this.form.get('importType');

    switch (type.value) {
      case ImportEntities.Training:
        return { request: new ImportTrainingRequest(), entity: type.value };
      case ImportEntities.ExerciseTypes:
        return { request: new ImportExerciseTypeRequest(), entity: type.value };
      default:
        throw new Error('Unknown import type');
    }
  }

}