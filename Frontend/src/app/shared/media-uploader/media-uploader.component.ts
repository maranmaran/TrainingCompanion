import { ComponentPortal } from '@angular/cdk/portal';
import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { UploadInputComponent } from './upload-input/upload-input.component';

@Component({
  selector: 'app-media-uploader',
  templateUrl: './media-uploader.component.html',
  styleUrls: ['./media-uploader.component.scss']
})
export class MediaUploaderComponent implements OnInit, AfterViewInit {

  @Input() files: MediaFile[];
  @Input() fileTypesToAccept: string;
  @Output() fileUploaded = new EventEmitter<File>();

  uploadInputComponent: ComponentPortal<UploadInputComponent>;

  constructor() { }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
      this.uploadInputComponent = new ComponentPortal(UploadInputComponent);
  }

  onUploadFile(file: File) {
    this.fileUploaded.emit(file);
  }

}
