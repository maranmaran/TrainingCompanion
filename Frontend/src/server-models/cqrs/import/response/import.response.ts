import { ValidatonError } from './validation-error.model';

export class ImportResponse {
  success: boolean;
  errors: ValidatonError[];
}



