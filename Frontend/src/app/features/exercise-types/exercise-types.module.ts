import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { UIService } from 'src/business/services/shared/ui.service';
import { ExerciseTypesRoutingModule } from './exercise-types-routing.module';
import { exerciseTypeReducer } from 'src/ngrx/exercise-type/exercise-type.reducers';
import { ExerciseTypeEffects } from 'src/ngrx/exercise-type/exercise-type.effects';
import { ExerciseTypesHomeComponent } from './exercise-types-home/exercise-types-home.component';
import { ExerciseTypeService } from 'src/business/services/exercise-type.service';
import { ExerciseTypesResolver } from 'src/business/resolvers/exercise-types.resolver';
import { ExerciseTypeListComponent } from './exercise-types-home/exercise-type-list/exercise-type-list.component';

@NgModule({
    imports: [
        SharedModule,
        ExerciseTypesRoutingModule,
        StoreModule.forFeature('exerciseType', exerciseTypeReducer),
        EffectsModule.forFeature([ExerciseTypeEffects])
    ],
    declarations: [
        ExerciseTypesHomeComponent,
        ExerciseTypeListComponent,
    ],
    exports: [
    ],
    providers: [
        UIService,
        ExerciseTypeService,
        ExerciseTypesResolver,
    ],
    entryComponents: [
    ]
})
export class ExerciseTypesModule { }
