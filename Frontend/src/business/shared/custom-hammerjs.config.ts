import { HammerGestureConfig } from '@angular/platform-browser';

export class CustomHammerJsConfig extends HammerGestureConfig {
  options = {
    domEvents: true
  };
}
