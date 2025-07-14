import { Routes } from '@angular/router';
import { DashboardComponent } from './shared/component/dashboard/dashboard.component';

export const routes: Routes = [
  { 
    path: '', 
    component: DashboardComponent,
    title: 'Dashboard' 
  }
  ];