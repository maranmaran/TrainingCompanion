import { Observable, ReplaySubject, Subject, Subscription } from 'rxjs';
import { round } from 'src/business/utils/utils';


export class DeviceRotationRecord {
  alpha: number;
  beta: number;
  gamma: number;

  constructor(alpha, beta, gamma) {
    this.alpha = alpha;
    this.beta = beta;
    this.gamma = gamma;
  }
}

export class DeviceAccelerationRecord {
  X: number;
  Y: number;
  Z: number;

  constructor(x, y, z) {
    this.X = x;
    this.Y = y;
    this.Z = z;
  }
}

export class MinMaxVerticalAccelerationCalculator {

  private _dataSubscription: Subscription;
  snapshotData: { min: number, max: number, total: number}[] = [];

  constructor(data: Observable<DeviceAccelerationRecord>) {
    this.reset();

    this._dataSubscription = data.subscribe(data => {
      if(data.Y < this._min)
        this._min = data.Y;

      if(data.Y > this._max)
        this._max = data.Y;
    });
  }

  private _min: number;
  private _max: number;
  private get _total() {
    return this._max - this._min
  }

  public get result() {
    return { min: round(this._min, 2), max: round(this._max, 2), total: round(this._total, 2)};
  }

  snapshot(result) {
    this.snapshotData.push(result);
  }

  reset() {
    this._min = 0;
    this._max = 0;
  }

  destroy() {
    this._dataSubscription.unsubscribe();
  }
}

export class DeviceAccelerationData {

  stream = new ReplaySubject<DeviceAccelerationRecord>(10);

  clear = () => {
  }

  update = (x, y, z) => {
    this.stream.next(new DeviceAccelerationRecord(x, y, z));
  }

}

export class DeviceRotationData {

  stream = new ReplaySubject<DeviceRotationRecord>(10);

  clear = () => {
  }

  update = (alpha, beta, gamma) => {
    this.stream.next(new DeviceRotationRecord(alpha, beta, gamma));
  }
}

export class DeviceAccelerationManager {

  private _data = new DeviceAccelerationData();
  private _minMax$ = new Subject<{min: number, max: number; total: number}>();

  private calculator = new MinMaxVerticalAccelerationCalculator(this.data$);

  onAccelerationChange(x, y, z) {
    this._data.update(x, y, z);
    this._minMax$.next(this.calculator.result);
  }

  recordCalculator(result) {
    this.calculator.snapshot(result);
  }

  resetCalculator() {
    this.calculator.reset();
  }

  public get data$() {
    return this._data.stream.asObservable();
  }

  public get minMax$() {
    return this._minMax$.asObservable();
  }

  public get snapshotData() {
    return this.calculator.snapshotData;
  }

  destroy() {
    this.calculator.destroy();
  }

}

export class DeviceRotationManager {

  private _data = new DeviceRotationData();

  onRotationChange(alpha, beta, gamma) {
    this._data.update(alpha, beta, gamma);
  }

  public get data$() {
    return this._data.stream.asObservable();
  }

  destroy() {

  }
}

export class DeviceMotionService {

  private _motionHandlerFn: any;
  private _accelerationManager: DeviceAccelerationManager;
  private _rotationManager: DeviceRotationManager;

  constructor() {
    this._motionHandlerFn = this.motionHandler.bind(this);

    this._accelerationManager = new DeviceAccelerationManager();
    this._rotationManager = new DeviceRotationManager();
  }

  public getMotionHandlerFn() {
    return this._motionHandlerFn;
  }

  private motionHandler(event) {
    this._accelerationManager.onAccelerationChange(event.acceleration.x, event.acceleration.y, event.acceleration.z)
    this._rotationManager.onRotationChange(event.rotationRate.alpha, event.rotationRate.beta, event.rotationRate.gamma)
  }

  accelerationSnapshot(result) {
    this._accelerationManager.recordCalculator(result);
  }

  accelerationReset() {
    this._accelerationManager.resetCalculator();
  }

  public get acceleration$() {
    return this._accelerationManager.data$;
  }

  public get minMax$() {
    return this._accelerationManager.minMax$;
  }

  public get accelerationSnapshotData() {
    return this._accelerationManager.snapshotData;
  }

  public get rotation$() {
    return this._rotationManager.data$;
  }

  public destroy() {
    this._accelerationManager.destroy();
    this._rotationManager.destroy();
  }

}
