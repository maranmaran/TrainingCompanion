import { AfterViewInit, Component, Inject, OnInit, ViewChild, ViewChildren, QueryList } from "@angular/core";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";
import { MatCheckboxChange } from '@angular/material/checkbox';
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Store } from "@ngrx/store";
import * as _ from "lodash";
import { concatMap, take, map } from "rxjs/operators";
import { ExerciseTypeService } from "src/business/services/feature-services/exercise-type.service";
import { TagGroupService } from "src/business/services/feature-services/tag-group.service";
import { CRUD } from "src/business/shared/crud.enum";
import { AppState } from "src/ngrx/app/app.state";
import { ExerciseType, ExerciseTypeTag } from "src/server-models/entities/exercise-type.model";
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { Tag } from 'src/server-models/entities/tag.model';
import { currentUserId } from "./../../../../../ngrx/auth/auth.selectors";
import { MatSelectChange, MatSelect } from '@angular/material/select';

@Component({
  selector: "app-exercise-type-create-edit",
  templateUrl: "./exercise-type-create-edit.component.html",
  styleUrls: ["./exercise-type-create-edit.component.scss"]
})
export class ExerciseTypeCreateEditComponent implements OnInit, AfterViewInit {
  constructor(
    private store: Store<AppState>,
    private tagGroupService: TagGroupService,
    protected dialogRef: MatDialogRef<ExerciseTypeCreateEditComponent>,
    private typeService: ExerciseTypeService,
    @Inject(MAT_DIALOG_DATA)
    public data: { title: string; action: CRUD; entity: ExerciseType }
  ) { }

  form: FormGroup;
  userId: string;
  entity = new ExerciseType();
  protected tagGroups: TagGroup[] = [];

  @ViewChildren(MatSelect) tagSelects: QueryList<MatSelect>;

  ngOnInit() {
    if (this.data.action === CRUD.Update) {
      this.entity = _.cloneDeep(this.data.entity);
    }

    // prerequisite data
    // can't filter included data https://github.com/aspnet/EntityFrameworkCore/issues/1833
    // do it in frontend...
    this.store
      .select(currentUserId)
      .pipe(
        take(1),
        concatMap((userId: string) => {
          this.userId = userId;
          return this.tagGroupService.getAll(userId);
        }),
        take(1),
        map((groups: TagGroup[]) => groups.map(group => {
          group.tags = group.tags.filter(tag => !!tag.active && this.entity.properties.find(x => x.tagId != tag.id)); // filter out assigned tags and unactive tags
          return group;
        }))
      )
      .subscribe(
        (tagGroups: TagGroup[]) => {
          this.tagGroups = tagGroups;
        },
        err => console.log(err)
      );

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
        Validators.min(1),
        Validators.max(50)
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

  onShowChange(event: MatCheckboxChange) {
    this.entity.properties[event.source.name].show = event.checked;
  }

  onTagGroupActiveChange(event: MatCheckboxChange, index: number) {
    this.tagGroups[index].active = event.checked;
  }

  tagSelectionChanged(change: MatSelectChange) {

    var tag = change.value;
    var exerciseTypeTag = new ExerciseTypeTag();
    exerciseTypeTag.exerciseTypeId = this.entity.id;
    exerciseTypeTag.tag = tag;
    exerciseTypeTag.tagId = tag.id;
    exerciseTypeTag.show = true;

    // add
    this.entity.properties.push(exerciseTypeTag);

    // remove added tag
    var tagGroup = this.tagGroups.find(x => x.id == tag.tagGroupId);
    tagGroup.tags = tagGroup.tags.filter(t => t.id != tag.id);
    this.tagGroups = this.tagGroups.map(x => x.id == tagGroup.id ? tagGroup : x);

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
    this.createType();
  }

  onClose(type?: ExerciseType) {
    this.dialogRef.close(type);
  }

  createType() {

  }
}
