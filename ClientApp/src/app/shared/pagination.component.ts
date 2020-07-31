import { Component, OnChanges, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'pagination',
  template: `
  <div class="card-tools">
  <nav aria-label="Page navigation example" *ngIf="totalItems > pageSize">
  <ul class="pagination justify-content-end mb-0">
    <li class="page-item" [class.disabled]="currentPage == 1"><a class="page-link"  (click)="previous()">Previous</a></li>
    <li class="page-item" [class.active]="currentPage == page" *ngFor="let page of pages" ><a class="page-link" (click)="changePage(page)">{{ page }}</a></li>
 
    <li class="page-item" [class.disabled]="currentPage == pages.length"><a class="page-link" (click)="next()">Next</a></li>
  </ul>
</nav>
  </div>
`,
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnChanges {
    @Input('total-items') totalItems;
    @Input('page-size') pageSize = 2;
    @Output('page-changed') pageChanged = new EventEmitter();
    pages: any[];
    currentPage = 1; 
  
    ngOnChanges(){
      this.currentPage = 1;
          
      var pagesCount = Math.ceil(this.totalItems / this.pageSize); 
      this.pages = [];
      for (var i = 1; i <= pagesCount; i++)
        this.pages.push(i);
  
      console.log(this);
    }
  
    changePage(page){
      this.currentPage = page; 
      this.pageChanged.emit(page);
    }
  
    previous(){
      if (this.currentPage == 1)
        return;
  
      this.currentPage--;
      this.pageChanged.emit(this.currentPage);
    }
  
    next(){
      if (this.currentPage == this.pages.length)
        return; 
      
      this.currentPage++;
      console.log("next", this);
      this.pageChanged.emit(this.currentPage);
    }
  }
