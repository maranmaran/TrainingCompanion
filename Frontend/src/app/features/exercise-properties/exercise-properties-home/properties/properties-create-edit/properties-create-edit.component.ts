import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { Component, OnInit, Inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AthleteCreateEditComponent } from 'src/app/features/athlete-management/athletes-home/athlete-create-edit/athlete-create-edit.component';
import { TagService } from 'src/business/services/feature-services/tag.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { Tag } from 'src/server-models/entities/tag.model';
import { FormGroup, FormControl, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { take, map, concatMap } from 'rxjs/operators';
import { Update } from '@ngrx/entity';
import { TagGroupService } from 'src/business/services/feature-services/tag-group.service';
import { selectedTagGroup } from 'src/ngrx/tag-group/tag-group.selectors';
import { tagGroupUpdated } from 'src/ngrx/tag-group/tag-group.actions';

@Component({
  selector: 'app-properties-create-edit',
  templateUrl: './properties-create-edit.component.html',
  styleUrls: ['./properties-create-edit.component.scss']
})
export class TagsCreateEditComponent implements OnInit {

  constructor(
    private store: Store<AppState>,
    protected dialogRef: MatDialogRef<TagsCreateEditComponent>,
    private tagGroupService: TagGroupService,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, action: CRUD, tag: Tag }) { }

  form: FormGroup;
  tag = new Tag();

  ngOnInit() {
    if (this.data.action == CRUD.Update) this.tag = Object.assign({}, this.data.tag);

    this.createForm();
  }

  createForm() {
    this.form = new FormGroup({
      value: new FormControl(this.tag.value, Validators.required),
    });
  }

  get value(): AbstractControl { return this.form.get('value'); }

  onActiveChange(event: MatSlideToggleChange) {
    if (event.checked) this.tag.active = true;
    if (!event.checked) this.tag.active = false;
  }

  onSubmit() {
    if (this.data.action == CRUD.Create) {
      this.createProperty();
    } else {
      this.updateProperty();
    }
  }

  onClose(tagGroup?: Tag) {
    this.dialogRef.close(tagGroup);
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
    this.tag.value = this.value.value;

    this.updateType(true, this.tag);
  }

  updateProperty() {
    this.tag.value = this.value.value;

    this.updateType(false, this.tag);
  }

  updateType(newProperty: boolean, property: Tag) {
    this.store.select(selectedTagGroup).pipe(
      take(1),
      map(tagGroup => Object.assign({}, tagGroup)),
      concatMap((tagGroup: TagGroup) => {
        tagGroup.properties = newProperty ? [...tagGroup.properties, property] : tagGroup.properties.map(prop => prop.id == property.id ? property : prop);
        return this.tagGroupService.update(tagGroup);
      }),
      take(1)
    ).subscribe((tagGroup: TagGroup) => {

      const tagGroupUpdate: Update<TagGroup> = {
        id: tagGroup.id,
        changes: tagGroup
      };

      this.store.dispatch(tagGroupUpdated({ tagGroup: tagGroupUpdate }));
      this.onClose(property);
    });
  }
}
