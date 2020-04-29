import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DeviceMotionService } from '../services/device-motion.service';
import { DeviceAccelerationRecord, DeviceRotationRecord } from './../services/device-motion.service';

@Component({
  selector: 'app-velocity-home',
  templateUrl: './velocity-home.component.html',
  styleUrls: ['./velocity-home.component.scss']
})
export class VelocityHomeComponent implements OnInit, OnDestroy {

  constructor(
    private deviceMotionService: DeviceMotionService
  ) { }

  accelerationSnapshotData: { min: number, max: number, total: number}[];
  minMax$: Observable<{ min: number, max: number, total: number}>;
  acceleration$: Observable<DeviceAccelerationRecord>;
  rotation$: Observable<DeviceRotationRecord>;

  ngOnInit(): void {
    if (window.DeviceMotionEvent) {
      // DeviceMotionEvent.requestPermission().then(
      //   response => {
      //     if (response == 'granted')
      //       window.addEventListener('devicemotion', e => this.motionHandler(e));
      //   }
      // )
      window.addEventListener('devicemotion', this.deviceMotionService.getMotionHandlerFn());
    }

    this.acceleration$ = this.deviceMotionService.acceleration$;
    this.rotation$ = this.deviceMotionService.rotation$;
    this.minMax$ = this.deviceMotionService.minMax$;
    this.accelerationSnapshotData = this.deviceMotionService.accelerationSnapshotData;
  }

  onAccelerationSnapshot(result) {
    this.deviceMotionService.accelerationSnapshot(result);
  }

  onAccelerationReset() {
    this.deviceMotionService.accelerationReset();
  }

  ngOnDestroy() {
    window.removeEventListener('devicemotion', this.deviceMotionService.getMotionHandlerFn());
    this.deviceMotionService.destroy();
  }

}
