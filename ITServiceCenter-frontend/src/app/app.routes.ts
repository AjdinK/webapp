import { Routes } from '@angular/router';
import { HomepageComponent } from './components/homepage/homepage.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardAdminComponent } from './components/dashboard-admin/dashboard-admin.component';

export const routes: Routes = [
  {
    path: '',
    component: HomepageComponent,
    title: 'Homepage',
  },
  {
    path: 'homepage',
    component: HomepageComponent,
    title: 'Homepage',
  },
  {
    path: 'login',
    component: LoginComponent,
    title: 'login',
  },
  {
    path: 'dashboard-admin',
    component: DashboardAdminComponent,
    title: 'dashboard-admin',
  },
  {
    path: 'assets/ava',
    component: HomepageComponent,
    title: 'assets/ava',
  },
  {
    path: 'assets/profile',
    component: HomepageComponent,
    title: 'assets/profile',
  },
  { path: '**', redirectTo: 'homepage' },
];
