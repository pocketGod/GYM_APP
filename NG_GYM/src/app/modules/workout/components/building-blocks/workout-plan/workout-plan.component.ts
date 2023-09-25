import { Component, Input } from '@angular/core';
import { WorkoutTypes, WorkoutTypesLabels } from 'src/app/models/enums/Workout.enum';
import { WorkoutPlan } from 'src/app/models/workout/WorkoutPlan.model';

@Component({
  selector: 'workout-plan',
  templateUrl: './workout-plan.component.html',
  styleUrls: ['./workout-plan.component.scss']
})
export class WorkoutPlanComponent {

  @Input() plan!: WorkoutPlan

  someBooleanVariable:boolean = false;
  
  getWorkoutTypeValue(type: WorkoutTypes): string {
    return WorkoutTypesLabels[type];
  }
  
}
