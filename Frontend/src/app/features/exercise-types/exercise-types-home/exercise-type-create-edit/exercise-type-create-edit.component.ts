import { AfterViewInit, Component, Inject, OnInit, QueryList, ViewChildren } from "@angular/core";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";
import { MatCheckboxChange } from '@angular/material/checkbox';
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MatSelect, MatSelectChange } from '@angular/material/select';
import { Update } from '@ngrx/entity';
import { Store } from "@ngrx/store";
import * as _ from "lodash";
import { take } from 'rxjs/operators';
import { ExerciseTypeService } from "src/business/services/feature-services/exercise-type.service";
import { TagGroupService } from "src/business/services/feature-services/tag-group.service";
import { CRUD } from "src/business/shared/crud.enum";
import { exerciseTypeUpdated } from 'src/ngrx/exercise-type/exercise-type.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UpdateExerciseTypeRequest } from 'src/server-models/cqrs/exercise-type/update-exercise-type.request';
import { ExerciseType, ExerciseTypeTag } from "src/server-models/entities/exercise-type.model";
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { Tag } from 'src/server-models/entities/tag.model';

@Component({
  selector: "app-exercise-type-create-edit",
  templateUrl: "./exercise-type-create-edit.component.html",
  styleUrls: ["./exercise-type-create-edit.component.scss"]
})
export class ExerciseTypeCreateEditComponent implements OnInit, AfterViewInit {
  constructor(
    private store: Store<AppState>,
    private tagGroupService: TagGroupService,
    private dialogRef: MatDialogRef<ExerciseTypeCreateEditComponent>,
    private typeService: ExerciseTypeService,
    @Inject(MAT_DIALOG_DATA)
    public data: { title: string; action: CRUD; entity: ExerciseType, tagGroups: TagGroup[] }
  ) { }

  form: FormGroup;
  entity = new ExerciseType();
  tagGroups: TagGroup[] = [];

  @ViewChildren(MatSelect) tagSelects: QueryList<MatSelect>;

  ngOnInit() {
    if (this.data.action === CRUD.Update) {
      this.entity = _.cloneDeep(this.data.entity);
    }

    this.tagGroups = this.data.tagGroups;

    this.createForm();
  }

  // Workaround for angular component issue #13870
  disableAnimation = true;
  ngAfterViewInit(): void {
    // timeout required to avoid the dreaded 'ExpressionChangedAfterItHasBeenCheckedError'
    setTimeout(() => this.disableAnimation = false);
  }

  createForm() {
    this.form = new FormGroup({
      name: new FormControl(this.entity.name, [
        Validators.required,
        Validators.minLength(1),
        Validators.maxLength(50)
      ]),
      code: new FormControl(this.entity.code, [
        Validators.required,
        Validators.minLength(1),
        Validators.maxLength(50)
      ]),
      active: new FormControl(this.entity.active),
      requiresWeight: new FormControl(this.entity.requiresWeight),
      requiresBodyweight: new FormControl(this.entity.requiresBodyweight),
      requiresReps: new FormControl(this.entity.requiresReps),
      requiresSets: new FormControl(this.entity.requiresSets),
      requiresTime: new FormControl(this.entity.requiresTime)
    });
  }

  get name(): AbstractControl {
    return this.form.get("name");
  }
  get code(): AbstractControl {
    return this.form.get("code");
  }
  get active(): AbstractControl {
    return this.form.get("active");
  }
  get requiresWeight(): AbstractControl {
    return this.form.get("requiresWeight");
  }
  get requiresBodyweight(): AbstractControl {
    return this.form.get("requiresBodyweight");
  }
  get requiresReps(): AbstractControl {
    return this.form.get("requiresReps");
  }
  get requiresSets(): AbstractControl {
    return this.form.get("requiresSets");
  }
  get requiresTime(): AbstractControl {
    return this.form.get("requiresTime");
  }

