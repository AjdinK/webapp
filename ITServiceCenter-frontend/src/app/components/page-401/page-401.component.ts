import {Component} from '@angular/core';
import {HeaderComponent} from "../homepage/header/header.component";

@Component({
  selector: 'app-page-401',
  standalone: true,
  imports: [
    HeaderComponent
  ],
  templateUrl: './page-401.component.html',
  styleUrl: '../../../assets/styles/page-error.css'
})
export class Page401Component {

}
