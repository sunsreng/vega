import { Component, Input, Output, EventEmitter } from '@angular/core';
import { OnChanges } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnChanges {
  // tslint:disable-next-line:no-input-rename
  @Input('total-items') totalItems;
  // tslint:disable-next-line:no-input-rename
  @Input('page-size') pageSize = 10;
  // tslint:disable-next-line:no-output-rename
  @Output('page-changed') pageChanged = new EventEmitter();
  pages: any[];
  currentPage = 1;

  ngOnChanges() {
    this.currentPage = 1;

    const pagesCount = Math.ceil(this.totalItems / this.pageSize);
    this.pages = [];
    // tslint:disable-next-line:curly
    for (let i = 1; i <= pagesCount; i++)
      this.pages.push(i);
  }

  changePage(page) {
    this.currentPage = page;
    this.pageChanged.emit(page);
  }

  previous() {
    // tslint:disable-next-line:curly
    if (this.currentPage === 1)
      return;

    this.currentPage--;
    this.pageChanged.emit(this.currentPage);
  }

  next() {
    // tslint:disable-next-line:curly
    if (this.currentPage === this.pages.length)
      return;

    this.currentPage++;
    this.pageChanged.emit(this.currentPage);
  }
}
