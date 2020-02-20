import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { MaterialElevationDirective } from 'src/business/directives/elevation.directive';
import { MediaResolver } from 'src/business/resolvers/media.resolver';
import { MediaEffects } from 'src/ngrx/media/media.effects';
import { mediaReducer } from 'src/ngrx/media/media.reducers';
import { MediaService } from '../../../business/services/feature-services/media.service';
import { MediaHomeComponent } from './media-home/media-home.component';
import { UserImagesComponent } from './media-home/user-images/user-images.component';
import { UserVideosComponent } from './media-home/user-videos/user-videos.component';
import { MediaRoutingModule } from './media-routing.module';


@NgModule({
    imports: [
        SharedModule,
        MediaRoutingModule,
        StoreModule.forFeature('media', mediaReducer),
        EffectsModule.forFeature([MediaEffects])
    ],
    declarations: [
        MediaHomeComponent,
        UserVideosComponent,
        UserImagesComponent,
        MaterialElevationDirective
    ],
    exports: [
    ],
    providers: [
        MediaService,
        MediaResolver
    ],
    entryComponents: [
    ]
})
export class MediaModule { }
