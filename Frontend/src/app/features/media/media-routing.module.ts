import { MediaHomeComponent } from './media-home/media-home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserVideosComponent } from './media-home/user-videos/user-videos.component';
import { UserImagesComponent } from './media-home/user-images/user-images.component';
import { MediaResolver } from 'src/business/resolvers/media.resolver';
import { MediaType } from 'src/server-models/enums/media-type.enum';

const routes: Routes = [
    { path: '', component: MediaHomeComponent, children: [
        { path: 'videos', resolve: {media: MediaResolver}, data: { type: MediaType.Video}, component: UserVideosComponent }, 
        { path: 'photos', resolve: {media: MediaResolver}, data: { type: MediaType.Image},  component: UserImagesComponent },
    ]},
    { path: '**', redirectTo: '/' }, //always last
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ],
    providers: [
    ]
})
export class MediaRoutingModule {
}
