export class CustomColumn {
  definition: string;
  title: string;
  displayFunction: Function;
  sort: boolean = false;
  displayOnMobile: boolean = true;
  headerClass?: string = '';
  cellClass?: string = '';
  useComponent: boolean = false;
  component: any;
  inputs: any;

  // why ? - Object initialization similar to c#.. because of default values
  public constructor(fields?: {
    definition?: string;
    title?: string;
    displayFunction?: Function;
    sort?: boolean;
    displayOnMobile?: boolean;
    headerClass?: string;
    cellClass?: string;
    useComponent?: boolean;
    component?: any;
    inputs?: any;
  }) {
    if (fields)
      Object.assign(this, fields);
  }
}
