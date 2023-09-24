import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkoutAnalysisRoutingModule } from './workout-analysis-routing.module';
import { AnalysisHomePageComponent } from './components/pages/analysis-home-page/analysis-home-page.component';
import { SharedModule } from '../shared/shared.module';
import { AnalysisStatPageComponent } from './components/pages/analysis-stat-page/analysis-stat-page.component';



@NgModule({
  declarations: [
    AnalysisHomePageComponent,
    AnalysisStatPageComponent
  ],
  imports: [
    CommonModule,
    WorkoutAnalysisRoutingModule,
    SharedModule
  ]
})
export class WorkoutAnalysisModule { }
