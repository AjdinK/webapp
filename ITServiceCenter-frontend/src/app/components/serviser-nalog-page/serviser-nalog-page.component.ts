import { Component } from '@angular/core';
import {HeaderComponent} from "../homepage/header/header.component";
import {Router} from "@angular/router";

@Component({
  selector: 'app-serviser-nalog-page',
  standalone: true,
  imports: [
    HeaderComponent
  ],
  templateUrl: './serviser-nalog-page.component.html',
  styleUrl: './serviser-nalog-page.component.css'
})
export class ServiserNalogPageComponent {

  constructor(private router:Router) {
  }

  goToAddDevice() {
    this.router.navigate(['/serviser-add-nalog'])
  }
}
