import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedTag } from 'src/ngrx/tag-group/tag-group.selectors';
import { Tag } from 'src/server-models/entities/tag.model';
import { TagGroupService } from './../../../../../../business/services/feature-services/tag-group.service';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.scss']
})
export class PropertyDetailsComponent implements OnInit {

  tag$: Observable<Tag>

  constructor(
    private store: Store<AppState>,
    private tagsService: TagGroupService
  ) { }

  ngOnInit() {
    this.tag$ = this.store.select(selectedTag);
  }

  onSetActive(value: boolean) {
    // this.tag$.pipe(take(1),
    //   map(tag => Object.assign({}, tag)),
    //   switchMap(tag => {
    //     tag.active = value;
    //     return this.tagsService.update();
    //   },
    //     tag => tag
    //   ),
    // ).subscribe(
    //   tagGroup => {
    //     let updateStatement: Update<TagGroup> = {
    //       id: tagGroup.id,
    //       changes: tagGroup
    //     }
    //     this.store.dispatch(tagUpdated({ entity: updateStatement }));
    //   },
    //   err => console.log(err)
    // )
  }

}
