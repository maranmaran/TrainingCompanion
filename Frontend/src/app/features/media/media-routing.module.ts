import { MediaHomeComponent } from './media-home/media-home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserVideosComponent } from './media-home/user-videos/user-videos.component';
import { UserImagesComponent } from './media-home/user-images/user-images.component';

const routes: Routes = [
    { path: '', component: MediaHomeComponent, children: [
        { path: 'videos', component: UserVideosComponent }, 
        { path: 'photos', component: UserImagesComponent },
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
