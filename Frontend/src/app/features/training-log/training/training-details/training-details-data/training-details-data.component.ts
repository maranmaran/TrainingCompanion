import { Component, Input, OnInit } from "@angular/core";
import { Store } from "@ngrx/store";
import { combineLatest, Observable } from "rxjs";
import { map } from "rxjs/operators";
import { transformWeight } from "src/business/services/shared/unit-system.service";
import {
  sessionNumberOfLifts,
  sessionVolume,
} from "src/ngrx/exercise/exercise.selectors";
import { AppState } from "src/ngrx/global-setup.ngrx";
import { unitSystem } from "./../../../../../../ngrx/auth/auth.selectors";

@Component({
  selector: "app-training-details-data",
  templateUrl: "./training-details-data.component.html",
  styleUrls: ["./training-details-data.component.scss"],
})
export class TrainingDetailsDataComponent implements OnInit {
  @Input() trainingId: string;

  data: Observable<{ volume: string; numOfLifts: number }>;

  constructor(private store: Store<AppState>) {}

  ngOnInit() {
    this.data = combineLatest(
      this.store.select(unitSystem),
      this.store.select(sessionVolume, this.trainingId),
      this.store.select(sessionNumberOfLifts, this.trainingId)
    ).pipe(
      map(([system, volume, numOfLifts]) => ({
        volume: transformWeight(volume, system),
        numOfLifts,
      }))
    );
  }
}
