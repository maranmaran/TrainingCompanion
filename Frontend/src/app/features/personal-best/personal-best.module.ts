import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { AllExerciseTypesResolver } from './../../../business/resolvers/all-exercise-types.resolver';
import { PersonalBestsResolver } from './../../../business/resolvers/personal-bests.resolver';
import { PersonalBestService } from './../../../business/services/feature-services/personal-best.service';
import { PersonalBestEffects } from './../../../ngrx/personal-best/personal-best.effects';
import { personalBestReducer } from './../../../ngrx/personal-best/personal-best.reducers';
import { PersonalBestCreateEditComponent } from './personal-best-home/personal-best-create-edit/personal-best-create-edit.component';
import { PersonalBestHomeComponent } from './personal-best-home/personal-best-home.component';
import { PersonalBestListComponent } from './personal-best-home/personal-best-list/personal-best-list.component';
import { PersonalBestRoutingModule } from './personal-best-routing.module';

@NgModule({
    imports: [
        SharedModule,
        PersonalBestRoutingModule,
        StoreModule.forFeature('personalBest', personalBestReducer),
        EffectsModule.forFeature([PersonalBestEffects]),
        FormsModule
    ],
    declarations: [
        PersonalBestHomeComponent,
        PersonalBestListComponent,
        PersonalBestCreateEditComponent,
    ],
    exports: [
      PersonalBestListComponent,
      PersonalBestCreateEditComponent,
    ],
    providers: [
        // UIService,
        PersonalBestService,
        AllExerciseTypesResolver,
        PersonalBestsResolver
    ],
    entryComponents: [
    ]
})
export class PersonalBestModule { }
