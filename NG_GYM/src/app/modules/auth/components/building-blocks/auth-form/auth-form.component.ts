import { Component, Input, Output, EventEmitter } from '@angular/core';
import { LoginCredentials, RegisterCredentials } from 'src/app/models/auth/Credentials.model';
import { GenericInputValue } from 'src/app/models/common/GenericInputValue.model';
import { ValidationType } from 'src/app/models/common/PatternValidations';

@Component({
  selector: 'auth-form',
  templateUrl: './auth-form.component.html',
  styleUrls: ['./auth-form.component.scss']
})
export class AuthFormComponent {

  @Input() isLoginForm: boolean = false;
  @Input() loginCreds: LoginCredentials = {
    user: {
      value: '',
      valid: false
    },
    pass: {
      value: '',
      valid: false
    }
  }
  @Input() registerCreds: RegisterCredentials = {
    user: {
      value: '',
      valid: false
    },
    pass: {
      value: '',
      valid: false
    }
  }
  @Output() formSubmit:EventEmitter<null> = new EventEmitter()
  
  usernameValidationType: ValidationType = ValidationType.Username;
  passwordValidationType: ValidationType = ValidationType.Password;

  handleValueChange(value: GenericInputValue<string> | null, fieldName: keyof LoginCredentials) {

    if(!value) return

    if(this.isLoginForm){
      this.loginCreds[fieldName].value = value.value;
      this.loginCreds[fieldName].valid = value.valid;
    }
    else {
      this.registerCreds[fieldName].value = value.value;
      this.registerCreds[fieldName].valid = value.valid;
    }
  }

  submitForm(){
    this.formSubmit.emit(null)
  }

}
