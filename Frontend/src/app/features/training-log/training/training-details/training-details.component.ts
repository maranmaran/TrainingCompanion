import { Component, OnInit } from '@angular/core';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedTraining, sessionVolume } from 'src/ngrx/training-log/training2/training.selectors';
import { Training } from 'src/server-models/entities/training.model';

@Component({
  selector: 'app-training-details',
  templateUrl: './training-details.component.html',
  styleUrls: ['./training-details.component.scss']
})
export class TrainingDetailsComponent implements OnInit {

  protected training: Training;
  protected sessionVolume: Observable<number>;

  protected ckEditor = ClassicEditor;
  protected showEditor = false;
  protected ckEditorConfig = {
      toolbar: ['bold', 'link', 'bulletedList', 'undo', 'redo', 'insertTable', 'ImageUpload', 'MediaEmbed']
  };

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    console.log(ClassicEditor.builtinPlugins.map( plugin => plugin.pluginName ));
    this.store.select(selectedTraining).pipe(take(1))
      .subscribe(training => this.training = training);

    this.sessionVolume = this.store.select(sessionVolume);
  }

}
