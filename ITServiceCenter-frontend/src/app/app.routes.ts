import {Routes} from '@angular/router';
import {HomepageComponent} from './components/homepage/homepage.component';
import {LoginComponent} from './components/login/login.component';
import {DashboardAdminComponent} from './components/dashboard-admin/dashboard-admin.component';
import {Page404Component} from "./components/page-404/page404.component";
import {Page401Component} from "./components/page-401/page-401.component";
import {authGuard} from "./services/auth.guard";

export const routes: Routes = [
  {
    path: '',
    component: HomepageComponent,
    canActivate: [],
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
    path: '401',
    component: Page401Component,
  },
  {
    path: 'dashboard-admin',
    component: DashboardAdminComponent,
    canActivate: [authGuard]
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
