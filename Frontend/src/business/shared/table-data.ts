import { MatTableDataSource } from '@angular/material/table';

export interface TableData<T> {
    columnSetup: CustomColumn[]
    data: T[];
}

export interface CustomColumn {
    definition: string,
    title: string,
    displayFunction: Function,
    sort: boolean
}

export class TableConfig {
    actionsEnabled = true;
    selectionEnabled = true;
    addEnabled = true;
    deleteEnabled = true;
    editEnabled = true;
    pageSize = 5;

    public constructor(init?:Partial<TableConfig>) {
        Object.assign(this, init);
    }
}

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
} {}