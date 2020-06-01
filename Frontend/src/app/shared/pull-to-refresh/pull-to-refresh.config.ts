export class RefreshConfig {

  constructor(config?: Partial<RefreshConfig>) {
    if(config) {
      Object.assign(this, config);
    }
  }

  indicatorRelativeHeight = 6;
  windowReload = true;
}
