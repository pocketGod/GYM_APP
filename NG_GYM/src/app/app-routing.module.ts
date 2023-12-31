import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'analysis',
    loadChildren: () => import('./modules/workout-analysis/workout-analysis.module').then(m => m.WorkoutAnalysisModule)
  },
  {path: '', pathMatch:'full', redirectTo:'auth/login'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
