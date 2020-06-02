
export class TableConfig {

  filterEnabled = false;
  selectionEnabled = true;
  enableDragAndDrop = false;
  enableExpandableRows = false;
  actionsEnabled = true;

  pagingOptions = new TablePagingOptions();

  cellActions: TableAction[] = [TableAction.update, TableAction.disable]
  headerActions: TableAction[] = [TableAction.create]

  defaultSort: string;
  defaultSortDirection: 'asc' | 'desc';

  filterFunction: (data: any, filter: string) => boolean;

  // ndc dynamic component
  expandableRowComponent: any; // component reference
  expandableRowComponentInputs: Function = () => { }; // component inputs
  expandableRowComponentAttributes: any = {}; // attributes

  public get usesExpandableRows(): boolean {
    return !!this.enableExpandableRows && !!this.expandableRowComponent;
  }


  public constructor(init?: Partial<TableConfig>) {
    Object.assign(this, init);
  }
}

export class TablePagingOptions {
  pageSize = PAGE_SIZE;
  pageSizeOptions = PAGE_SIZE_OPTIONS;
  serverSidePaging = false;

  public constructor(init?: Partial<TablePagingOptions>) {
    Object.assign(this, init);
  }
}

export enum TableAction {
  create = "create",
  update = "update",
  updateMany = "updateMany",
  delete = "delete",
  deleteMany = "deleteMany",
  disable = "disable",
  disableMany = "disableMany",
  dummy = 'dummy'
}

export const PAGE_SIZE = 5;
export const PAGE_SIZE_OPTIONS = [5, 10, 15];
