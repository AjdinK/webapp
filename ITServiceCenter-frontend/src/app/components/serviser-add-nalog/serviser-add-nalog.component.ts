import { Component } from '@angular/core';
import {HeaderComponent} from "../homepage/header/header.component";
import {Router} from "@angular/router";

@Component({
  selector: 'app-serviser-add-nalog',
  standalone: true,
  imports: [
    HeaderComponent
  ],
  templateUrl: './serviser-add-nalog.component.html',
  styleUrl: './serviser-add-nalog.component.css'
})
export class ServiserAddNalogComponent {

  constructor(private router:Router) {
  }

  goBack() {
    this.router.navigate(['serviser-nalog-page']);
  }

}
