import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, HostListener, Inject, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NguCarousel, NguCarouselConfig } from '@ngu/carousel';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { MediaType } from './../../../../server-models/enums/media-type.enum';

@Component({
  selector: 'app-media-carousel',
  templateUrl: './media-carousel.component.html',
  styleUrls: ['./media-carousel.component.scss']
})
export class MediaCarouselComponent implements OnInit, AfterViewInit {

  @Input() media: MediaFile[];
  @Input() selectedMedia: MediaFile;
  @Input() selectedIndex: number;

  mediaType = MediaType;

  carouselConfig: NguCarouselConfig = {
    grid: { xs: 1, sm: 1, md: 1, lg: 1, all: 0 },
    load: 1,
    loop: false,
    touch: true,
    velocity: 0.3,
    point: {
      visible: true,
      hideOnSingleSlide: true
    }
  }
  carouselItems = [];

  @ViewChild('carousel', { static: true }) carousel: NguCarousel<any>;
  @ViewChild('prevBtn', { read: ElementRef }) prevBtn: ElementRef;
  @ViewChild('nextBtn', { read: ElementRef }) nextBtn: ElementRef;
  @HostListener('document:keydown.ArrowRight', ['$event']) keyRight = () => this.next();
  @HostListener('document:keydown.ArrowLeft', ['$event']) keyLeft = () => this.previous();

  constructor(
    private cdr: ChangeDetectorRef,
    private dialogRef: MatDialogRef<MediaCarouselComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { media: MediaFile[], selectedMedia: MediaFile, index: number }) {
    this.media = data.media;
    this.selectedIndex = data.index;
    this.selectedMedia = data.selectedMedia;

    this.carouselItems = [...this.media];
  }

  ngOnInit(): void {
  }

  ngAfterViewInit() {
    this.carousel.moveTo(this.selectedIndex, true);
    this.cdr.detectChanges();
  }

  onClose() {
    this.dialogRef.close();
  }

  previous(event = null) {
    this.prevBtn.nativeElement.click();
  }

  next(event = null) {
    this.nextBtn.nativeElement.click();
  }

  // handle play of video on swipe event
  onPlayingVideo(event, index) {
    if (this.carousel.currentSlide != index) {
      event.target.pause();
      event.target.currentTime = 0;
      event.target.load();
    }
  }
}
