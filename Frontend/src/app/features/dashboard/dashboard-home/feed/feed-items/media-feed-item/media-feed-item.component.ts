import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Activity, BasicActivityInfo, BasicUserInfo } from 'src/app/features/dashboard/models/activity.model';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';

@Component({
  selector: 'app-media-feed-item',
  templateUrl: './media-feed-item.component.html',
})
export class MediaFeedItemComponent implements OnInit {

  @Input() activity: BasicActivityInfo;
  @Input() user: BasicUserInfo;
  message: string;

  constructor(
    private translateService: TranslateService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    const params = {
      username: this.user.userName,
    }

    this.message = this.translateService.instant('DASHBOARD.FEED.MEDIA_MESSAGE', params);
  }

  enlarge() {
    this.dialog.open(MediaDialogComponent, {
      height: 'auto',
      width: 'auto',
      maxWidth: '58rem',
      maxHeight: '40rem',
      autoFocus: false,
      data: { type: this.activity.entity.type, sourceUrl: this.activity.entity.downloadUrl },
      panelClass: 'media-dialog-container'
    });
  }

}
