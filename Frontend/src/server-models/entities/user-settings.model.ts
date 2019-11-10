import { Theme } from 'src/business/shared/theme.enum';
import { RpeSystem } from '../enums/rpe-system.enum';
import { UnitSystem } from '../enums/unit-system.enum';

export class UserSetting {
    id: string;
    theme: Theme;
    unitSystem: UnitSystem;
    useRpeSystem: boolean;
    rpeSystem: RpeSystem;
}


