import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-active-flag',
  templateUrl: './active-flag.component.html',
  styleUrls: ['./active-flag.component.scss']
})
export class ActiveFlagComponent implements OnInit {

  @Input() active: boolean;
  
  constructor() { }

  ngOnInit() {
  }

}
