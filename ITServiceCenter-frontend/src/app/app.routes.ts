import {Routes} from '@angular/router';
import {HomepageComponent} from './components/homepage/homepage.component';
import {LoginComponent} from './components/login/login.component';
import {DashboardAdminComponent} from './components/dashboard-admin/dashboard-admin.component';
import {Page404Component} from "./components/page-404/page404.component";
import {Page401Component} from "./components/page-401/page-401.component";
import {authGuard} from "./services/auth.guard";
import {guestGuard} from "./services/guest.guard";
import {DashboardRadnikComponent} from "./components/dashboard-radnik/dashboard-radnik.component";
import {SearchPageComponent} from "./components/search-page/search-page.component";
import {AdminNalogPageComponent} from "./components/admin-nalog-page/admin-nalog-page.component";
import {ServiserNalogPageComponent} from "./components/serviser-nalog-page/serviser-nalog-page.component";
import {ServiserAddNalogComponent} from "./components/serviser-add-nalog/serviser-add-nalog.component";

export const routes: Routes = [
  {
    path: '',
    component: HomepageComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [guestGuard]
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
    path: 'serviser-nalog-page',
    component: ServiserNalogPageComponent,
  },
  {
    path: 'search-page',
    component: SearchPageComponent,
  },
  {
    path: 'admin-nalog-page',
    component: AdminNalogPageComponent,
  },
  {
    path: 'serviser-nalog-page',
    component: ServiserNalogPageComponent,
  },
  {
    path: 'serviser-add-nalog',
    component: ServiserAddNalogComponent,
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
