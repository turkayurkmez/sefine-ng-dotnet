import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectListComponent } from './project-list/project-list.component';
import { DepartmentMenuComponent } from './department-menu/department-menu.component';

const routes: Routes = [
  {path:'',component: ProjectListComponent},
  {path:'tumProjeler',component: ProjectListComponent},
  {path:'departmanlar',component: DepartmentMenuComponent},
  {path:'projeler/departman/:departmentId',component: ProjectListComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
