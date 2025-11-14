import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs';
import { Project } from '../models/project.model';
import { projects } from '../models/mocks/projects.mock';

//beni enjekte edebilirsin:
@Injectable({
  //providedIn: nerede enjekte edilecegini belirtiriz.
  providedIn: 'root'
})
export class ProjectService {

  projectList: Observable<Project[]> ;
  constructor() { 
    this.projectList = from([projects]);

  }

  getProjects(): Observable<Project[]> {
    return this.projectList;
  }
}
