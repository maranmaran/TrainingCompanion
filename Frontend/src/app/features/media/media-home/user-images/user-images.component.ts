import { Component, OnInit } from '@angular/core';
import { MediaType } from 'src/server-models/enums/media-type.enum';
import { MediaService } from 'src/business/services/media.service';

@Component({
  selector: 'app-user-images',
  templateUrl: './user-images.component.html',
  styleUrls: ['./user-images.component.scss']
})
export class UserImagesComponent implements OnInit {

  fileTypesToAccept = "image/*";
  mediaType = MediaType.Image;

  constructor(
    private mediaService: MediaService
  ) { }

  ngOnInit() {
  }

}
