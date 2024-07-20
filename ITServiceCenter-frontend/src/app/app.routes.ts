import {Routes} from '@angular/router';
import {HomepageComponent} from './components/homepage/homepage.component';
import {LoginComponent} from './components/login/login.component';
import {DashboardAdminComponent} from './components/dashboard-admin/dashboard-admin.component';
import {Page404Component} from "./components/page-404/page404.component";

export const routes: Routes = [
  {
    path: '',
    component: HomepageComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '404',
    component: Page404Component,
  },
  {
    path: 'dashboard-admin',
    component: DashboardAdminComponent,
  },
  {
    path: 'assets/ava',
    component: HomepageComponent,
  },
  {
    path: 'assets/profile',
    component: HomepageComponent,
  },
  {
    path: '**',
    redirectTo: '404'
  },
];
