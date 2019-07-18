export enum Theme {
    Dark = 'Dark',
    Light = 'Light'
}

export const themeLightClass = 'theme-light';
export const themeDarkClass = 'theme-dark';

export function getThemeClass(theme: Theme) {
    switch (theme)
    {
        case Theme.Dark:
            return themeDarkClass;
        case Theme.Light:
            return themeLightClass;
        default:
            throw new Error('Theme is not supported');
    }
}