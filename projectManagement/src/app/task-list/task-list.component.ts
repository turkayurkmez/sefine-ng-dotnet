import { Component, Input, OnInit } from '@angular/core';
import { Task } from '../models/task.model';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {

  
  ngOnInit(): void {
   console.log("ngOnInit metodu çalıştı....")
  }

  @Input('allTasks') tasks?: Task[];



}
