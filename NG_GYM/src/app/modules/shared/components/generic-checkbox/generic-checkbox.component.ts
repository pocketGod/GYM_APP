import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'generic-checkbox',
  templateUrl: './generic-checkbox.component.html',
  styleUrls: ['./generic-checkbox.component.scss']
})
export class GenericCheckboxComponent {
  @Input() label: string = ''; 
  @Input() isChecked: boolean = false;  
  @Output() isCheckedChange = new EventEmitter<boolean>();
  
  
  toggleChecked() {
    this.isChecked = !this.isChecked;
    this.isCheckedChange.emit(this.isChecked);
  }
}
