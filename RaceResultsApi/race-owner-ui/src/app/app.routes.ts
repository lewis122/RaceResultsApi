import { Routes } from '@angular/router';
import { HorseDashboardComponent } from './features/horse-dashboard/horse-dashboard.component';

export const routes: Routes = [
  { path: '', component: HorseDashboardComponent },
  { path: '**', redirectTo: '' }
];
