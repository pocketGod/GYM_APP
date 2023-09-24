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
    return this.get<Workout[]>(`${this.baseWorkoutURL}/GetAllWorkouts`);
  }

  getAllExercises(): Observable<Exercise[]> {
    return this.get<Exercise[]>(`${this.baseExerciseURL}/GetAllExercises`);
  }

  getExercisesByTargetMuscle(targetMuscle: string): Observable<ExerciseByMuscleResponse> {
    return this.get<ExerciseByMuscleResponse>(`${this.baseExerciseURL}/GetByTargetMuscle/${targetMuscle}`);
  }

}