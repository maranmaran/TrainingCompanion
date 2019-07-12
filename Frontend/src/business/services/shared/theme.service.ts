import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CurrentUserStore } from './../../stores/current-user.store';
import { Theme } from 'ng-chat';

@Injectable({ providedIn: 'root'})
export class ThemeService {

    public theme$: BehaviorSubject<string>;

    private themeLight = 'theme-light';
    private themeDark = 'theme-dark';
    private themeLightSelector = 'Light';
    private themeDarkSelector = 'Dark';

    constructor(
        private currentUserStore: CurrentUserStore
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
        this.setTheme(this.currentUserStore.state.userSettings.theme);
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