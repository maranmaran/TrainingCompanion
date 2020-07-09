import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { BodyweightsResolver } from 'src/business/resolvers/bodyweights.resolver';
import { BodyweightService } from 'src/business/services/feature-services/bodyweight.service';
import { BodyweightEffects } from 'src/ngrx/bodyweight/bodyweight.effects';
import { UIService } from './../../../business/services/shared/ui.service';
import { bodyweightReducer } from './../../../ngrx/bodyweight/bodyweight.reducers';
import { BodyweightChartComponent } from './bodyweight-home/bodyweight-chart/bodyweight-chart.component';
import { BodyweightCreateEditComponent } from './bodyweight-home/bodyweight-create-edit/bodyweight-create-edit.component';
import { BodyweightHomeComponent } from './bodyweight-home/bodyweight-home.component';
import { BodyweightListComponent } from './bodyweight-home/bodyweight-list/bodyweight-list.component';
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
        BodyweightListComponent,
        BodyweightCreateEditComponent,
        BodyweightChartComponent,
    ],
    exports: [
    ],
    providers: [
        BodyweightService,
        BodyweightsResolver,
        UIService
    ],
    entryComponents: [
        // TODO remove after ~30 days - 09.07.20
        //BodyweightCreateEditComponent
    ]
})
export class BodyweightModule { }
