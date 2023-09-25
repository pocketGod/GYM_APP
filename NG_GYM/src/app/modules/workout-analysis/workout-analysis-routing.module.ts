import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnalysisHomePageComponent } from './components/pages/analysis-home-page/analysis-home-page.component';
import { AuthGuard } from 'src/app/common/guards/auth.guard';
import { AnalysisStatPageComponent } from './components/pages/analysis-stat-page/analysis-stat-page.component';


const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'home',
        component: AnalysisHomePageComponent,
      },
      {
        path: 'stat',
        component: AnalysisStatPageComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkoutAnalysisRoutingModule { }
