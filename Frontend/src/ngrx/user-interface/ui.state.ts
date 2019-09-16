import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { TrainingLogTabGroup1, TrainingLogTabGroup2, TrainingLogTab } from 'src/app/features/training-log/training-log-home/training-log-home.component';

export interface UIState {
    theme: Theme,
    showErrorDialogs: boolean,
    httpRequestLoading: boolean,
    httpErrorMessage: string,
    activeProgressBar: UIProgressBar,
    isMobile: boolean,
    trainingLogTabs: {index: TrainingLogTabGroup1 | TrainingLogTabGroup2, tab: TrainingLogTab}
}

export const initialUIState: UIState = {
    theme: Theme.Light,
    showErrorDialogs: true,
    httpRequestLoading: false,
    httpErrorMessage: undefined,
    activeProgressBar: UIProgressBar.MainAppScreen,
    isMobile: undefined,
    trainingLogTabs: undefined
};
