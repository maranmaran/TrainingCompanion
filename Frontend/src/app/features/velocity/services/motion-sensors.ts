export const slot = window["__sensor__"] = "__sensor__";

export const SensorState = {
  ERROR: 0,
  IDLE: 1,
  ACTIVATING: 2,
  ACTIVE: 3,
}

export function defineReadonlyProperties(target, slot, descriptions) {
  const propertyBag = target[slot] || (target[slot] = new WeakMap);
  for (const property in descriptions) {
    propertyBag[property] = descriptions[property];
    Object.defineProperty(target, property, {
      get: () => propertyBag[property]
    });
  }
}

export function defineOnEventListener(target, name) {
  Object.defineProperty(target, `on${name}`, {
    enumerable: true,
    configurable: false,
    writable: true,
    value: null
  });
}

export class SensorErrorEvent extends Event {
  constructor(type, errorEventInitDict) {
    super(type, errorEventInitDict);

    if (!errorEventInitDict || !(errorEventInitDict.error instanceof DOMException)) {
      throw TypeError(
        "Failed to construct 'SensorErrorEvent':" +
        "2nd argument much contain 'error' property"
      );
    }

    Object.defineProperty(this, "error", {
      configurable: false,
      writable: false,
      value: errorEventInitDict.error
    });
  }
};

export class Sensor extends EventTarget {

  frequency: number = 60;

  constructor(options) {
    super();
    this[slot] = new WeakMap;

    defineOnEventListener(this, "reading");
    defineOnEventListener(this, "activate");
    defineOnEventListener(this, "error");

    defineReadonlyProperties(this, slot, {
      activated: false,
      hasReading: false,
      timestamp: null
    })

    this[slot].setState = (value) => {
      switch(value) {
        case SensorState.ERROR: {
          let error = new SensorErrorEvent("error", {
            error: new DOMException("Could not connect to a sensor")
          });
          this.dispatchEvent(error);

          this.stop(); // Moves to IDLE state.
          break;
        }
        case SensorState.IDLE: {
          this[slot].activated = false;
          this[slot].hasReading = false;
          this[slot].timestamp = null;
          break;
        }
        case SensorState.ACTIVATING: {
          break;
        }
        case SensorState.ACTIVE: {
          let activate = new Event("activate");
          this[slot].activated = true;
          this.dispatchEvent(activate);
          break;
        }
      }
    };

    this[slot].frequency = null;

    if (window && window.parent != window.top) {
      throw new DOMException("Only instantiable in a top-level browsing context", "SecurityError");
    }

    if (options && typeof(options.frequency) == "number") {
      if (options.frequency > 60) {
        this.frequency = options.frequency;
      }
    }
  }

  start() { }
  stop() { }
}

export const DeviceOrientationMixin = (superclass, ...eventNames) => class extends superclass {
  constructor(...args) {
    super(args);

    for (const eventName of eventNames) {
      if (`on${eventName}` in window) {
        this[slot].eventName = eventName;
        break;
      }
    }
  }

  start() {
    super.start();
    this[slot].setState(SensorState.ACTIVATING);
    window.addEventListener(this[slot].eventName, this[slot].handleEvent, { capture: true });
  }

  stop() {
    super.stop();
    this[slot].setState(SensorState.IDLE);
    window.removeEventListener(this[slot].eventName, this[slot].handleEvent, { capture: true });
  }
};

export class Accelerometer extends DeviceOrientationMixin(Sensor, "devicemotion") {
  constructor(options) {
    super(options);
    this[slot].handleEvent = event => {
      // If there is no sensor we will get values equal to null.
      if (event.accelerationIncludingGravity.x === null) {
        this[slot].setState(SensorState.ERROR);
        return;
      }

      if (!this[slot].activated) {
        this[slot].setState(SensorState.ACTIVE);
      }

      this[slot].timestamp = performance.now();

      this[slot].x = event.accelerationIncludingGravity.x;
      this[slot].y = event.accelerationIncludingGravity.y;
      this[slot].z = event.accelerationIncludingGravity.z;

      this[slot].hasReading = true;
      this.dispatchEvent(new Event("reading"));
    }

    defineReadonlyProperties(this, slot, {
      x: null,
      y: null,
      z: null
    });
  }

  stop() {
    super.stop();
    this[slot].x = null;
    this[slot].y = null;
    this[slot].z = null;
  }
}
