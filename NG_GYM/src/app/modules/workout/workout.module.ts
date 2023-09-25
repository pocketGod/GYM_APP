import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkoutRoutingModule } from './workout-routing.module';
import { SharedModule } from '../shared/shared.module';
import { WorkoutPlanComponent } from './components/building-blocks/workout-plan/workout-plan.component';



@NgModule({
  declarations: [
    WorkoutPlanComponent
  ],
  imports: [
    CommonModule,
    WorkoutRoutingModule,
    SharedModule
  ],
  exports: [
    WorkoutPlanComponent
  ]
})
export class WorkoutModule { }
