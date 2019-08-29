import { MediaFile } from 'src/server-models/entities/media-file.model';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-media-container',
  templateUrl: './media-container.component.html',
  styleUrls: ['./media-container.component.scss']
})
export class MediaContainerComponent implements OnInit {

  @Input() media: MediaFile[];
  
  constructor() { }

  ngOnInit() {
  }

}
