import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { AthleteCreateEditComponent } from 'src/app/features/athlete-management/athletes-home/athlete-create-edit/athlete-create-edit.component';
import { CRUD } from 'src/business/shared/crud.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExercisePropertyTypeService } from '../../../../../../business/services/feature-services/exercise-property-type.service';
import { ExercisePropertyType } from './../../../../../../server-models/entities/exercise-property-type.model';
import { exercisePropertyTypeUpdated } from 'src/ngrx/exercise-property-type/exercise-property-type.actions';

@Component({
  selector: 'app-types-create-edit',
  templateUrl: './types-create-edit.component.html',
  styleUrls: ['./types-create-edit.component.scss']
})
export class TypesCreateEditComponent implements OnInit {


  constructor(
    private store: Store<AppState>,
    protected dialogRef: MatDialogRef<TypesCreateEditComponent>,
    private exercisePropertyTypeService: ExercisePropertyTypeService,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, action: CRUD, exercisePropertyType: ExercisePropertyType }) { }

  form: FormGroup;
  exercisePropertyType = new ExercisePropertyType();

  ngOnInit() {
    if (this.data.action == CRUD.Update) this.exercisePropertyType = Object.assign({}, this.data.exercisePropertyType);

    this.createForm();
  }

  createForm() {
    this.form = new FormGroup({
      type: new FormControl(this.exercisePropertyType.type, Validators.required),
    });
  }

  get type(): AbstractControl { return this.form.get('type'); }
  
  onActiveChange(event: MatSlideToggleChange) {
    if (event.checked) this.exercisePropertyType.active = true;
    if (!event.checked) this.exercisePropertyType.active = false;
  }

  onSubmit() {
    if (this.data.action == CRUD.Create) {
      this.createType();
    } else {
      this.updateType();
    }
  }

  onClose(propertyType?: ExercisePropertyType) {
    this.dialogRef.close(propertyType);
  }

  handleError(validationErrors: ValidationErrors) {
    // if (validationErrors.status && validationErrors.status == ServerStatusCodes.ValidationError) {


    //   if(validationErrors.errors.username) {
    //     this.username.setErrors(validationErrors.errors.username)
    //   }

    //   if(validationErrors.errors.email) {
    //     this.email.setErrors(validationErrors.errors.email)
    //   }

    // }
  }

  createType() {
    // var request = new CreateUserRequest();
    // request.coachId = this.coachId;
    // request.firstname = this.fullName.value.split(' ')[0];
    // request.lastname = this.fullName.value.split(' ')[1];
    // request.email = this.email.value;
    // request.username = this.username.value;
    // request.gender = this.athlete.gender;
    // request.accountType = AccountType.Athlete;

    // this.userService.create(request)
    //   .subscribe(
    //     (athlete: ApplicationUser) => {
    //       this.store.dispatch(athleteCreated({athlete}));
    //       this.onClose(athlete);
    //     },
    //     (err: HttpErrorResponse) => this.handleError(err.error)
    //   );
  }

  updateType() {
    this.exercisePropertyType.type = this.type.value;
    const exercisePropertyType = Object.assign({}, this.exercisePropertyType);

    this.exercisePropertyTypeService.update(exercisePropertyType).pipe(take(1))
      .subscribe(
        (propertyType: ExercisePropertyType) => {

          const propertyTypeUpdate: Update<ExercisePropertyType> = {
            id: propertyType.id,
            changes: propertyType
          };

          this.store.dispatch(exercisePropertyTypeUpdated({propertyType: propertyTypeUpdate}));
          this.onClose(propertyType);
        },
        (err: HttpErrorResponse) => this.handleError(err.error)
      );
  }

}
