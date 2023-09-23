import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkoutAnalysisRoutingModule } from './workout-analysis-routing.module';
import { AnalysisHomePageComponent } from './components/pages/analysis-home-page/analysis-home-page.component';



@NgModule({
  declarations: [
    AnalysisHomePageComponent
  ],
  imports: [
    CommonModule,
    WorkoutAnalysisRoutingModule
  ]
})
export class WorkoutAnalysisModule { }
