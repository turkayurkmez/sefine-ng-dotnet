import { Component } from '@angular/core';

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
}
