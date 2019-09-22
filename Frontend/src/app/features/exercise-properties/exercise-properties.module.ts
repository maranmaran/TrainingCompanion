import { TagService } from 'src/business/services/feature-services/tag.service';
import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { ColorPickerModule } from 'ngx-color-picker';
import { SharedModule } from 'src/app/shared/shared.module';
import { UIService } from 'src/business/services/shared/ui.service';
import { TagGroupService } from '../../../business/services/feature-services/tag-group.service';
import { TagGroupsResolver } from './../../../business/resolvers/tag-groups.resolver';
import { ExercisePropertiesHomeComponent } from './exercise-properties-home/exercise-properties-home.component';
import { TagsCreateEditComponent } from './exercise-properties-home/properties/properties-create-edit/properties-create-edit.component';
import { PropertiesListComponent } from './exercise-properties-home/properties/properties-list/properties-list.component';
import { PropertyDetailsComponent } from './exercise-properties-home/properties/property-details/property-details.component';
import { TypeDetailsComponent } from './exercise-properties-home/types/type-details/type-details.component';
import { TypesCreateEditComponent } from './exercise-properties-home/types/types-create-edit/types-create-edit.component';
import { TypesListComponent } from './exercise-properties-home/types/types-list/types-list.component';
import { ExercisePropertiesRoutingModule } from './exercise-properties-routing.module';
import { EffectsModule } from '@ngrx/effects';
import { TagGroupEffects } from 'src/ngrx/tag-group/tag-group.effects';
import { tagGroupReducer } from 'src/ngrx/tag-group/tag-group.reducers';
import { TagEffects } from 'src/ngrx/tag/tag.effects';

@NgModule({
    imports: [
        SharedModule,
        ExercisePropertiesRoutingModule,
        StoreModule.forFeature('tagGroup', tagGroupReducer),
        EffectsModule.forFeature([TagGroupEffects, TagEffects]),
        ColorPickerModule
    ],
    declarations: [
        ExercisePropertiesHomeComponent,
        TypesListComponent,
        PropertiesListComponent,
        TypeDetailsComponent,
        PropertyDetailsComponent,
        TagsCreateEditComponent,
        TypesCreateEditComponent
    ],
    exports: [
    ],
    providers: [
        UIService,
        TagGroupService,
        TagService,
        TagGroupsResolver,
    ],
    entryComponents: [
        TypesCreateEditComponent,
        TagsCreateEditComponent
    ]
})
export class ExercisePropertiesModule { }
