import { Directive, ElementRef, Input, AfterViewInit } from '@angular/core';

@Directive({
  selector: '[appAutofocus]'
})
export class AutofocusDirective implements AfterViewInit {

  @Input() appAutofocus: boolean = true;

  constructor(private el: ElementRef) { }

  ngAfterViewInit() {
    if (this.appAutofocus) {
      this.el.nativeElement.focus();
    }
  }
}
