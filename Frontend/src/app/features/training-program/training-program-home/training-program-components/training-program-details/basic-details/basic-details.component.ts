import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { getPlaceholderImagePath } from 'src/business/utils/utils';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-basic-details',
  templateUrl: './basic-details.component.html',
  styleUrls: ['./basic-details.component.scss']
})
export class BasicDetailsComponent implements OnInit, OnDestroy {

  @Input() trainingProgram: TrainingProgram;

  placeholderImagePath: string;
  showAll = false;

  subs = new SubSink();

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    this.subs.add(
      this.store.select(activeTheme).subscribe(theme => this.placeholderImagePath = getPlaceholderImagePath(theme))
    )
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }


}
