import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TodoItem } from '../models/todoItem.model';
import { TodoService } from '../services/todo.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {
   //url:'https://jsonplaceholder.typicode.com/todos';

   constructor(private todoService: TodoService) {}
 

   todoList: TodoItem[] = [];

 ngOnInit(): void {

    // this.http.get<TodoItem[]>('https://jsonplaceholder.typicode.com/todos')
    //          .subscribe(data=> this.todoList = data);
   
    this.todoService.getTodos()
        .subscribe(data => this.todoList = data);
  }


}
