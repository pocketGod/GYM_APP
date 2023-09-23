import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ValidationType } from 'src/app/models/common/PatternValidations';
import { PatternValidationService } from '../../services/pattern-validation.service';
import { GenericInputValue } from 'src/app/models/common/GenericInputValue.model';

@Component({
  selector: 'generic-input',
  templateUrl: './generic-input.component.html',
  styleUrls: ['./generic-input.component.scss']
})
export class GenericInputComponent<T> implements OnInit {
  @Input() type: 'text' | 'number' | 'date' | 'password' = 'text';
  @Input() placeholder: string = '';
  @Input() validationType?: ValidationType;
  @Input() customRules?: { minLength?: number, maxLength?: number };
  @Input() value: T | null = null;
  @Input() autoFocus: boolean = false;

  @Output() valueChange: EventEmitter<GenericInputValue<T> | null> = new EventEmitter();

  isValid: boolean = true;
  isDirty: boolean = false;

  constructor(private patternValidationService: PatternValidationService) {}

  ngOnInit(): void {}

  onInputChange(event: any) {
    this.isDirty = true;
    this.value = event.target.value;
    this.validate();
  }

  validate() {
    this.isValid = this.patternValidationService.validate(this.value, this.validationType, this.customRules);
    
    const genericInputValue: GenericInputValue<T> = {
      value: this.value,
      valid: this.isValid,
    };
    
    this.valueChange.emit(genericInputValue);
  }
}