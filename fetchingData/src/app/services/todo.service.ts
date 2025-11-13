import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TodoItem } from '../models/todoItem.model';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  constructor(private http: HttpClient) { }

  url: string = 'https://jsonplaceholder.typicode.com/todos';

  getTodos(): Observable<TodoItem[]> {
    // Logic to fetch todo items can be added here
    return this.http.get<TodoItem[]>(this.url);

  }
}
