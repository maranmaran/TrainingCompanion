import { EventEmitter } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatTableDataSource } from '@angular/material/table';
import * as _ from 'lodash-es';
import { BehaviorSubject, Subject } from 'rxjs';
import { PagingModel } from './paging.model';

interface Entity {
  id: string
}

export class TableDatasource<T extends Entity> extends MatTableDataSource<T> {
  // tslint:disable-next-line:variable-name
  private _internalData: T[];
  
  public selection = new SelectionModel<string>(true, []);
  public selectionEvent = new EventEmitter<T>()

  constructor(private initData: T[], private initSelectedElement: T = null) {
    super();
    this._internalData = _.cloneDeep(this.initData);
    this.data = _.cloneDeep(initData);

    if(initSelectedElement) {
      this.selectElement(initSelectedElement);
    }
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

  selectElement(element: T, keepSelected: boolean = false) {

    // Null element -> clear selection
    if (!element) {
      this.selection.clear();
      return this.selectionEvent.emit(null);
    }
    
    var elementAlreadySelected = this.selection.isSelected(element.id);

    // New selection
    if(!elementAlreadySelected) {
      this.selection.clear();
      this.selection.toggle(element.id);
      return this.selectionEvent.emit(element);
    }

    // don't keep it selected
    if(!keepSelected) {
      this.selection.clear();
      return this.selectionEvent.emit(null);
    }
    
    // keep it selected.. ie do nothing
  }
}
