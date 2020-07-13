import { Component, Input, OnChanges, OnInit } from '@angular/core';
import * as _ from 'lodash-es';
import { ExerciseTypeTag } from 'src/server-models/entities/exercise-type.model';
import { Tag } from 'src/server-models/entities/tag.model';

@Component({
  selector: 'app-exercise-type-chip-list',
  templateUrl: './exercise-type-chip-list.component.html',
  styleUrls: ['./exercise-type-chip-list.component.scss']
})
export class ExerciseTypeChipListComponent implements OnInit, OnChanges {

  @Input() propertyList: ExerciseTypeTag[];
  @Input() showInactiveGroups: boolean;
  @Input() showInactiveTags: boolean;
  @Input() disableAll: boolean = false;

  constructor() {
  }

  ngOnInit() {

  }

  ngOnChanges() {
    this.sortProperties();
  }

  sortProperties() {
    // sort by disabled then tagGroup alphabetically and then by tag order inside that group
    this.propertyList = _.sortBy(this.propertyList, [
      property => !(property.show && property.tag.tagGroup.active),
      'tag.tagGroup.type',
      'tag.order'
    ]);
  }

  isDisabled(tag: Tag) {
    return tag.active && tag.tagGroup.active;
  }

}
