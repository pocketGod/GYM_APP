import { Injectable } from '@angular/core';
import { GenericDialogComponent } from '../components/generic-dialog/generic-dialog.component';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  private dialogComponent?: GenericDialogComponent;

  setDialogComponent(component: GenericDialogComponent) {
    this.dialogComponent = component;
  }

  confirm(message: string): Observable<boolean> {
    if (!this.dialogComponent) return of(false);
  
    this.dialogComponent.message = message;
    this.dialogComponent.open();
    return this.dialogComponent.onConfirm();
  }
}
