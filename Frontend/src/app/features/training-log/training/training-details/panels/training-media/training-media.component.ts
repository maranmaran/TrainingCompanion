import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MediaFile } from './../../../../../../../server-models/entities/media-file.model';

@Component({
  selector: 'app-training-media',
  templateUrl: './training-media.component.html',
  styleUrls: ['./training-media.component.scss']
})
export class TrainingMediaComponent implements OnInit {

  @Input() media: MediaFile[];
  @Output() onFileUploaded = new EventEmitter<File>();

  constructor() { }

  ngOnInit() {
  }

}
