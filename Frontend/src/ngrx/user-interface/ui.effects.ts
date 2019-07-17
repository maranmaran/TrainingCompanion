import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions } from '@ngrx/effects';


@Injectable()
export class UIEffects {

    constructor(
        private actions$: Actions,
        private router: Router,
    ) { }

    // login$ = createEffect(() =>
    //     this.actions$
    //         .pipe(
    //             ofType(AuthActions.login),
    //             tap((currentUser: CurrentUser) => {
    //                 localStorage.setItem('id', currentUser.id);
    //                 this.router.navigate(['/']);
    //             })
    //         )
    //     , { dispatch: false });

  

}
