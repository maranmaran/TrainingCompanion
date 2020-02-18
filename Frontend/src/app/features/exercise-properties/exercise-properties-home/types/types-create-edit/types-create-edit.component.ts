import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { CRUD } from 'src/business/shared/crud.enum';
import { clearExerciseTypeState } from 'src/ngrx/exercise-type/exercise-type.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { tagGroupUpdated } from 'src/ngrx/tag-group/tag-group.actions';
import { TagGroupService } from '../../../../../../business/services/feature-services/tag-group.service';
import { tagGroupCreated } from './../../../../../../ngrx/tag-group/tag-group.actions';
import { TagGroup } from './../../../../../../server-models/entities/tag-group.model';

@Component({
  selector: 'app-types-create-edit',
  templateUrl: './types-create-edit.component.html',
  styleUrls: ['./types-create-edit.component.scss']
})
export class TypesCreateEditComponent implements OnInit {


  constructor(
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<TypesCreateEditComponent>,
    private tagGroupService: TagGroupService,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, action: CRUD, tagGroup: TagGroup }) { }

  form: FormGroup;
  tagGroup: TagGroup;

  ngOnInit() {
    this.tagGroup = Object.assign({}, this.data.tagGroup);

    this.createForm();
  }

  createForm() {
    this.form = new FormGroup({
      type: new FormControl(this.tagGroup.type, Validators.required),
    });
  }

  get type(): AbstractControl { return this.form.get('type'); }

  onActiveChange(event: MatSlideToggleChange) {
    if (event.checked) this.tagGroup.active = true;
    if (!event.checked) this.tagGroup.active = false;
  }

  onSubmit() {
    if (this.data.action == CRUD.Create) {
      this.createType();
    } else {
      this.updateType();
    }
  }

  onClose(tagGroup?: TagGroup) {
    this.dialogRef.close(tagGroup);
  }

  createType() {
    this.tagGroup.type = this.type.value;
    const tagGroup = Object.assign(new TagGroup(), this.tagGroup);
    tagGroup.tags = [];

    this.tagGroupService.create(tagGroup).pipe(take(1))
      .subscribe(
        (tagGroup: TagGroup) => {
          this.store.dispatch(tagGroupCreated({ tagGroup }));
          this.onClose(tagGroup);
        },
        (err: HttpErrorResponse) => console.log(err.error)
      );
  }

  updateType() {
    this.tagGroup.type = this.type.value;
    const tagGroup = Object.assign(new TagGroup(), this.tagGroup);

    this.tagGroupService.update(tagGroup).pipe(take(1))
      .subscribe(
        (tagGroup: TagGroup) => {

          const tagGroupUpdate: Update<TagGroup> = {
            id: tagGroup.id,
            changes: tagGroup
          };

          this.store.dispatch(tagGroupUpdated({ tagGroup: tagGroupUpdate }));
          // clear exercise type state.. so we can fetch new tags and everything
          this.store.dispatch(clearExerciseTypeState());
          this.onClose(tagGroup);
        },
        (err: HttpErrorResponse) => console.log(err.error)
      );
  }

}
