export class TableConfig {

  actionsEnabled = true;
  selectionEnabled = true;
  filterEnabled = true;
  addEnabled = true;
  editManyEnabled = false;
  deleteManyEnabled = true;
  disableManyEnabled = true;
  editEnabled = true;
  deleteEnabled = false;
  disableEnabled = true;
  enableDragAndDrop = false;

  pageSize = PAGE_SIZE;
  pageSizeOptions = PAGE_SIZE_OPTIONS;
  serverSidePaging = false;

  filterFunction: (data: any, filter: string) => boolean;

  public constructor(init?: Partial<TableConfig>) {
    Object.assign(this, init);
  }
}

export const PAGE_SIZE = 5;
export const PAGE_SIZE_OPTIONS = [5, 10, 15];
