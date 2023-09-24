import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { RegisterCredentials } from 'src/app/models/auth/Credentials.model';

@Component({
  selector: 'register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent {

  credentials:RegisterCredentials = {
    user: {value: '', valid: false},
    pass: {value: '', valid: false}
  };


  constructor(private router: Router, private authService: AuthService) {}

  navigateToAnalysis() {
    this.router.navigate(['/analysis/home']);
  }


  onSubmit() {
    if (this.credentials.user.value && this.credentials.pass.value && this.credentials.user.valid && this.credentials.pass.valid) {
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

}
