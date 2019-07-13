import { ChatHomeComponent } from './chat-home/chat-home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    { path: '', component: ChatHomeComponent },
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
export class ChatRoutingModule {
}
