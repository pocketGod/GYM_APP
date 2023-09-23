import { Component, OnInit } from '@angular/core';
import { WorkoutService } from 'src/app/modules/workout/services/workout.service';

@Component({
  selector: 'analysis-home-page',
  templateUrl: './analysis-home-page.component.html',
  styleUrls: ['./analysis-home-page.component.scss']
})
export class AnalysisHomePageComponent implements OnInit {

  constructor(private workoutService:WorkoutService) {
    
  }

  ngOnInit(): void {
    this.workoutService.getAllWorkouts().subscribe((workouts)=>{
      console.log(workouts);
    });
  }
}
