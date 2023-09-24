import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericInputComponent } from './components/generic-input/generic-input.component';
import { FormsModule } from '@angular/forms';
import { AutofocusDirective } from './directives/auto-focus.directive';
import { CapitalizePipe } from './pipes/capitalize.pipe';
import { GenericDialogComponent } from './components/generic-dialog/generic-dialog.component';
import { GenericNotificationComponent } from './components/generic-notification/generic-notification.component';
import { GenericNotificationsContainerComponent } from './components/generic-notifications-container/generic-notifications-container.component';


@NgModule({
  declarations: [
    GenericInputComponent,
    AutofocusDirective,
    CapitalizePipe,
    GenericDialogComponent,
    GenericNotificationComponent,
    GenericNotificationsContainerComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
  ],
  exports: [
    GenericInputComponent,
    GenericDialogComponent,
    GenericNotificationComponent,
    GenericNotificationsContainerComponent,
    AutofocusDirective
  ]
})
export class SharedModule { }
