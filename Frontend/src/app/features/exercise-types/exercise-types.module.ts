import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExerciseTypesResolver } from 'src/business/resolvers/exercise-types.resolver';
import { UIService } from 'src/business/services/shared/ui.service';
import { ExerciseTypeEffects } from 'src/ngrx/exercise-type/exercise-type.effects';
import { exerciseTypeReducer } from 'src/ngrx/exercise-type/exercise-type.reducers';
import { ExerciseTypeDetailsComponent } from './exercise-types-home/exercise-type-details/exercise-type-details.component';
import { ExerciseTypeListComponent } from './exercise-types-home/exercise-type-list/exercise-type-list.component';
import { ExerciseTypesHomeComponent } from './exercise-types-home/exercise-types-home.component';
import { ExerciseTypesRoutingModule } from './exercise-types-routing.module';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ExerciseTypeCreateEditComponent } from './exercise-type-create-edit/exercise-type-create-edit.component';

@NgModule({
    imports: [
        SharedModule,
        ExerciseTypesRoutingModule,
        StoreModule.forFeature('exerciseType', exerciseTypeReducer),
        EffectsModule.forFeature([ExerciseTypeEffects]),
        FormsModule
    ],
    declarations: [
        ExerciseTypesHomeComponent,
        ExerciseTypeListComponent,
        ExerciseTypeDetailsComponent,
        ExerciseTypeCreateEditComponent,
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
