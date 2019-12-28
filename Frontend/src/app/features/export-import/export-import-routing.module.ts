import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExportImportHomeComponent } from './export-import-home/export-import-home.component';

const routes: Routes = [
    { path: '', component: ExportImportHomeComponent, resolve: {ExportImportResolver}, children: [
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
export class ExportImportRoutingModule {
}
