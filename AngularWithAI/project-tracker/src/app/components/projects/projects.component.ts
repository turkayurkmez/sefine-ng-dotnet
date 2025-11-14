import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Department } from '../../models/department.model';
import { Project, ProjectStats } from '../../models/project.model';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {
  department: Department | undefined;
  projects: Project[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const departmentId = +params['departmentId'];
      this.department = this.dataService.getDepartmentById(departmentId);
      if (this.department) {
        this.projects = this.department.projects;
      }
    });
  }

  viewTasks(projectId: number): void {
    this.router.navigate(['/projects', projectId, 'tasks']);
  }

  getProjectStats(projectId: number): ProjectStats | undefined {
    return this.dataService.getProjectStats(projectId);
  }

  goBack(): void {
    this.router.navigate(['/departments']);
  }
}
