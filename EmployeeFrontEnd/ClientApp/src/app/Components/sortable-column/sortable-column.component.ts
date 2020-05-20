import { Component, OnInit, Input,Output, EventEmitter, OnDestroy, HostListener } from '@angular/core';
import { SortEvent } from '../../Models/SortEvent';
@Component({
  selector: 'sortable-column',
  templateUrl: './sortable-column.component.html'
})
export class SortableColumnComponent implements OnInit {

  constructor() {
    this.sortDirection = 'asc';
  }
  @Output() sortEvent = new EventEmitter<SortEvent>();
  @Input('sortable-column')
  columnName: string;

  @Input('sort-direction')
  sortDirection: string = 'asc';

  @HostListener('click')
  sort() {
    
    this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    this.sortEvent.emit({ column: this.columnName, direction: this.sortDirection });
  }

  ngOnInit() {
    this.sortDirection='asc';
  }
}

