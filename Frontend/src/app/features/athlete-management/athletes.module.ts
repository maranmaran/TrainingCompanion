import { HttpBackend } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { AthleteManagementHttpLoaderFactory } from 'src/assets/i18n/translation-http-loader.factory';
import { UIService } from 'src/business/services/shared/ui.service';
import { athletesReducer } from 'src/ngrx/athletes/athlete.reducers';
import { AthletesResolver } from '../../../business/resolvers/athletes.resolver';
import { AthletesEffects } from '../../../ngrx/athletes/athlete.effects';
import { AthleteCreateEditComponent } from './athletes-home/athlete-create-edit/athlete-create-edit.component';
import { AthleteDetailsComponent } from './athletes-home/athlete-details/athlete-details.component';
import { AthleteListComponent } from './athletes-home/athlete-list/athlete-list.component';
import { AthletesHomeComponent } from './athletes-home/athletes-home.component';
import { AthletesRoutingModule } from './athletes-routing.module';


@NgModule({
    imports: [
        SharedModule,
        AthletesRoutingModule,
        StoreModule.forFeature('athletes', athletesReducer),
        EffectsModule.forFeature([AthletesEffects]),
        // lazy loaded modules import of translate module
        // https://github.com/ngx-translate/core#1-import-the-translatemodule
        TranslateModule.forChild({
          isolate: true,
          loader: {
            provide: TranslateLoader,
            useFactory: AthleteManagementHttpLoaderFactory,
            deps: [HttpBackend]
          }
        })
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
