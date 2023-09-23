import { CanActivateFn } from '@angular/router';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard {
  canActivate: CanActivateFn = (route, state) => {
    const token = localStorage.getItem('user_auth_token');
    if (token) {
      return true;
    }
    this.router.navigate(['/auth/login']);
    return false;
  };

  constructor(private router: Router) {}
}
