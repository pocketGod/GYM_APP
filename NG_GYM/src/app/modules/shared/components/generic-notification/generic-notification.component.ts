
import { ChangeDetectorRef, Component, EventEmitter, HostListener, Input, OnChanges, OnDestroy, Output, SimpleChanges } from '@angular/core';
import { Subject } from 'rxjs';
import { slideDown, slideInOut } from 'src/app/common/animations/notifications.animation';
import { NotificationTypes } from 'src/app/models/enums/Notifications.enum';

@Component({
  selector: 'generic-notification',
  templateUrl: './generic-notification.component.html',
  styleUrls: ['./generic-notification.component.scss'],
  animations: [
    slideInOut,
    slideDown
  ]
})

export class GenericNotificationComponent implements OnChanges, OnDestroy{

  @Input() type: NotificationTypes = NotificationTypes.Success;
  @Input() message: string = ''
  @Output() closed = new EventEmitter<void>();
  
  isVisible: boolean = false;
  progress: number = 100;
  animationState: string = 'out';

  private timerId: any;
  private initialTime: number = 4000;
  private remainingTime: number = this.initialTime;
  private lastPauseTime: number | null = null;

  private closeSubject: Subject<void> = new Subject<void>();

  constructor(private cdr: ChangeDetectorRef) {
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['message'] && changes['message'].currentValue) {
      this.open(this.message);
    }
  }

  ngOnDestroy() {
    if (this.timerId) {
      clearInterval(this.timerId);
    }
  }
  

  open(message: string) {
    this.message = message;
    this.isVisible = true;
    this.animationState = 'in';
    this.startTimer();
  }
  
  close() {
    console.log('Setting animation state to void');
    this.animationState = 'void';  
    this.isVisible = false;
    this.pauseTimer();
  }
  
  

  onClose() {
    return this.closeSubject.asObservable();
  }

  @HostListener('@slideInOut.done', ['$event'])
  animationDone(event: any) {
    console.log('Animation done event fired', event);
    if (event.toState === 'void') {
      this.isVisible = false;
      this.closeSubject.next();
      this.closed.emit();
    }
  }
  

  private startTimer() {
    const updateProgress = () => {
      this.progress = (this.remainingTime / this.initialTime) * 100;
      if (this.remainingTime <= 0) {
        this.close();
      }
    };

    this.lastPauseTime = new Date().getTime();

    this.timerId = setInterval(() => {
      const currentTime = new Date().getTime();
      const elapsedTime = currentTime - this.lastPauseTime!;
      this.remainingTime -= elapsedTime;
      this.lastPauseTime = currentTime;
      updateProgress();
    }, 50);
  }

  pauseTimer() {
    clearInterval(this.timerId);
  }

  resumeTimer() {
    this.startTimer();
  }
}
