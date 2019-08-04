import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { SubusersService } from 'src/business/services/subusers.service';
import { subusersReducer } from 'src/ngrx/subusers/subuser.reducers';
import { SubusersResolver } from '../../../business/resolvers/subusers.resolver';
import { SubusersEffects } from '../../../ngrx/subusers/subuser.effects';
import { SubuserDetailsComponent } from './subusers-home/subuser-details/subuser-details.component';
import { SubusersHomeComponent } from './subusers-home/subusers-home.component';
import { SubusersListComponent } from './subusers-home/subusers-list/subusers-list.component';
import { SubusersRoutingModule } from './subusers-routing.module';


@NgModule({
    imports: [
        SharedModule,
        SubusersRoutingModule,
        StoreModule.forFeature('subusers', subusersReducer),
        EffectsModule.forFeature([SubusersEffects])
    ],
    declarations: [
        SubusersHomeComponent,
        SubusersListComponent,
        SubuserDetailsComponent,
    ],
    exports: [
    ],
    providers: [
        SubusersService,
        SubusersResolver
    ],
    entryComponents: [
    ]
})
export class SubusersModule { }
