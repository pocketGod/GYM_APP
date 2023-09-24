import { Injectable } from '@angular/core';
import { NotificationTypes } from 'src/app/models/enums/Notifications.enum';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  private notifications: any[] = [];

  getNotifications() {
    return this.notifications;
  }

  addNotification(message: string, type: NotificationTypes) {
    const id = new Date().getTime(); // unique notification ID
    this.notifications.push({ id, message, type });
  }

  removeNotification(id: number) {
    this.notifications = this.notifications.filter(notification => notification.id !== id);
  }
}
