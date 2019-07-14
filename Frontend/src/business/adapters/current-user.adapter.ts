import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { Injectable } from '@angular/core';
import { plainToClass } from "class-transformer";
import { IBaseAdapter } from './base.adapter.interface';

@Injectable({
    providedIn: 'root'
})
export class CurrentUserAdapter implements IBaseAdapter<CurrentUser> {

    adaptToModel(plainObject: Object): CurrentUser {
        return plainToClass(CurrentUser, plainObject);
    }

}