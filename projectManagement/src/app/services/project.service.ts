import { Injectable } from '@angular/core';
import { from, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Project } from '../models/project.model';
import { projects } from '../models/mocks/projects.mock';
import { HttpClient } from '@angular/common/http';

//beni enjekte edebilirsin:
@Injectable({
  //providedIn: nerede enjekte edilecegini belirtiriz.
  providedIn: 'root',
})
export class ProjectService {
  constructor(private httpClient: HttpClient) {}

  getProjects(): Observable<Project[]> {
    return this.httpClient.get<Project[]>(
      'https://localhost:7110/api/Projects/with-tasks'
    );
  }

  createProject(project: Project): Observable<Project> {
    //header ve options ayararını yaptıktan sonra hata alacak biçimde post isteği gönder:
    let headers = { 'Content-Type': 'application/json',
                     'Authorization':'Basic '+ btoa('user1:password123')
     };
    let options = { headers: headers };
    return this.httpClient
      .post<Project>('https://localhost:7110/api/Projects', project, options)
      .pipe(
        catchError(() =>
          throwError(() => new Error('Proje oluşturulurken bir hata oluştu'))
        )
      );
  }
}
