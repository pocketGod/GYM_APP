import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { map } from 'rxjs/operators';
import { LoginRequest, LoginResponse, RegisterRequest } from 'src/app/models/auth/AuthApi.model';
import { HttpHandlerService } from 'src/app/shared/services/http-handler.service';

@Injectable({
  providedIn: 'root'
})

export class AuthService extends HttpHandlerService {

  private baseAuthURL = 'Auth'; 

  login(username: string, password: string): Observable<LoginResponse> {
    const body: LoginRequest = { Username: username, Password: password };
    return this.post(`${this.baseAuthURL}/Sign_In`, body).pipe(
      map(response => response as LoginResponse),
      tap(result => {
        if (result && result.Token) {
          localStorage.setItem('auth_token', result.Token);
        }
      })
    );
  }
  
  register(username: string, password: string): Observable<LoginResponse> {
    const body: RegisterRequest = { Username: username, Password: password };
    return this.post(`${this.baseAuthURL}/Sign_Up`, body).pipe(
      map(response => response as LoginResponse),
      tap(result => {
        if (result && result.Token) {
          localStorage.setItem('auth_token', result.Token);
        }
      })
    );
  }
  
}
