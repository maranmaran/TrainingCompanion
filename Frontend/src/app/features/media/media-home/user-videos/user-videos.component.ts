import { Component, OnInit } from '@angular/core';
import { MediaType } from 'src/server-models/enums/media-type.enum';
import { MediaService } from 'src/business/services/media.service';

@Component({
  selector: 'app-user-videos',
  templateUrl: './user-videos.component.html',
  styleUrls: ['./user-videos.component.scss']
})
export class UserVideosComponent implements OnInit {

  fileTypesToAccept = "video/*";
  mediaType = MediaType.Video;

  constructor(
    private mediaService: MediaService
  ) { }

  ngOnInit() {
  }

  

}
