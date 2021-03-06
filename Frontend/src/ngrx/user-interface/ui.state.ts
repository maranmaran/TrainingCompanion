import { TrainingLogTab, TrainingLogTabGroup1, TrainingLogTabGroup2 } from 'src/app/features/training-log/training-log-home/training-log-home.component';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';

export interface UIState {
    language: string,
    theme: Theme,
    showErrorDialogs: boolean,
    httpRequestLoading: boolean,
    httpErrorMessage: string,
    activeProgressBar: UIProgressBar,
    isMobile: boolean,
    trainingLogTabs: {index: TrainingLogTabGroup1 | TrainingLogTabGroup2, tab: TrainingLogTab},
}

export const initialUIState: UIState = {
    language: "en",
    theme: Theme.Light,
    showErrorDialogs: true,
    httpRequestLoading: false,
    httpErrorMessage: undefined,
    activeProgressBar: UIProgressBar.MainAppScreen,
    isMobile: undefined,
    trainingLogTabs: undefined,
};
