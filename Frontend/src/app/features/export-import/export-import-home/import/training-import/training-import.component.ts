import { Component, OnInit } from '@angular/core';
import { ImportService } from 'src/business/services/feature-services/import.service';
import { ImportTrainingRequest } from 'src/server-models/cqrs/import/request/import.request';

@Component({
  selector: 'app-training-import',
  templateUrl: './training-import.component.html',
  styleUrls: ['./training-import.component.scss']
})
export class TrainingImportComponent implements OnInit {

  constructor(
    private importService: ImportService
  ) { }

  ngOnInit() {
  }

  import() {
    var request = this.getRequest();
    this.importService.importTraining(request);
  }

  getRequest() {
    return new ImportTrainingRequest();
  }

}
