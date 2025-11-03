import { Component } from '@angular/core';
import { TodoItem } from './models/todoItem.model';
import { todoList } from './models/todoItem.mock';

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

  todoList: TodoItem[] = todoList;

  textData:string ='';
  
  /**
   *
   */
  constructor() {
    this.myTodoItem.task='Çiçekleri sula';
    
  }

  getInCompletedItemsCount(): number{

    //todoList array'i içindeki isDone özelliği true olanları filtrele ve
    //eleman sayısını döndür.

    return todoList.filter(t => !t.isDone).length;

  }

  isAllTaskDisplayed: boolean = true;
  customButtonText:string = 'Yapılan işleri gizle';

  filter():void{
    console.log('tıklandı...');
    this.isAllTaskDisplayed = !this.isAllTaskDisplayed;
    //tüm yapılacaklar gösterilecekse, tüm kloleksiyonu getir, sadece yapılmamış olanlar gösterilecekse filtrele.
   this.isAllTaskDisplayed ? this.todoList = todoList : 
                             this.todoList =  this.todoList.filter(t => !t.isDone);

   this.isAllTaskDisplayed ? this.customButtonText = 'Yapılan işleri gizle': 
                             this.customButtonText = 'Tüm görevleri göster';
  }

  getButtonText():string{
    return this.isAllTaskDisplayed ? 'Yapılan işleri gizle':'Tüm görevleri göster';
  }


}
