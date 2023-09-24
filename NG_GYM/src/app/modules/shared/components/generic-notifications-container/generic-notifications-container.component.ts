import { Component } from '@angular/core';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'generic-notifications-container',
  template: `
    <div class="notifications-container">
      <generic-notification *ngFor="let notification of notificationService.getNotifications(); let i = index"
                            [type]="notification.type"
                            [message]="notification.message"
                            (closed)="removeNotification(notification.id)">
      </generic-notification>
    </div>
  `,
  styleUrls: ['./generic-notifications-container.component.scss']
})
export class GenericNotificationsContainerComponent {

  constructor(public notificationService: NotificationService) {}

  removeNotification(id: number) {
    this.notificationService.removeNotification(id);
  }
}
