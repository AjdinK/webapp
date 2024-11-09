import { Component } from '@angular/core';
import {HeaderComponent} from "../homepage/header/header.component";
import {Router} from "@angular/router";

@Component({
  selector: 'app-search-page',
  standalone: true,
  imports: [
    HeaderComponent
  ],
  templateUrl: './search-page.component.html',
  styleUrl: './search-page.component.css'
})
export class SearchPageComponent {

  constructor(private router: Router) {
  }

  goBack () {
    this.router.navigate(['/serviser-nalog-page']);
  }

}
