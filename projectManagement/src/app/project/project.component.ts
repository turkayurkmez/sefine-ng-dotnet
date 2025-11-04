import { AfterContentChecked, Component, Input, OnInit } from '@angular/core';
import { Project } from '../models/project.model';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit, AfterContentChecked {

  incompletedTasksCount?: number;
  isTasksFound? :boolean;


    
   @Input('activeProject') project? : Project

   constructor(){
     this.incompletedTasksCount = this.project?.tasks?.filter(tk => !tk.isDone).length;
     console.log(this.incompletedTasksCount);
   }
  ngAfterContentChecked(): void {
        this.incompletedTasksCount = this.project?.tasks?.filter(tk => !tk.isDone).length;
        this.isTasksFound = this.incompletedTasksCount != undefined && this.incompletedTasksCount > 0;
  }
  ngOnInit(): void {
     this.incompletedTasksCount = this.project?.tasks?.filter(tk => !tk.isDone).length;
     console.log(this.incompletedTasksCount);
  }

  isSelectAll?: boolean = false

  selectAll(){

    this.isSelectAll = !this.isSelectAll;    
    this.project?.tasks?.map(x=>x.isDone = this.isSelectAll);
   
  }

}
