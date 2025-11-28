import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs';
import { Project } from '../models/project.model';
import { projects } from '../models/mocks/projects.mock';
import { HttpClient } from '@angular/common/http';

//beni enjekte edebilirsin:
@Injectable({
  //providedIn: nerede enjekte edilecegini belirtiriz.
  providedIn: 'root'
})
export class ProjectService {

  
  constructor(private httpClient: HttpClient) {   

  }

  getProjects(): Observable<Project[]> {
    return this.httpClient.get<Project[]>('https://localhost:7110/api/Projects/with-tasks');
  }
}
