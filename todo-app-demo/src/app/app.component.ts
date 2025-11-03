import { Component } from '@angular/core';
import { TodoItem } from './models/todoItem.model'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Başlık burada olacak';
  paragraph = "Bu da bir paragraf yazısı olacak";

  creator: string = 'Türkay Ürkmez'
  generatedDate: string = 'Kasım 2025' 

  isChecked:boolean = true;

  myTodoItem: TodoItem = new TodoItem('Çiçekleri sula',false);

  todoList: TodoItem[] = [
    new TodoItem('Angular Öğren',false),
    new TodoItem('.net ile api uygulaması geliştir',true),
    new TodoItem('DB oluştur',false)
  ];
  
  /**
   *
   */
  constructor() {
    this.myTodoItem.task='Çiçekleri sula';
    
  }


}
