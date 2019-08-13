import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { athletesReducer } from 'src/ngrx/athletes/athlete.reducers';
import { AthletesResolver } from '../../../business/resolvers/athletes.resolver';
import { AthletesEffects } from '../../../ngrx/athletes/athlete.effects';
import { AthleteDetailsComponent } from './athletes-home/athlete-details/athlete-details.component';
import { AthletesHomeComponent } from './athletes-home/athletes-home.component';
import { AthleteListComponent } from './athletes-home/athlete-list/athlete-list.component';
import { AthletesRoutingModule } from './athletes-routing.module';
import { AthleteCreateEditComponent } from './athletes-home/athlete-create-edit/athlete-create-edit.component';
import { UIService } from 'src/business/services/shared/ui.service';


@NgModule({
    imports: [
        SharedModule,
        AthletesRoutingModule,
        StoreModule.forFeature('athletes', athletesReducer),
        EffectsModule.forFeature([AthletesEffects])
    ],
    declarations: [
        AthletesHomeComponent,
        AthleteListComponent,
        AthleteDetailsComponent,
        AthleteCreateEditComponent
    ],
    exports: [
    ],
    providers: [
        UIService,
        AthletesResolver
    ],
    entryComponents: [
        AthleteCreateEditComponent,
    ]
})
export class AthletesModule { }
