import { Component } from '@angular/core';
import {HeaderComponent} from "../homepage/header/header.component";
import {Router} from "@angular/router";

@Component({
  selector: 'app-admin-nalog-page',
  standalone: true,
  imports: [
    HeaderComponent
  ],
  templateUrl: './admin-nalog-page.component.html',
  styleUrl: './admin-nalog-page.component.css'
})
export class AdminNalogPageComponent {
  constructor(private router: Router) {
  }
  goToDashboard (){
    this.router.navigate(['/dashboard-admin']);
  }
}
