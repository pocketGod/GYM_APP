import { Component } from '@angular/core';
import { NotificationService } from '../../services/notification.service';
import { slideDown } from 'src/app/common/animations/notifications.animation';
import { NotificationTypes } from 'src/app/models/enums/Notifications.enum';

@Component({
   selector: 'generic-notifications-container',
  template: `
    <div class="notifications-container" [@slideDown]="notificationService.getNotifications().length">
      <generic-notification *ngFor="let notification of notificationService.getNotifications(); let i = index"
                            [type]="notification.type"
                            [message]="notification.message"
                            (closed)="removeNotification(notification.id)">
      </generic-notification>
    </div>
  `,
  styleUrls: ['./generic-notifications-container.component.scss'],
  animations:[slideDown]
})
export class GenericNotificationsContainerComponent {


  constructor(public notificationService: NotificationService) {}

  removeNotification(id: number) {
    this.notificationService.removeNotification(id);
  }

  addNotification(message: string, type: NotificationTypes) {
    this.notificationService.addNotification(message, type);
  }

  
}
