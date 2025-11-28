import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Department } from '../models/department.model';
import { DepartmentService } from '../services/department.service';
import { ProjectService } from '../services/project.service';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css'],
})
export class AddProjectComponent implements OnInit {
  constructor(private formBuilder: FormBuilder, 
              private departmentService: DepartmentService,
              private projectService: ProjectService

            ) {}

  addProjectForm!: FormGroup;

  departments$ = this.departmentService.getDepartments();

  ngOnInit(): void {
    //kurallar:
    this.addProjectForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      description: ['', [Validators.required]],
      departmentId: ['', [Validators.required]],
      startDate: ['']
    });
  }

  checkName(): boolean | undefined {
    return (
      this.addProjectForm.get('name')?.hasError('required') &&
      this.addProjectForm.get('name')?.dirty
    );
  }

  checkNameLength(): boolean | undefined {
    return (
      this.addProjectForm.get('name')?.hasError('minlength') &&
      this.addProjectForm.get('name')?.dirty
    );
  }

  checkDescription(): boolean | undefined {
    return (
      this.addProjectForm.get('description')?.hasError('required') &&
      this.addProjectForm.get('description')?.dirty
    );
  }

  checkDepartment(): boolean | undefined {
    return (
      this.addProjectForm.get('departmentId')?.hasError('required') &&
      this.addProjectForm.get('departmentId')?.touched
    );
  }

  createProject(): void {
    if (this.addProjectForm.valid) {
      console.log('DİKKAT: form nesnesi:',this.addProjectForm.value);
      //servise gönderme işlemi burada yapılacak
      this.projectService.createProject(this.addProjectForm.value).subscribe({
        next:(data)=>{
          console.log('Yeni proje eklendi:', data);
          alert('Yeni proje başarıyla eklendi: ' + data.name);
          this.addProjectForm.reset();
        },
        error:(error:Error)=>{
          console.error('Proje eklenirken hata oluştu!!!:', error);
        }
      })
    }
  } 
}
