import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericInputComponent } from './components/generic-input/generic-input.component';
import { FormsModule } from '@angular/forms';
import { AutofocusDirective } from './directives/auto-focus.directive';
import { CapitalizePipe } from './pipes/capitalize.pipe';



@NgModule({
  declarations: [
    GenericInputComponent,
    AutofocusDirective,
    CapitalizePipe
  ],
  imports: [
    CommonModule,
    FormsModule,
  ],
  exports: [
    GenericInputComponent,
    AutofocusDirective
  ]
})
export class SharedModule { }
