import { Theme } from 'src/app/core/ng-chat/core/theme.enum';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CurrentUserStore } from './../../stores/current-user.store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Store } from '@ngrx/store';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { take } from 'rxjs/operators';

@Injectable({ providedIn: 'root'})
export class ThemeService {

    public theme$: BehaviorSubject<string>;

    private themeLight = 'theme-light';
    private themeDark = 'theme-dark';
    private themeLightSelector = 'Light';
    private themeDarkSelector = 'Dark';

    constructor(
        private store: Store<AppState>
    ) {
        this.theme$ = new BehaviorSubject<string>(this.themeLight);
    }


    public resetToDefault() {
        this.theme$.next(this.themeLight);
    }

    public setTheme(theme: string) {
        theme.toLowerCase() === this.themeLightSelector.toLowerCase() && this.theme$.next(this.themeLight);
        theme.toLowerCase() === this.themeDarkSelector.toLowerCase() && this.theme$.next(this.themeDark);
    }

    public setCurrentUserTheme() {
        this.store
            .select(currentUser)
            .pipe(take(1))
            .subscribe(currentUser => this.setTheme(currentUser.userSettings.theme));
    }

    public getChatTheme(theme: string): Theme {
        switch (theme) {
            case this.themeLight:
                return Theme.Light
            case this.themeDark:
                return Theme.Dark;
        }
    }
}