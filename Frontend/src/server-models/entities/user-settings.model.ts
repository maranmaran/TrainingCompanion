import { Theme } from 'src/business/models/theme.enum';

export interface UserSettings {
    id: string;
    theme: Theme;
}