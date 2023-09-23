import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'capitalize'
})
export class CapitalizePipe implements PipeTransform {

  transform(value: string, capitalizeAll: boolean = false): string {
    if (!value || typeof value !== 'string') {
      return value;
    }
    
    if (capitalizeAll) {
      // Capitalize the first letter of each word
      return value.replace(/\b\w/g, char => char.toUpperCase());
    } else {
      // Capitalize only the first letter of the string
      return value.charAt(0).toUpperCase() + value.slice(1);
    }
  }

}
