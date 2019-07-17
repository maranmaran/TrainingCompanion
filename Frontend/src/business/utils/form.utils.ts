import { UIService } from '../services/shared/notification.service';
import { FormGroup } from '@angular/forms';
import { genericErrorMessage } from './messages.utils';

// import { FormGroup } from '@angular/forms';
// import { genericErrorMessage } from './messages.utils';
// import { Injectable } from '@angular/core';
// import { NotificationService } from '../services/shared/notification.service';

// @Injectable()
// export class FormUtils {

//   constructor(
//     private UIService: NotificationService
//     ) { }

//   public validateForm = (form: FormGroup) => {

//     if(form.invalid) {
//       this.UIService.fadeOutMessage(genericErrorMessage());
//       return false;
//     }

//     return true;
//   }

// }

export const validateForm = (form: FormGroup, UIService: UIService) => {

  if(form.invalid) {
    this.UIService.fadeOutMessage(genericErrorMessage());
    return false;
  }

  return true;
}
