import { Component, Input } from '@angular/core';
import { WorkoutPlan } from 'src/app/models/workout/WorkoutPlan.model';

@Component({
  selector: 'workout-plan',
  templateUrl: './workout-plan.component.html',
  styleUrls: ['./workout-plan.component.scss']
})
export class WorkoutPlanComponent {

  @Input() plan!: WorkoutPlan

}
