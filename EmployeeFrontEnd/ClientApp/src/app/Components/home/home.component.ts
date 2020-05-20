import { Component } from '@angular/core';
import { Employee } from '../../Models/Employee'
import { DropdownValue } from '../../Models/dropdownvalue';
import { EmployeeService } from '../../services/employee.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public EmployeesArr: Employee[];
  employeeService: EmployeeService;
  searchParam: string;
  total: number;
  columnName: number = 0;
  public values: Array<DropdownValue>=[];
  constructor(_empSer: EmployeeService) {
    this.employeeService = _empSer;
    this.values.push({ value: "0", label: "Filter By" });
    this.values.push({ value: "1", label: "First Name" });
    this.values.push({ value: "2", label: "Last Name" });
    this.values.push({ value: "3", label: "Email" });
    this.values.push({ value: "4", label: "Job Title" });
    this.values.push({ value: "5", label: "Phone Number" });
    this.values.push({ value: "6", label: "Hire Date" });
    this.values.push({ value: "7", label: "Any" });
  }
  searchForEmployee() {
    if (this.columnName != 0) {

      this.employeeService.getEmployeesByColumn(this.values[this.columnName].label, this.searchParam, 'asc').subscribe(result => {
        
        this.EmployeesArr = result as Employee[];
       
        this.total = this.EmployeesArr.length;
      }
      );
    }
  }
  select(columnName: number) {
    this.columnName = columnName;
  }
}
