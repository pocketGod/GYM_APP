import { Directive, ElementRef, Input, AfterViewInit } from '@angular/core';

@Directive({
  selector: '[Autofocus]'
})
export class AutofocusDirective implements AfterViewInit {

  @Input() Autofocus: boolean = true;

  constructor(private el: ElementRef) { }

  ngAfterViewInit() {
    if (this.Autofocus) {
      this.el.nativeElement.focus();
    }
  }
}
