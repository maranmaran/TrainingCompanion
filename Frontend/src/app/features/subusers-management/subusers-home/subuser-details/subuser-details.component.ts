import { FormGroup } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

@Component({
  selector: 'app-subuser-details',
  templateUrl: './subuser-details.component.html',
  styleUrls: ['./subuser-details.component.scss']
})
export class SubuserDetailsComponent implements OnInit {

  @Input() subuser: ApplicationUser;
  

  constructor() { }

  ngOnInit() {
  }

}
