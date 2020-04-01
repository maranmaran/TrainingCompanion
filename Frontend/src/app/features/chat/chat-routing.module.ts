import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatFullscreenComponent } from './components/chat-fullscreen/chat-fullscreen.component';

const routes: Routes = [
    { path: '', component: ChatFullscreenComponent, resolve: { }},
    // { path: 'friends', component: FriendListComponent, resolve: { }},
    // { path: 'messages', component: ChatBodyRouteComponent, resolve: { }},
    { path: '**', redirectTo: '/' }, //always last
];

@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ],
    providers: [
    ]
})
export class ChatRoutingModule {
}
