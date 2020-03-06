export class CustomColumn {
  definition: string;
  title: string;

  displayOnMobile: boolean = true;
  headerClass?: string = '';
  cellClass?: string = '';
  displayFn: Function;

  sort: boolean = false;
  sortFn: Function;
  defaultSort: boolean = false;
  sortAsc: 'asc' | 'desc';

  tooltip: string = null;

  useComponent: boolean = false;
  component: any;
  componentInputs: any;

  // why ? - Object initialization similar to c#.. because of default values
  public constructor(fields?: {
    definition?: string;
    title?: string;
    displayFn?: Function;
    sort?: boolean;
    defaultSort?: boolean;
    sortAsc?: string;
    sortFn?: Function;
    displayOnMobile?: boolean;
    headerClass?: string;
    cellClass?: string;
    useComponent?: boolean;
    component?: any;
    componentInputs?: any;
  }) {
    if (fields)
      Object.assign(this, fields);
  }
}
