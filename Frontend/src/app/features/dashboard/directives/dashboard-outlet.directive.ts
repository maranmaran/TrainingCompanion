import { Directive, Input, ViewContainerRef } from '@angular/core';
import { TrackItem } from '../models/track-item.model';

@Directive({
  selector: '[appDashboardOutlet]'
})
export class DashboardOutletDirective {

  @Input() item: TrackItem

  constructor(
    public viewContainerRef: ViewContainerRef
  ) { }

}