  onCheckboxChange(change: MatCheckboxChange) {
    switch (change.source.name) {
      case 'time':
        this.requiresReps.value && change.checked && this.requiresReps.setValue(false);
        break;
      case 'weight':
        this.requiresBodyweight.value && change.checked && this.requiresBodyweight.setValue(false);
        break;
      case 'bodyweight':
        this.requiresWeight.value && change.checked && this.requiresWeight.setValue(false);
        break;
      case 'reps':
        this.requiresTime.value && change.checked && this.requiresTime.setValue(false);
        break;
      default:
        throw new Error('No checkbox like that defined ' + change.source);
    }
  }

  getEntityTags(tagGroupId: string) {
    return this.entity.properties ? this.entity.properties.filter(x => x.tag.tagGroupId === tagGroupId) : [];
  }

  getGroupTags(tagGroupId: string) {
    return this.tagGroups ? this.tagGroups.find(x => x.id === tagGroupId).tags : [];
  }

  trackByFn(index: number, item: ExerciseTypeTag) {
    return item ? item.id : null;
  }

  displayFn(tag: Tag) {
    return tag.value;
  }

  onShowChange(event: MatCheckboxChange, index: number) {
    this.entity.properties[index].show = event.checked;
  }

  onTagGroupActiveChange(event: MatCheckboxChange, index: number) {
    this.tagGroups[index].active = event.checked;
  }

  tagSelectionChanged(change: MatSelectChange) {

    var tag = change.value;
    // remove added tag
    var tagGroup = this.tagGroups.find(x => x.id == tag.tagGroupId);
    tagGroup.tags = tagGroup.tags.filter(t => t.id != tag.id);
    this.tagGroups = this.tagGroups.map(x => x.id == tagGroup.id ? tagGroup : x);

    // add
    var exerciseTypeTag = new ExerciseTypeTag();
    exerciseTypeTag.exerciseTypeId = this.entity.id;
    exerciseTypeTag.tag = tag;
    exerciseTypeTag.tag.tagGroup = tagGroup;
    exerciseTypeTag.tagId = tag.id;
    exerciseTypeTag.show = true;

    this.entity.properties.push(exerciseTypeTag);

    //clear
    var selectInput = this.tagSelects.find(x => x.id == change.source.id);
    selectInput.writeValue(null);
  }

  removeTag(property: ExerciseTypeTag) {
    // remove from properties
    this.entity.properties = this.entity.properties.filter(x => x.tagId != property.tagId);

    // add to tags that can be selected
    var tagGroup = this.tagGroups.find(x => x.id == property.tag.tagGroupId);
    tagGroup.tags.push(property.tag);
    this.tagGroups = this.tagGroups.map(x => x.id == tagGroup.id ? tagGroup : x);
  }

  onSubmit() {
    this.entity.name = this.name.value;
    this.entity.code = this.code.value;
    this.entity.active = this.active.value;
    this.entity.requiresBodyweight = this.requiresBodyweight.value;
    this.entity.requiresReps = this.requiresReps.value;
    this.entity.requiresSets = this.requiresSets.value;
    this.entity.requiresTime = this.requiresTime.value;
    this.entity.requiresWeight = this.requiresWeight.value;

    if (this.data.action == CRUD.Create) {
      this.createType();
    } else {
      this.updateType();
    }
  }

  onClose(type?: ExerciseType) {
    this.dialogRef.close(type);
  }

  createType() {

  }

  updateType() {

    const request = new UpdateExerciseTypeRequest();
    request.exerciseType = this.entity;

    this.typeService.update<UpdateExerciseTypeRequest, ExerciseType>(request).pipe(take(1))
      .subscribe(
        (exerciseType: ExerciseType) => {

          const exerciseTypeUpdate: Update<ExerciseType> = {
            id: exerciseType.id,
            changes: exerciseType
          };

          this.store.dispatch(exerciseTypeUpdated({ entity: exerciseTypeUpdate }));
          this.onClose(exerciseType);
        },
        err => console.log(err)
      );
  }
}
