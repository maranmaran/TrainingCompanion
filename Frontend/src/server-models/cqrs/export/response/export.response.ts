import { ValidatonError } from './validation-error.model';

export class ExportResponse {
  success: boolean;
  errors: ValidatonError[];
}
