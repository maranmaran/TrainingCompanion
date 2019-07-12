import { IBaseAdapter } from './base.adapter.interface';
import {plainToClass} from "class-transformer";
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class CurrentUserAdapter implements IBaseAdapter<CurrentUser> {

    adaptToModel(plainObject: Object): CurrentUser {
        return plainToClass(CurrentUser, plainObject);
    }

}