import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpHandlerService } from 'src/app/common/services/http-handler.service';
import { LoginRequest, LoginResponse, RegisterRequest } from 'src/app/models/auth/AuthApi.model';
import { ValidationType } from 'src/app/models/common/PatternValidations';

@Injectable({
  providedIn: 'root'
})

export class AuthService extends HttpHandlerService {

  validationTypes = {
    usernameValidationType:ValidationType.Username,
    passwordValidationType:ValidationType.Password
  }
  
  private baseAuthURL = 'Auth'; 

  login(username: string, password: string): Observable<LoginResponse> {
    const body: LoginRequest = { Username: username, Password: password };
    return this.post<LoginResponse>(`${this.baseAuthURL}/Sign_In`, body).pipe(
      tap(result => {
        if (result && result.token) {
          localStorage.setItem('user_auth_token', result.token);
        }
      })
    );
  }

  register(username: string, password: string): Observable<LoginResponse> {
    const body: RegisterRequest = { Username: username, Password: password };
    return this.post<LoginResponse>(`${this.baseAuthURL}/Sign_Up`, body).pipe(
      tap(result => {
        if (result && result.token) {
          localStorage.setItem('user_auth_token', result.token);
        }
      })
    );
  }
  
}
