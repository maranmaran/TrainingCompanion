import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-upload-input',
  templateUrl: './upload-input.component.html',
  styleUrls: ['./upload-input.component.scss']
})
export class UploadInputComponent {

  @Input() fileTypesToAccept: string;
  @Output() fileUploaded = new EventEmitter<File>();

  @ViewChild('uploadInput') uploadInput: ElementRef;

  constructor(
  ) { }

  triggerUploadMediaInput() {
    this.uploadInput.nativeElement.click();
  }

  uploadMedia(files: FileList) {
    if (files.item(0)) {
      this.fileUploaded.emit(files.item(0));
      this.uploadInput.nativeElement.value = '';
    }
  }

}
