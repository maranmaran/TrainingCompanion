import { MatTableDataSource } from '@angular/material/table';

export class TableData<T> {
    columnSetup: CustomColumn[];
    data: T[];
}

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
    public constructor(
        fields?: {
            definition?: string;
            title?: string;
            displayFunction?: Function;
            sort?: boolean;
            displayOnMobile?: boolean;
            headerClass?: string ;
            cellClass?: string ;
            useComponent?: boolean;
            component?: any;
            inputs?: any;
        }) {

        if (fields) Object.assign(this, fields);
        
    }

}

export class TableConfig {
    actionsEnabled = true;
    selectionEnabled = true;
    addEnabled = true;
    deleteEnabled = true;
    editEnabled = true;
    enableDragAndDrop: boolean = false;
    pageSize = 5;
    filterFunction: (data: any, filter: string) => boolean

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