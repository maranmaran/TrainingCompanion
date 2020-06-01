import { Subject } from 'rxjs';
import { round } from 'src/business/utils/utils';

export class DeviceAccelerationRecord {
  X: number;
  Y: number;
  Z: number;
  timestamp?: number

  constructor(x, y, z, timestamp = null) {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.timestamp = timestamp
  }
}

export class VelocityCalculator {

  velocityData: { v, a, t }[] = [];

  constructor() {
    this.velocityData.push({ v: 0, a: 0, t: 0})
  }

  calculate(acceleration) {

    const a = acceleration.Y;
    const v0 = this.velocityData[this.velocityData.length - 1].v;
    const t1 = this.velocityData[this.velocityData.length - 1].t;
    const t2 = acceleration.timestamp;

    const v = this.getVelocity(v0, t1, t2, a);
    this.velocityData.push({ v, a, t: t2 });

    console.log({ v, a, t2 });
  }

  getVelocity(v0, t1, t2, a) {
    return v0 + Math.abs(a) * Math.abs(t2 - t1);
  }

}

export class DeviceAccelerationManager {

  private _stream = new Subject<DeviceAccelerationRecord>();

  private calculator = new VelocityCalculator();

  onAccelerationChange(x, y, z, timestamp) {
    var acceleration = new DeviceAccelerationRecord(x, y, z, timestamp);
    this._stream.next(acceleration);
    this.calculator.calculate(acceleration);
  }

  public get realtimeData$() {
    return this._stream.asObservable();
  }

}

export class DeviceMotionService {

  accelerationManager = new DeviceAccelerationManager();

  motionHandler(event) {
    console.log(event);
    this.accelerationManager.onAccelerationChange(
      round(event.acceleration.x, 2),
      round(event.acceleration.y, 2),
      round(event.acceleration.z, 2),
      round(event.timeStamp / 1000, 2))
  }
}
