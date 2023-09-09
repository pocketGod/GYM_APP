import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { WorkoutCreationPropertiesResponse } from 'src/app/models/workout-creator/NewWorkoutApi.model';
import { HttpHandlerService } from 'src/app/shared/services/http-handler.service';

@Injectable({
  providedIn: 'root'
})
export class WorkoutCreationService extends HttpHandlerService {

  private baseExerciseURL = 'Exercise'; 
  private baseWorkoutURL = 'Workout'; 
  private propertiesWorkoutURL = 'Properties'; 

  getWorkoutCreationProperties(): Observable<WorkoutCreationPropertiesResponse> {
    return this.get(`${this.propertiesWorkoutURL}/GetWorkoutCreatorProperties`).pipe(
      map(response => response as WorkoutCreationPropertiesResponse)
    );
  }

}
