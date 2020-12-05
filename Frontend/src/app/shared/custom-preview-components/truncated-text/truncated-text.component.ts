import { Component, Input, OnInit } from '@angular/core';

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
  
  constructor() { }

  ngOnInit(): void {
  }

}
