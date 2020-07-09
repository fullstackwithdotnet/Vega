import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {

  // tslint:disable-next-line: no-input-rename
  @Input('total-items') totalItems: any;
  // tslint:disable-next-line: no-input-rename
  @Input('page-size') pageSize: any;
  noOfPages: any;

  // tslint:disable-next-line:no-input-rename
  // tslint:disable-next-line:no-output-rename
  @Output('page-changed') pageChanged: EventEmitter<number> = new EventEmitter();
  pagesArray: number[];

  constructor() { }

  ngOnInit() {
    console.log(this.totalItems);
    let pages = this.totalItems / this.pageSize;
    const remainder = this.totalItems % this.pageSize;
    if (remainder > 0) {
      pages++;
    }
    this.noOfPages = Math.round(pages);
    let xx = 0;
    this.pagesArray = new Array();
    while (xx < this.noOfPages) {
      ++xx;
      this.pagesArray.push(xx);
    }
  }
  OnPageClick(event) {
    this.pageChanged.emit(event.target.text);
  }

}
