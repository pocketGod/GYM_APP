import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { HttpHandlerService } from 'src/app/common/services/http-handler.service';
import { WorkoutCreationPropertiesResponse } from 'src/app/models/workout-creator/NewWorkoutApi.model';

@Injectable({
  providedIn: 'root'
})
export class WorkoutCreationService extends HttpHandlerService {

  private baseExerciseURL = 'Exercise'; 
  private baseWorkoutURL = 'Workout'; 
  private propertiesWorkoutURL = 'Properties'; 

  getWorkoutCreationProperties(): Observable<WorkoutCreationPropertiesResponse> {
    return this.get<WorkoutCreationPropertiesResponse>(`${this.propertiesWorkoutURL}/GetWorkoutCreatorProperties`);
  }

}
