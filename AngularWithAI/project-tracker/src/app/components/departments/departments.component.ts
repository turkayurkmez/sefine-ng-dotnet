import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Department } from '../../models/department.model';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.css']
})
export class DepartmentsComponent implements OnInit {
  departments$!: Observable<Department[]>;

  constructor(
    private dataService: DataService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.departments$ = this.dataService.getDepartments();
  }

  viewProjects(departmentId: number): void {
    this.router.navigate(['/departments', departmentId, 'projects']);
  }

  getProjectCount(department: Department): number {
    return department.projects.length;
  }
}
