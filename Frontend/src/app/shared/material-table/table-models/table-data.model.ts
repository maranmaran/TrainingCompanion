import { CustomColumn } from './custom-column.model';

export class TableData<T> {
    columnSetup: CustomColumn[];
    data: T[];
}


