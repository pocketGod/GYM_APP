import { Injectable } from '@angular/core';
import { VALIDATION_PATTERNS, ValidationType } from 'src/app/models/common/PatternValidations';

@Injectable({
  providedIn: 'root'
})
export class PatternValidationService {

  validate(value: any, validationType?: ValidationType, customRules?: {minLength?: number, maxLength?: number}): boolean {
    // Check for custom rules first
    if (customRules) {
      if (customRules.minLength && String(value).length < customRules.minLength) {
        return false;
      }

      if (customRules.maxLength && String(value).length > customRules.maxLength) {
        return false;
      }
    }

    if (validationType) {
      const pattern = VALIDATION_PATTERNS[validationType];
      return pattern.test(String(value));
    }

    // If no validation is specified, consider it valid
    return true;
  }
}