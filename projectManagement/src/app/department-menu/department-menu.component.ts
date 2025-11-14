import { Component, OnInit } from '@angular/core';
import { Department } from '../models/department.model';
import { DepartmentService } from '../services/department.service';

@Component({
  selector: 'app-department-menu',
  templateUrl: './department-menu.component.html',
  styleUrls: ['./department-menu.component.css']
})
export class DepartmentMenuComponent implements OnInit {

  constructor(private departmentService: DepartmentService){}

  //bileşen yüklendiğinde departmanları al
   ngOnInit(): void {
     this.departmentService.getDepartments().subscribe(data=> this.departments = data);
   }
   departments: Department[] = [];

}
