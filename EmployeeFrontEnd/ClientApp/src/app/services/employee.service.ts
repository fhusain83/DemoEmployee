import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Employee } from '../Models/Employee';
import { Observable } from 'rxjs/internal/Observable';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs/internal/observable/of';
@Injectable()
export class EmployeeService
{
  http: HttpClient;
  employees: Employee[];
  constructor(_http: HttpClient) {
    this.http = _http;
  }

  getEmployeesByColumn(columnName: string, searchParam: string, sortOrder: string): Observable<Employee[]> {
    let params = new HttpParams()
    .set("columnName", columnName)
    .set("searchParam", searchParam)
    .set("sortOrder", sortOrder);
    return this.http.get<Employee[]>("https://localhost:44372/DemoEmployee", { params: params }).
      pipe(catchError(this.handleError<Employee[]>('getemployee', [])));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
