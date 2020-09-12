import { HttpClient } from '@angular/common/http';

import { Injectable, Inject } from '@angular/core';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { exception } from 'console';

/*
 * credit goes to tutorial : https://dzone.com/articles/crud-operations-with-aspnet-core-using-angular-5-a
 **/
@Injectable()

export class EmployeeService {
  myAppUrl: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }
  getEmployees() {
    return this.http.get(this.myAppUrl + 'api/Employee/Index')
      .map((response: Response) => response.json())
      .catch((e) => this.handleError(e));
  }
  getEmployeeById(id: number) {
    return this.http.get(this.myAppUrl + "api/Employee/Details/" + id)
      .map((response: Response) => response.json())
      .catch((e) => this.handleError(e))
  }
  saveEmployee(employee) {
    return this.http.post(this.myAppUrl + 'api/Employee/Create', employee)
      .map((response: Response) => response.json())
      .catch((e) => this.handleError(e))
  }
  updateEmployee(employee) {
    return this.http.put(this.myAppUrl + 'api/Employee/Edit', employee)
      .map((response: Response) => response.json())
      .catch((e) => this.handleError(e));
  }
  deleteEmployee(id) {
    return this.http.delete(this.myAppUrl + "api/Employee/Delete/" + id)
      .map((response: Response) => response.json())
      .catch((e) => this.handleError(e));
  }
  handleError(error: Response) {
    console.log(error);
   throw exception();
  }
}
