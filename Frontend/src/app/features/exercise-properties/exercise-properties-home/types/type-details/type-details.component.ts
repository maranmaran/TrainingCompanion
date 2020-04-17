import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Tag } from 'src/server-models/entities/tag.model';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedTagGroup } from 'src/ngrx/tag-group/tag-group.selectors';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-type-details',
  templateUrl: './type-details.component.html',
  styleUrls: ['./type-details.component.scss']
})
export class TypeDetailsComponent implements OnInit {

  tagGroup$: Observable<TagGroup>

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tagGroup$ = this.store.select(selectedTagGroup);
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
