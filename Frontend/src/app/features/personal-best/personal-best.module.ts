import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { PersonalBestService } from './../../../business/services/feature-services/personal-best.service';
import { PersonalBestEffects } from './../../../ngrx/personal-best/personal-best.effects';
import { personalBestReducer } from './../../../ngrx/personal-best/personal-best.reducers';
import { PersonalBestHomeComponent } from './personal-best-home/personal-best-home.component';
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
    ],
    exports: [
    ],
    providers: [
        // UIService,
        PersonalBestService,
        // PersonalBestResolver,
    ],
    entryComponents: [
    ]
})
export class PersonalBestModule { }
