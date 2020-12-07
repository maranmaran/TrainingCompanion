import { Component, Input, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-truncated-text',
  templateUrl: './truncated-text.component.html',
  styleUrls: ['./truncated-text.component.scss']
})
export class TruncatedTextComponent implements OnInit {

  @Input() text: string;
  @Input() characters: number;
  @Input() fallbackText: string;

  showAll = false;
  
  constructor(
    private mediaObserver: MediaObserver
  ) { }

  ngOnInit(): void {
    // on mobile we probably want to display less text.. (about 70% till further changes)
    this.mediaObserver.media$.pipe(take(1)).subscribe(
      media => {
        if(media.mqAlias == 'xs') 
          this.characters = this.characters * 0.3;
      }
    )
    
  }

}
