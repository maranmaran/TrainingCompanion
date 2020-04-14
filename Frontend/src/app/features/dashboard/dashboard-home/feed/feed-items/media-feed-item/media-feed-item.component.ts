import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Activity } from 'src/app/features/dashboard/models/activity.model';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';

@Component({
  selector: 'app-media-feed-item',
  templateUrl: './media-feed-item.component.html',
})
export class MediaFeedItemComponent implements OnInit {

  @Input() activity: Activity;
  message: string;

  constructor(
    private translateService: TranslateService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    const params = {
      username: this.activity.userName,
    }

    this.message = this.translateService.instant('DASHBOARD.FEED.MEDIA_MESSAGE', params);
  }

  enlargeImage() {
    this.dialog.open(MediaDialogComponent, {
      height: 'auto',
      width: 'auto',
      maxWidth: '58rem',
      maxHeight: '40rem',
      autoFocus: false,
      data: { type: this.activity.entity.Type, sourceUrl: this.activity.entity.DownloadUrl },
      panelClass: 'media-dialog-container'
    });
  }

}
