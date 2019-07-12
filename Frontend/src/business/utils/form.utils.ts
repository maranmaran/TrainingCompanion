import { NotificationService } from '../services/shared/notification.service';
import { FormGroup } from '@angular/forms';
import { genericErrorMessage } from './messages.utils';

// import { FormGroup } from '@angular/forms';
// import { genericErrorMessage } from './messages.utils';
// import { Injectable } from '@angular/core';
// import { NotificationService } from '../services/shared/notification.service';

// @Injectable()
// export class FormUtils {

//   constructor(
//     private notificationService: NotificationService
//     ) { }

//   public validateForm = (form: FormGroup) => {

//     if(form.invalid) {
//       this.notificationService.fadeOutMessage(genericErrorMessage());
//       return false;
//     }

//     return true;
//   }

// }

export const validateForm = (form: FormGroup, notificationService: NotificationService) => {

  if(form.invalid) {
    this.notificationService.fadeOutMessage(genericErrorMessage());
    return false;
  }

  return true;
}
