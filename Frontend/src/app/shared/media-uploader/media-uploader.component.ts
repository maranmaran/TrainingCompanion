import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MediaFile } from 'src/server-models/entities/media-file.model';

@Component({
  selector: 'app-media-uploader',
  templateUrl: './media-uploader.component.html',
  styleUrls: ['./media-uploader.component.scss']
})
export class MediaUploaderComponent implements OnInit {

  @Input() files: MediaFile[];
  @Output() fileUploaded = new EventEmitter<File>();

  constructor() { }

  ngOnInit() {
  }

  onUploadFile(file: File) {
    this.fileUploaded.emit(file);
  }

}
