import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { take } from 'rxjs/operators';
import { TrainingCreateEditComponent } from 'src/app/features/training-log/training/training-create-edit/training-create-edit.component';
import { TrainingBlockDay } from 'src/server-models/entities/training-program.model';
import { Training } from 'src/server-models/entities/training.model';
import { TrainingService } from './../../../../../../business/services/feature-services/training.service';

@Component({
  selector: 'app-block-day',
  templateUrl: './block-day.component.html',
  styleUrls: ['./block-day.component.scss']
})
export class BlockDayComponent implements OnInit {

  @Input() day: TrainingBlockDay;
  isRestDay: boolean = false;

  public get dayLabel(): string {
    // return this.translate.instant('TRAINING_BLOCK_DAY.DAY_LABEL', { number: (this.day.order - 1) % 7 + 1 });
    return `${(this.day.order - 1) % 7 + 1}.`;
  }

  constructor(
    private translate: TranslateService,
    private trainingService: TrainingService,
    private changeTracking: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.changeTracking.detectChanges();
  }

  onAdd() {
    this.trainingService.onAdd(TrainingCreateEditComponent, this.day.id)
      .afterClosed()
      .pipe(take(1))
      .subscribe((training: Training) => {

        if (!this.day.trainings) this.day.trainings = [];

        this.day.trainings.push(training);
        //this.store.dispatch(trainingAddedToBlockDay({training: training, blockDay: day}));
      });
  }

}
