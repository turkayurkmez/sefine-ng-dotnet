import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private authService: AuthService, private router: Router) { }
  login(username: string, password: string): void {
    this.authService.login(username, password).subscribe({
      next: () => {
        console.log('Giriş başarılı');
        this.router.navigate([this.authService.returnUrl]); // Giriş başarılıysa gidilmek istenen URL'ye yönlendir
      },
      error: (error: Error) => {
        console.error('Giriş başarısız:', error);
        alert('Giriş başarısız: ' + error.message);
      }
    });

  }

}
