import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { Component, OnInit, Inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AthleteCreateEditComponent } from 'src/app/features/athlete-management/athletes-home/athlete-create-edit/athlete-create-edit.component';
import { ExercisePropertyService } from 'src/business/services/feature-services/exercise-property.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';
import { FormGroup, FormControl, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { take, map, concatMap } from 'rxjs/operators';
import { Update } from '@ngrx/entity';
import { ExercisePropertyTypeService } from 'src/business/services/feature-services/exercise-property-type.service';
import { selectedExercisePropertyType } from 'src/ngrx/exercise-property-type/exercise-property-type.selectors';
import { exercisePropertyTypeUpdated } from 'src/ngrx/exercise-property-type/exercise-property-type.actions';

@Component({
  selector: 'app-properties-create-edit',
  templateUrl: './properties-create-edit.component.html',
  styleUrls: ['./properties-create-edit.component.scss']
})
export class PropertiesCreateEditComponent implements OnInit {

  constructor(
    private store: Store<AppState>,
    protected dialogRef: MatDialogRef<AthleteCreateEditComponent>,
    private exercisePropertyTypeService: ExercisePropertyTypeService,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, action: CRUD, exerciseProperty: ExerciseProperty }) { }

  form: FormGroup;
  exerciseProperty = new ExerciseProperty();

  ngOnInit() {
    if (this.data.action == CRUD.Update) this.exerciseProperty = Object.assign({}, this.data.exerciseProperty);

    this.createForm();
  }

  createForm() {
    this.form = new FormGroup({
      value: new FormControl(this.exerciseProperty.value, Validators.required),
    });
  }

  get value(): AbstractControl { return this.form.get('value'); }
  
  onActiveChange(event: MatSlideToggleChange) {
    if (event.checked) this.exerciseProperty.active = true;
    if (!event.checked) this.exerciseProperty.active = false;
  }

  onSubmit() {
    if (this.data.action == CRUD.Create) {
      this.createProperty();
    } else {
      this.updateProperty();
    }
  }

  onClose(propertyType?: ExerciseProperty) {
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

  createProperty() {
    this.exerciseProperty.value = this.value.value;

    this.updateType(true, this.exerciseProperty);
  }

  updateProperty() {
    this.exerciseProperty.value = this.value.value;

    this.updateType(false, this.exerciseProperty);
  }

  updateType(newProperty: boolean, property: ExerciseProperty) {
    this.store.select(selectedExercisePropertyType).pipe(
      take(1),
      map(propertyType => Object.assign({}, propertyType)),
      concatMap((propertyType: ExercisePropertyType) => {
        propertyType.properties = newProperty ? [...propertyType.properties, property] : propertyType.properties.map(prop => prop.id == property.id ? property : prop);
        return this.exercisePropertyTypeService.update(propertyType);
      }),
      take(1)
    ).subscribe((propertyType: ExercisePropertyType) => {

      const propertyTypeUpdate: Update<ExercisePropertyType> = {
        id: propertyType.id,
        changes: propertyType
      };

      this.store.dispatch(exercisePropertyTypeUpdated({ propertyType: propertyTypeUpdate }));
      this.onClose(property);
    });
  }
}
