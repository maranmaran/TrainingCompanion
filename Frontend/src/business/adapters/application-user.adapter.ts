// import { IBaseAdapter } from './base.adapter.interface';
// import {plainToClass} from "class-transformer";
// import { Injectable } from '@angular/core';
// import { ApplicationUser } from 'src/server-models/entities/application-user.model';

// @Injectable({
//     providedIn: 'root'
// })
// export class ApplicationUserAdapter implements IBaseAdapter<ApplicationUser> {

//     adaptToModel(plainObject: Object): ApplicationUser {
//         return plainToClass(ApplicationUser, plainObject);
//     }

//     adaptToList(plainObjectList: Object[]) {
//         return plainToClass(ApplicationUser, plainObjectList);
//     }

// }