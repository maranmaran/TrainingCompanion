import { Theme } from 'src/business/shared/theme.enum';
import { UnitSystem } from '../enums/unit-system.enum';
import { RpeSystem } from '../enums/rpe-system.enum';

export class UserSettings {
    id: string;
    theme: Theme;
    unitSystem: UnitSystem;
    useRpeSystem: boolean;
    rpeSystem: RpeSystem;
}


