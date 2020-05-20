import { Component, Inject, Input, Output } from '@angular/core';
import { QueryList, ViewChildren } from '@angular/core';
import { DecimalPipe } from '@angular/common';
import { EmployeeService } from '../../services/employee.service';
import { SortEvent } from '../../Models/SortEvent';
import { Employee } from '../../Models/Employee';
import { EventEmitter } from 'protractor';
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})


export class FetchDataComponent {
  @Input() Employees: Employee[];
  @Input() total: number;

  currentPage = 1;
  itemsPerPage = 5;
  pageSize: number;
  
  sortDirection: string;
  employeeService: EmployeeService;

  constructor(_employeeService:EmployeeService) {
    this.sortDirection = 'asc';
    this.employeeService = _employeeService;
  }

 

  onSort({ column, direction }: SortEvent) {
   
    this.Employees.sort(this.dynamicSort(column,direction==='asc'?1:-1));
  }

  public onPageChange(pageNum: number): void {
    this.pageSize = this.itemsPerPage * (pageNum - 1);
  }

  public changePagesize(num: number): void {
    this.itemsPerPage = this.pageSize + num;
  }

  dynamicSort(property,direction) {
  var sortOrder = direction;
  return function (a, b) {
    /* next line works with strings and numbers, 
     * and you may want to customize it to your needs
     */
    var result = (a[property] < b[property]) ? -1 : (a[property] > b[property]) ? 1 : 0;
    return result * sortOrder;
  }
}
}


