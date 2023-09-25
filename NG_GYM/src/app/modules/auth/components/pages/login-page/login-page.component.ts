import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginCredentials } from 'src/app/models/auth/Credentials.model';
import { GenericInputValue } from 'src/app/models/common/GenericInputValue.model';
import { ValidationType } from 'src/app/models/common/PatternValidations';
import { AuthService } from '../../../services/auth.service';
import { LoginResponse } from 'src/app/models/auth/AuthApi.model';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent {

  credentials:LoginCredentials = {
    user: {value:'', valid:false},
    pass: {value:'', valid:false}
  } 


  constructor(private router: Router, private authService: AuthService) {}

  navigateToAnalysis() {
    this.router.navigate(['/analysis/home']);
  }

  onSubmit() {
    if(this.credentials.user.valid && this.credentials.pass.valid){
      
      this.authService.login(this.credentials.user.value as string, this.credentials.pass.value as string)
        .subscribe(
          (response: LoginResponse) => {
                 
            if (response.isSuccess) {
              localStorage.setItem('user_auth_token', response.token);
              this.navigateToAnalysis();

            } else {
              console.log('Login failed:', response.error);
            }
          },
          (error) => {
            console.log('An error occurred:', error); // API error
          }
        );
    }
    else{
      console.log('invalid credentials', this.credentials);
    }
  }
  
}
