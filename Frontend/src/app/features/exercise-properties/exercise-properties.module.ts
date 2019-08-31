import { PropertyDetailsComponent } from './exercise-properties-home/properties/property-details/property-details.component';
import { ExercisePropertyTypeService } from '../../../business/services/feature-services/exercise-property-type.service';
import { ExercisePropertyTypesResolver } from './../../../business/resolvers/exercise-property-types.resolver';
import { ExercisePropertiesHomeComponent } from './exercise-properties-home/exercise-properties-home.component';
import { UIService } from 'src/business/services/shared/ui.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { StoreModule } from '@ngrx/store';
import { exercisePropertyTypeReducer } from 'src/ngrx/exercise-property-type/exercise-property-type.reducers';
import { EffectsModule } from '@ngrx/effects';
import { ExercisePropertiesRoutingModule } from './exercise-properties-routing.module';
import { ExercisePropertyTypeEffects } from 'src/ngrx/exercise-property-type/exercise-property-type.effects';
import { NgModule } from '@angular/core';
import { TypesListComponent } from './exercise-properties-home/types/types-list/types-list.component';
import { PropertiesListComponent } from './exercise-properties-home/properties/properties-list/properties-list.component';
import { TypeDetailsComponent } from './exercise-properties-home/types/type-details/type-details.component';
import { TypesCreateEditComponent } from './exercise-properties-home/types/types-create-edit/types-create-edit.component';
import { PropertiesCreateEditComponent } from './exercise-properties-home/properties/properties-create-edit/properties-create-edit.component';
import { ColorPickerModule } from 'ngx-color-picker';

@NgModule({
    imports: [
        SharedModule,
        ExercisePropertiesRoutingModule,
        StoreModule.forFeature('exercisePropertyType', exercisePropertyTypeReducer),
        EffectsModule.forFeature([ExercisePropertyTypeEffects]),
        ColorPickerModule
    ],
    declarations: [
        ExercisePropertiesHomeComponent,
        TypesListComponent,
        PropertiesListComponent,
        TypeDetailsComponent,
        PropertyDetailsComponent,
        PropertiesCreateEditComponent,
        TypesCreateEditComponent
    ],
    exports: [
    ],
    providers: [
        UIService,
        ExercisePropertyTypeService,
        ExercisePropertyTypesResolver,
    ],
    entryComponents: [
        TypesCreateEditComponent,
        PropertiesCreateEditComponent
    ]
})
export class ExercisePropertiesModule { }
