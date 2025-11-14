import { Injectable } from '@angular/core';
import { Department } from '../models/department.model';
import { departments } from '../models/mocks/departments.mock';
import { Observable, from } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  // departmentList: Observable<Department[]>;

  url: string = 'https://localhost:7110/api/Departments';

  constructor(private httpClient: HttpClient) {
    //bir koleksiyonu observable a çevirmek için from isimli rxjs operatörünü kullandık:
    //this.departmentList = from([departments]);
  }
  getDepartments(): Observable<Department[]> {
    //return this.departmentList;
    return this.httpClient.get<Department[]>(this.url);
  }
}
