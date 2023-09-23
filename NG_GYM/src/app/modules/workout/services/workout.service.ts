import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { HttpHandlerService } from 'src/app/common/services/http-handler.service';
import { Exercise } from 'src/app/models/exercise/Exercise.model';
import { ExerciseByMuscleResponse } from 'src/app/models/exercise/ExerciseApi.model';
import { Workout } from 'src/app/models/workout/Workout.model';

@Injectable({
  providedIn: 'root'
})
export class WorkoutService extends HttpHandlerService {

  private baseExerciseURL = 'Exercise'; 
  private baseWorkoutURL = 'Workout'; 

  getAllWorkouts(): Observable<Workout[]> {
    return this.get(`${this.baseWorkoutURL}/GetAllWorkouts`).pipe(
      map(response => response as Workout[])
    );
  }

  
  getAllExercises(): Observable<Exercise[]> {
    return this.get(`${this.baseExerciseURL}/GetAllExercises`).pipe(
      map(response => response as Exercise[])
    );
  }

  getExercisesByTargetMuscle(targetMuscle: string): Observable<ExerciseByMuscleResponse> {
    return this.get(`${this.baseExerciseURL}/GetByTargetMuscle/${targetMuscle}`).pipe(
      map(response => response as ExerciseByMuscleResponse)
    );
  }

}