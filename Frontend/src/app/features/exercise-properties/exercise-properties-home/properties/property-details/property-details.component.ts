import { TagGroupService } from './../../../../../../business/services/feature-services/tag-group.service';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { Component, OnInit } from '@angular/core';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Tag } from 'src/server-models/entities/tag.model';
import { selectedTag } from 'src/ngrx/tag-group/tag-group.selectors';
import { take, map, switchMap } from 'rxjs/operators';
import { getUpdateUserRequest } from 'src/server-models/cqrs/users/update-user.request';
import { Update } from '@ngrx/entity';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { tagUpdated } from 'src/ngrx/tag/tag.actions';
import { TagGroup } from 'src/server-models/entities/tag-group.model';

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
