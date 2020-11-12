import { Component, Input, OnInit } from '@angular/core';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { MediaService } from './../../../../../business/services/feature-services/media.service';

@Component({
  selector: 'app-media-list',
  templateUrl: './media-list.component.html',
  styleUrls: ['./media-list.component.scss']
})
export class MediaListComponent implements OnInit {

  @Input() fileTypesToAccept = 'image/*';
  @Input() mediaList: MediaFile[];

  constructor(
    private mediaService: MediaService
  ) { }

  ngOnInit() {
  }

  enlarge(media: MediaFile, index: number) {

    // handle single image
    // TODO what if we implement comments
    if (this.mediaList.length === 1) {
        return this.mediaService.enlargeSingle(media.type, media.downloadUrl);
    }

    this.mediaService.enlargeCarousel(media, this.mediaList, index);
  }



}
