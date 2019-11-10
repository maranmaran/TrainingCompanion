import { Theme } from 'src/business/shared/theme.enum';
import { RpeSystem } from '../enums/rpe-system.enum';
import { UnitSystem } from '../enums/unit-system.enum';
import { NotificationSetting } from './notification-setting.model';

export class UserSetting {
    id: string;
    theme: Theme;
    unitSystem: UnitSystem;
    useRpeSystem: boolean;
    rpeSystem: RpeSystem;
    notificationSettings: NotificationSetting[];
}


