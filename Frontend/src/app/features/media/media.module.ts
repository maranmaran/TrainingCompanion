import { MediaService } from './../../../business/services/media.service';
import { MediaHomeComponent } from './media-home/media-home.component';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { ChatService } from 'src/business/services/chat.service';
import { MediaRoutingModule } from './media-routing.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { mediaReducer } from 'src/ngrx/media/media.reducers';
import { MediaEffects } from 'src/ngrx/media/media.effects';
import { UserVideosComponent } from './media-home/user-videos/user-videos.component';
import { UserImagesComponent } from './media-home/user-images/user-images.component';
import { MediaUploaderComponent } from './media-uploader/media-uploader.component';
import { MediaResolver } from 'src/business/resolvers/media.resolver';
import { MaterialElevationDirective } from 'src/business/directives/elevation.directive';
import { MediaDialogComponent } from 'src/app/shared/media-dialog/media-dialog.component';


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
        MediaUploaderComponent,
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
