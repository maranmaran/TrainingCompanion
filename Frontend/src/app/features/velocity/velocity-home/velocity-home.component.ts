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

    this.acceleration$ = this.deviceMotionService.accelerationManager.data$;
    this.rotation$ = this.deviceMotionService.rotationManager.data$;
    this.minMax$ = this.deviceMotionService.accelerationManager.minMax$;
    this.accelerationSnapshotData = this.deviceMotionService.accelerationManager.snapshotData;
  }

  onAccelerationSnapshot(result) {
    this.deviceMotionService.accelerationManager.recordCalculator(result);
  }

  onAccelerationReset() {
    this.deviceMotionService.accelerationManager.resetCalculator();
  }

  ngOnDestroy() {
    window.removeEventListener('devicemotion', this.deviceMotionService.getMotionHandlerFn());
    this.deviceMotionService.destroy();
  }

}
