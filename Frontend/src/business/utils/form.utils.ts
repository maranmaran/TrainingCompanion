import { UIService } from '../services/shared/ui.service';
import { FormGroup } from '@angular/forms';
import { genericErrorMessage } from './messages.utils';

export const validateForm = (form: FormGroup, UIService: UIService) => {

  if(form.invalid) {
    UIService.fadeOutMessage(genericErrorMessage());
    return false;
  }

  return true;
}
