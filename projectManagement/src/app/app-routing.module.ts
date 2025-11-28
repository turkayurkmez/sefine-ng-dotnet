import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectListComponent } from './project-list/project-list.component';
import { DepartmentMenuComponent } from './department-menu/department-menu.component';
import { AddDepartmentComponent } from './add-department/add-department.component';
import { AddProjectComponent } from './add-project/add-project.component';
import { loginGuard } from './login/login.guard';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path:'',component: ProjectListComponent},
  {path:'tumProjeler',component: ProjectListComponent},
  {path:'departmanlar',component: DepartmentMenuComponent},
  {path:'projeler/departman/:departmentId',component: ProjectListComponent},
  {path:'addDepartment',component: AddDepartmentComponent, canActivate:[loginGuard] },
  {path:'addProject',component: AddProjectComponent, canActivate:[loginGuard] },
  {path:'login',component:LoginComponent}
    
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
