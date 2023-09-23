import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss', '../login-page/login-page.component.scss']
})
export class RegisterPageComponent {

  credentials = {
    user: {value: '', valid: false},
    pass: {value: '', valid: false}
  };

  get usernameValidationType() {
    return this.authService.validationTypes.usernameValidationType;
  }

  get passwordValidationType() {
    return this.authService.validationTypes.passwordValidationType;
  }

  constructor(private router: Router, private authService: AuthService) {}

  navigateToAnalysis() {
    this.router.navigate(['/analysis/home']);
  }


  onSubmit() {
    if (this.credentials.user.valid && this.credentials.pass.valid) {
      this.authService.register(this.credentials.user.value, this.credentials.pass.value)
        .subscribe(
          (response) => {
            if (response.isSuccess) {
              localStorage.setItem('user_auth_token', response.token);
              this.navigateToAnalysis(); 
            } else {
              console.log('Registration failed:', response.error);
            }
          },
          (error) => {
            console.log('An error occurred:', error);
          }
        );
    } else {
      console.log('Invalid credentials', this.credentials);
    }
  }

  handleValueChange(value: any, fieldName: keyof typeof this.credentials) {
    if (value) {
      this.credentials[fieldName].value = value.value;
      this.credentials[fieldName].valid = value.valid;
    }
  }
}
