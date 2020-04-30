import { Component, OnDestroy, OnInit } from '@angular/core';
import { fromEvent, Observable } from 'rxjs';
import { throttleTime } from 'rxjs/operators';
import { SubSink } from 'subsink';
import { DeviceMotionService } from '../services/device-motion.service';
import { DeviceAccelerationRecord } from './../services/device-motion.service';

@Component({
  selector: 'app-velocity-home',
  templateUrl: './velocity-home.component.html',
  styleUrls: ['./velocity-home.component.scss'],
  providers: [ DeviceMotionService ]
})
export class VelocityHomeComponent implements OnInit, OnDestroy {

  constructor(
    private deviceMotionService: DeviceMotionService
  ) { }

  accelerationSnapshotData: { min, max, total, timestamp }[];
  minMaxRealtime$: Observable<{ min, max, total, timestamp}>;
  acceleration$: Observable<DeviceAccelerationRecord>;

  subs = new SubSink();

  ngOnInit(): void {

    // if (window.DeviceMotionEvent) {
    //   DeviceMotionEvent.requestPermission().then(
    //     response => {
    //       if (response == 'granted')
    //         window.addEventListener('devicemotion', e => this.motionHandler(e));
    //     }
    //   )


      this.subs.add(
        fromEvent(window, 'devicemotion')
        .pipe(throttleTime(100)) // take every x ms..
        .subscribe(
          e => this.deviceMotionService.motionHandler(e),
          err => console.log(err)
        )
      )

      // window.addEventListener('devicemotion', this.deviceMotionService.getMotionHandlerFn());
      this.acceleration$ = this.deviceMotionService.accelerationManager.realtimeData$;


      // const accelerometer = new Accelerometer({frequency: 60});
      // accelerometer.start();

      // var reading = function onreading(event) {
      //   console.log({
      //     timestamp: event.timeStamp,
      //     x: accelerometer.x,
      //     y: accelerometer.y,
      //     z: accelerometer.z
      //   });
      // }

      // accelerometer.addEventListener('reading', reading);

  }


  ngOnDestroy() {
    this.subs.unsubscribe();
  }

}

