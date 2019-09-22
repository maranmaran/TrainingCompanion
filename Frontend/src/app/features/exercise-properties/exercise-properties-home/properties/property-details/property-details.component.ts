import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { Component, OnInit } from '@angular/core';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Tag } from 'src/server-models/entities/tag.model';
import { selectedTag } from 'src/ngrx/tag-group/tag-group.selectors';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.scss']
})
export class PropertyDetailsComponent implements OnInit {

  tag$: Observable<Tag>

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tag$ = this.store.select(selectedTag);
  }

}
