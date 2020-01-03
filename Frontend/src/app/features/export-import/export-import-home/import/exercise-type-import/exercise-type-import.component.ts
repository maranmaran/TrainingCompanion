import { Component, OnInit } from '@angular/core';
import { ImportExerciseTypeRequest } from 'src/server-models/cqrs/import/request/import.request';
import { ImportService } from './../../../../../../business/services/feature-services/import.service';

@Component({
  selector: 'app-exercise-type-import',
  templateUrl: './exercise-type-import.component.html',
  styleUrls: ['./exercise-type-import.component.scss']
})
export class ExerciseTypeImportComponent implements OnInit {

  constructor(
    private importService: ImportService
  ) { }

  ngOnInit() {
  }

  import() {
    var request = this.getRequest();
    this.importService.importExerciseType(request);
  }

  getRequest() {
    return new ImportExerciseTypeRequest();
  }

}
