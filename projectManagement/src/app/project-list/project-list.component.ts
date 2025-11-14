import { Component, OnInit } from '@angular/core';
import { Project } from '../models/project.model';
import { ActivatedRoute } from '@angular/router';
import { ProjectService } from '../services/project.service';


@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css'],
})
export class ProjectListComponent implements OnInit {
  constructor(private route: ActivatedRoute, private projectService: ProjectService) {}

  ngOnInit(): void {
    console.log(this.route.params);


//1. allprojects'i doldur:
      this.projectService.getProjects().subscribe(data=> {
      this.allProjects = data;
      console.log(this.allProjects);

    });

//2. route parametrelerini dinle. Eğer departmentId varsa filtrele:

    this.route.params.subscribe((value) => {
      console.log('route parametresi değişti');
      console.log(value['departmentId']);
      if (value['departmentId']) {
        this.filteredProjects = this.allProjects?.filter(
          (prj) => prj.departmentId == +value['departmentId']
        );
      } else {
        this.filteredProjects = this.allProjects;
      }
    });


  



  }
  allProjects?: Project[] = [];

  filteredProjects?: Project[] = this.allProjects;

  key: string = '';
}
