import { SortDirection } from '@angular/material/sort';
import { PAGE_SIZE } from './table-config.model';

export class PagingModel {
  page: number = 0;
  pageSize: number = PAGE_SIZE;
  filterQuery: string;
  sortBy: string;
  sortDirection: SortDirection;
  fetchAll: boolean = false;
  itemId: string;

  constructor(data?: Partial<PagingModel>) {
    Object.assign(this, data);
  }
}
