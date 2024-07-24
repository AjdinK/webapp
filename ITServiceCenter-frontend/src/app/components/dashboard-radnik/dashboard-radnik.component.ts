import {Component} from '@angular/core';
import {HeaderComponent} from "../homepage/header/header.component";

@Component({
  selector: 'app-dashboard-radnik',
  standalone: true,
  imports: [
    HeaderComponent
  ],
  templateUrl: './dashboard-radnik.component.html',
  styleUrl: './dashboard-radnik.component.css'
})
export class DashboardRadnikComponent {

}
