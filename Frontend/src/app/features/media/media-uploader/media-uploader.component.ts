import { MediaService } from './../../../../business/services/media.service';
import { MediaType } from './../../../../server-models/enums/media-type.enum';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit, ViewChild, ViewChildren, ElementRef, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';

@Component({
  selector: 'app-media-uploader',
  templateUrl: './media-uploader.component.html',
  styleUrls: ['./media-uploader.component.scss']
})
export class MediaUploaderComponent implements OnInit {

  @Input() fileTypesToAccept: string;
  @Input() mediaType: MediaType; 

  @ViewChild('uploadInput', {static: false}) uploadInput: ElementRef;
  
  constructor(
    private mediaService: MediaService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
  }

  triggerUploadMediaInput() {
    this.uploadInput.nativeElement.click();
  }

  uploadMedia(files: FileList) {
    console.log(files);
  }

}
