import { Directive, Input, ViewContainerRef } from '@angular/core';
import { DashboardItem } from '../models/dashboard-item.interface';

@Directive({
  selector: '[appDashboardOutlet]'
})
export class DashboardOutletDirective {

  @Input() item: DashboardItem

  constructor(
    public viewContainerRef: ViewContainerRef
  ) { }

}
