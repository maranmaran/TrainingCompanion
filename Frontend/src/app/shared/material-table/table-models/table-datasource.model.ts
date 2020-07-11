import { MatTableDataSource } from '@angular/material/table';
import * as _ from 'lodash-es';
import { BehaviorSubject } from 'rxjs';
import { PagingModel } from './paging.model';

export class TableDatasource<T> extends MatTableDataSource<T> {
  // tslint:disable-next-line:variable-name
  private _internalData: T[];

  constructor(private initData: T[]) {
    super();
    this._internalData = _.cloneDeep(this.initData);
    this.data = _.cloneDeep(initData);
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

  private _totalItems = new BehaviorSubject<number>(0);
  totalLength = () => this._totalItems.asObservable();
  setTotalLength(totalItems: number) {
    this._totalItems.next(totalItems);
  }

  private _pagingModel = new BehaviorSubject<PagingModel>(new PagingModel());
  pagingModel = () => this._pagingModel.asObservable()
  setPagingModel(model: PagingModel) {
    this._pagingModel.next(model);
  }
}
