import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { concatMap, map, switchMap, take } from 'rxjs/operators';
import { TagGroupService } from 'src/business/services/feature-services/tag-group.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import * as TagGroupActions from './tag-group.actions';
import { allTagGroups } from './tag-group.selectors';


@Injectable()
export class TagGroupEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private tagGroupService: TagGroupService
    ) { }

    reordered$ = createEffect(() =>
    this.actions$
        .pipe(
            ofType(TagGroupActions.reorderTagGroups),
            concatMap(_ => this.store.select(allTagGroups)),
            switchMap((groups: TagGroup[]) =>
              this.tagGroupService.updateMany(groups)
              .pipe(
                take(1),
                map((tagGroups: TagGroup[]) => {

                  let updateStatements = tagGroups.map(group => {
                    let updateStatement: Update<TagGroup>;
                    updateStatement = { id: group.id, changes: group }
                    return updateStatement;
                  });

                  return this.store.dispatch(TagGroupActions.manyTagGroupsUpdated({tagGroups: updateStatements}))
                })
            ))
        )
    , { dispatch: false });

}
