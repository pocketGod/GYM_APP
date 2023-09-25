import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'generic-dialog',
  templateUrl: './generic-dialog.component.html',
  styleUrls: ['./generic-dialog.component.scss']
})
export class GenericDialogComponent {

  @Input() message: string = '';
  @ViewChild('dialogElement', { static: false }) dialogElement!: ElementRef;

  isOpen:boolean = false;
  private confirmSubject:Subject<boolean> = new Subject<boolean>();

  open() {
    this.isOpen = true;
  }

  close() {
    this.isOpen = false;
  }

  confirm() {
    this.confirmSubject.next(true);
    this.close();
  }

  cancel() {
    this.confirmSubject.next(false);
    this.close();
  }

  onConfirm() {
    return this.confirmSubject.asObservable();
  }

  onBackdropClick(event: Event) {
    const clickedInside = this.dialogElement.nativeElement.contains(event.target);
    if (!clickedInside) {
      this.cancel();
    }
  }
}
