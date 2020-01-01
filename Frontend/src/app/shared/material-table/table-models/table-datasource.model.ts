import { MatTableDataSource } from '@angular/material/table';
export class TableDatasource<T> extends MatTableDataSource<T> {
  // tslint:disable-next-line:variable-name
  private _internalData: T[];
  constructor(private initData: T[]) {
    super();
    this._internalData = this.initData;
    this.data = initData;
  }
  addElement(element: T) {
    this._internalData.push(element);
    this.data = this._internalData;
  }
  removeElement(element: T) {
    this._internalData.splice(this._internalData.findIndex(item => item === element), 1);
    this.data = this._internalData;
  }
  updateDatasource(elements: T[]) {
    this._internalData = elements;
    this.data = this._internalData;
  }
}
