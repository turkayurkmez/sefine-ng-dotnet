import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const loginGuard: CanActivateFn = (route, state) => {

  //1. Kullanıcının giriş yapıp yapmadığını kontrol et
  let authService = inject(AuthService);
  let router = inject(Router);

  authService.returnUrl = route.url.join('/');



  if (!authService.isLoggedIn()) {
   router.navigate(['login']);
   return false;
  }

  return true;

};
