import { Component, OnInit } from '@angular/core';
import { Project } from '../models/project.model';
import { projects } from '../models/mocks/projects.mock';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {

  constructor(private route: ActivatedRoute) {}



  ngOnInit(): void {
    console.log(this.route.params);

    this.route.params.subscribe(value =>{ 
      console.log(value['departmentId']);
      if(value['departmentId']){
        this.filteredProjects = this.allProjects?.filter(prj => prj.departmentId == +value['departmentId']);
      }
      else{
        this.filteredProjects = this.allProjects;
      }


    });
  }



   allProjects?: Project[] = projects;
   filteredProjects?: Project[] = this.allProjects;

   key: string = '';
   
}
