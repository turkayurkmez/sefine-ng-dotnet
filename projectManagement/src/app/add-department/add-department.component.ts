import { Component } from '@angular/core';
import { Department } from '../models/department.model';
import { NgForm } from '@angular/forms';
import { DepartmentService } from '../services/department.service';

@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.css']
})
export class AddDepartmentComponent {

  department: Department = new Department();

  constructor(private departmentService: DepartmentService) { }

  submitDepartment(form:NgForm):void{
    if(form.valid){
       console.log(form.value);
       this.department = form.value;

       this.departmentService.addDepartment(this.department).subscribe({
        next:(data: Department)=>{
          console.log('Yeni departman eklendi:', data);
          alert('Yeni departman başarıyla eklendi: ' + data.name);
          form.resetForm();
        },
        error:(error:Error)=>{
          console.error('Departman eklenirken hata oluştu!!!:', error);
        }
       })
    }
  }

}
