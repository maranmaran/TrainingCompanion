import { Component, OnInit } from '@angular/core';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/internal/Observable';
import { map, switchMap, take } from 'rxjs/operators';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { selectedExerciseType } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UpdateExerciseTypeRequest } from 'src/server-models/cqrs/exercise-type/update-exercise-type.request';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { exerciseTypeUpdated } from './../../../../../ngrx/exercise-type/exercise-type.actions';

@Component({
  selector: 'app-exercise-type-details',
  templateUrl: './exercise-type-details.component.html',
  styleUrls: ['./exercise-type-details.component.scss'],
})
export class ExerciseTypeDetailsComponent implements OnInit {

  exerciseType$: Observable<ExerciseType>

  constructor(
    private store: Store<AppState>,
    private exerciseTypeService: ExerciseTypeService,
  ) { }

  ngOnInit() {
    this.exerciseType$ = this.store.select(selectedExerciseType);
  }

  onSetActive(value: boolean) {

    this.exerciseType$.pipe(take(1),
      map(entity => Object.assign({}, entity)),
      switchMap(entity => {
        entity.active = value;
        return this.exerciseTypeService.update(new UpdateExerciseTypeRequest({ exerciseType: entity }));
      },
        entity => entity
      ),
    ).subscribe(
      entity => {
        let updateStatement: Update<ExerciseType> = {
          id: entity.id,
          changes: { active: entity.active }
        }
        this.store.dispatch(exerciseTypeUpdated({ entity: updateStatement }));
      },
      err => console.log(err)
    )
  }

}
