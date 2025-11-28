import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

interface LoginResponse {
  token: string; 
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly TOKEN_KEY = 'auth_token';
  private readonly apiUrl = 'https://localhost:7110/api/accounts';



  constructor(private httpClient: HttpClient) { }

  login(username: string, password: string): Observable<LoginResponse> {
    const body = { username, password };
    return this.httpClient.post<LoginResponse>(`${this.apiUrl}`, body).pipe(
      tap(response => this.setToken(response.token))
    );
  }
  setToken(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
  }

  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }

  returnUrl: string ='/';
}
