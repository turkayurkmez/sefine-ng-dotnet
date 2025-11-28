import { Injectable } from '@angular/core';
import { Department } from '../models/department.model';
import { departments } from '../models/mocks/departments.mock';
import { Observable, catchError, from, map, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  // departmentList: Observable<Department[]>;

  url: string = 'https://localhost:7110/api/Departments';

  constructor(private httpClient: HttpClient, private authService: AuthService) {
    //bir koleksiyonu observable a çevirmek için from isimli rxjs operatörünü kullandık:
    //this.departmentList = from([departments]);
  }
  getDepartments(): Observable<Department[]> {
    //return this.departmentList;
    return this.httpClient.get<Department[]>(this.url);
  }

  getDepartmentById(id: number): Observable<Department> {
    return this.httpClient.get<Department>(`${this.url}/${id}`);
    
  }
  addDepartment(department: Department): Observable<Department> 
  {
     let headers = { 'Content-Type': 'application/json',
                     'Authorization':'Bearer '+ this.authService.getToken() };
     let options = { headers: headers };

      return this.httpClient.post<Department>(this.url, department, options)
                 .pipe(
                  map((response: Department) => {
                    console.log('Departman başarıyla eklendi:', response);
                    return response;
                  }),
                  catchError((error:HttpErrorResponse)=>{
                    console.error('Departman eklenirken bir hata oluştu:', error);
                    console.error('Hata detayı:', error.message);
                    console.error('Hata kodu:', error.status);
                    return throwError(()=>new Error(error.statusText));
                  })
                 )
  }


}
