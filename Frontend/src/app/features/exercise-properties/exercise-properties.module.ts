import { ExercisePropertyTypeService } from './../../../business/services/exercise-property-type.service';
import { ExercisePropertyTypesResolver } from './../../../business/resolvers/exercise-property-types.resolver';
import { ExercisePropertiesHomeComponent } from './exercise-properties-home/exercise-properties-home.component';
import { UIService } from 'src/business/services/shared/ui.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { StoreModule } from '@ngrx/store';
import { exercisePropertyTypeReducer } from 'src/ngrx/exercise-property-management/exercise-property-type/exercise-property-type.reducers';
import { EffectsModule } from '@ngrx/effects';
import { ExercisePropertiesRoutingModule } from './exercise-properties-routing.module';
import { ExercisePropertyTypeEffects } from 'src/ngrx/exercise-property-management/exercise-property-type/exercise-property-type.effects';
import { NgModule } from '@angular/core';
import { TypesListComponent } from './exercise-properties-home/types-list/types-list.component';

@NgModule({
    imports: [
        SharedModule,
        ExercisePropertiesRoutingModule,
        StoreModule.forFeature('exercisePropertyType', exercisePropertyTypeReducer),
        EffectsModule.forFeature([ExercisePropertyTypeEffects])
    ],
    declarations: [
        ExercisePropertiesHomeComponent,
        TypesListComponent,
    ],
    exports: [
    ],
    providers: [
        UIService,
        ExercisePropertyTypeService,
        ExercisePropertyTypesResolver,
    ],
    entryComponents: [
    ]
})
export class ExercisePropertiesModule { }
