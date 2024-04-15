import { Routes } from '@angular/router';
import { HomepageComponent } from './components/homepage/homepage.component';
import {LoginComponent} from "./components/login/login.component";

export const routes: Routes = [
  {
    path: '',
    component: HomepageComponent,
    title: 'Home page',
  },
  {
    path: 'homepage',
    component: HomepageComponent,
    title: 'Home page',
  },

  {
    path: 'login',
    component: LoginComponent,
    title: 'login',
  },
];
