import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ImageCroppedEvent } from 'ngx-image-cropper/public-api';

@Component({
  selector: 'app-image-cropper',
  templateUrl: './image-cropper.component.html',
  styleUrls: ['./image-cropper.component.scss']
})
export class ImageCropperComponent implements OnInit {

  showCropper = false;
  imageCroppedEvent: ImageCroppedEvent;

  constructor(
    public dialogRef: MatDialogRef<ImageCropperComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      config: ImageCropperConfiguration
    }) { }

  ngOnInit(): void {
  }

  imageLoaded() {
  }

  cropperReady() {

  }

  loadImageFailed() {

  }

  imageCropped(event: ImageCroppedEvent) {
    this.imageCroppedEvent = event;
  }

}

export class ImageCropperConfiguration {

  imageChangedEvent: any = '';
  format: string = 'jpeg';
  imageQuality: number = 60; // only jpeg - 0 to 100
  roundCropper: boolean = true;

  constructor(config: Partial<ImageCropperConfiguration>) {
    Object.assign(this, config);
  }
}
