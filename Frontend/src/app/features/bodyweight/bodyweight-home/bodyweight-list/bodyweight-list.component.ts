import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { CRUD } from 'src/business/shared/crud.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Bodyweight } from 'src/server-models/entities/bodyweight.model';
import { UIService } from './../../../../../business/services/shared/ui.service';
import { bodyweights } from './../../../../../ngrx/bodyweight/bodyweight.selectors';
import { BodyweightCreateEditComponent } from './../bodyweight-create-edit/bodyweight-create-edit.component';

@Component({
  selector: 'app-bodyweight-list',
  templateUrl: './bodyweight-list.component.html',
  styleUrls: ['./bodyweight-list.component.scss']
})
export class BodyweightListComponent implements OnInit {

  bodyweights$: Observable<Bodyweight[]>

  constructor(
    private uiService: UIService,
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    this.bodyweights$ = this.store.select(bodyweights)
  }

  onAdd() {
    const dialogRef = this.uiService.openDialogFromComponent(BodyweightCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'Add bodyweight record', action: CRUD.Create },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((entity: Bodyweight) => {
        // something
        }
      )
  }
}
