import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { BodyweightsResolver } from 'src/business/resolvers/bodyweights.resolver';
import { BodyweightService } from 'src/business/services/feature-services/bodyweight.service';
import { BodyweightEffects } from 'src/ngrx/bodyweight/bodyweight.effects';
import { bodyweightReducer } from './../../../ngrx/bodyweight/bodyweight.reducers';
import { BodyweightHomeComponent } from './bodyweight-home/bodyweight-home.component';
import { BodyweightRoutingModule } from './bodyweight-routing.module';

@NgModule({
    imports: [
        SharedModule,
        BodyweightRoutingModule,
        StoreModule.forFeature('bodyweights', bodyweightReducer),
        EffectsModule.forFeature([BodyweightEffects]),
        FormsModule
    ],
    declarations: [
        BodyweightHomeComponent,
    ],
    exports: [
    ],
    providers: [
        BodyweightService,
        BodyweightsResolver,
    ],
    entryComponents: [
    ]
})
export class BodyweightModule { }
