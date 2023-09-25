import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { take } from 'rxjs';
import { NotificationTypes } from 'src/app/models/enums/Notifications.enum';
import { Workout } from 'src/app/models/workout/Workout.model';
import { WorkoutPlan } from 'src/app/models/workout/WorkoutPlan.model';
import { GenericDialogComponent } from 'src/app/modules/shared/components/generic-dialog/generic-dialog.component';
import { DialogService } from 'src/app/modules/shared/services/dialog.service';
import { NotificationService } from 'src/app/modules/shared/services/notification.service';
import { WorkoutService } from 'src/app/modules/workout/services/workout.service';

@Component({
  selector: 'analysis-home-page',
  templateUrl: './analysis-home-page.component.html',
  styleUrls: ['./analysis-home-page.component.scss']
})
export class AnalysisHomePageComponent implements OnInit, AfterViewInit {

  @ViewChild('confirmationDialog') private confirmDialog!: GenericDialogComponent;

  workouts: Workout[] = []
  plans: WorkoutPlan[] = []

  constructor(
    private workoutService:WorkoutService, 
    private dialogService: DialogService, 
    private notificationService:NotificationService
    ) {
  }


  ngOnInit(): void {
    this.workoutService.getAllWorkouts().subscribe((workouts)=>{
      console.log(workouts);
      this.workouts = workouts
    });

    this.workoutService.getAllWorkoutPlans().subscribe((plans)=>{
      console.log(plans);
      this.plans = plans
    })
  }

  ngAfterViewInit(): void {
    this.dialogService.setDialogComponent(this.confirmDialog)
  }

  testDialog(){
    this.dialogService.confirm('Are you sure you want to confirm this dialog action?')
      .pipe(take(1))
      .subscribe(confirmed => {
        if (confirmed) {
          console.log('dialog said yes');
        } else {
          console.log('dialog said no');
        }
      });
  }

  testNotificationPositive() {
    this.notificationService.addNotification('This is a success message', NotificationTypes.Success);
  }

  testNotificationNegative() {
    this.notificationService.addNotification('This is an error message', NotificationTypes.Error);
  }
}
