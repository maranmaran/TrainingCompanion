import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatBodyComponent } from './components/chat-fullscreen/chat-body/chat-body.component';
import { ChatFullscreenComponent } from './components/chat-fullscreen/chat-fullscreen.component';
import { FriendListComponent } from './components/chat-fullscreen/friend-list/friend-list.component';

const routes: Routes = [
    { path: '', component: ChatFullscreenComponent, resolve: { }},
    { path: 'friends', component: FriendListComponent, resolve: { }},
    { path: 'messages', component: ChatBodyComponent, resolve: { }},
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
