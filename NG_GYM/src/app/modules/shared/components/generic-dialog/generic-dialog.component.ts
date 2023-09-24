import { Component, Input } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'generic-dialog',
  templateUrl: './generic-dialog.component.html',
  styleUrls: ['./generic-dialog.component.scss']
})
export class GenericDialogComponent {
  @Input() message: string = '';

  private confirmSubject:Subject<boolean> = new Subject<boolean>();
  isOpen:boolean = false;

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
}
