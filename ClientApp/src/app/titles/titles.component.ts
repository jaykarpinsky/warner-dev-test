import { Component, Inject, OnInit, ViewChild } from '@angular/core';
// import { HttpClient, HttpParams } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

import { Title } from './title';
import { TitleService } from './title.service';
import { ApiResult } from '../base.service';

@Component({
  selector: 'app-titles',
  templateUrl: './titles.component.html',
  styleUrls: ['./titles.component.css']
})
export class TitlesComponent implements OnInit {
  public displayedColumns: string[] = ['titleName', 'releaseYear'];
  public titles: MatTableDataSource<Title>;

  defaultPageIndex: number = 0;
  defaultPageSize: number = 10;
  public defaultSortColumn: string = "titleNameSortable";
  public defaultSortOrder: string = "asc";

  defaultFilterColumn: string = "titleName";
  filterQuery: string = null;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  filterTextChanged: Subject<string> = new Subject<string>();

  constructor(
    private titleService: TitleService) {
  }

  ngOnInit() {
    this.loadData(null);
  }

  // debounce filter text changes
  onFilterTextChanged(filterText: string) {
    if (this.filterTextChanged.observers.length === 0) {
      this.filterTextChanged
        .pipe(debounceTime(200), distinctUntilChanged())
        .subscribe(query => {
          this.loadData(query);
        });
    }
    this.filterTextChanged.next(filterText);
  }

  loadData(query: string = null) {
    var pageEvent = new PageEvent();
    pageEvent.pageIndex = (this.paginator) ? this.paginator.pageIndex : this.defaultPageIndex;
    pageEvent.pageSize = (this.paginator) ? this.paginator.pageSize : this.defaultPageSize;
    this.filterQuery = query;  
    this.getData(pageEvent);
  }

  getData(event: PageEvent) {

    var sortColumn = (this.sort)  ? this.sort.active : this.defaultSortColumn;

    var sortOrder = (this.sort) ? this.sort.direction : this.defaultSortOrder;

    var filterColumn = (this.filterQuery) ? this.defaultFilterColumn  : null;

    var filterQuery = (this.filterQuery) ? this.filterQuery : null;

    this.titleService.getData<ApiResult<Title>>(
      event.pageIndex,
      event.pageSize,
      sortColumn,
      sortOrder,
      filterColumn,
      filterQuery)
      .subscribe(result => {
        this.paginator.length = result.totalCount;
        this.paginator.pageIndex = result.pageIndex;
        this.paginator.pageSize = result.pageSize;
        this.titles = new MatTableDataSource<Title>(result.data);
      }, error => console.error(error));
  }
}
