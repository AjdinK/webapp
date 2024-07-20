import {Component} from '@angular/core';
import {HeaderComponent} from "../homepage/header/header.component";

@Component({
  selector: 'app-page-404',
  standalone: true,
  imports: [
    HeaderComponent
  ],
  templateUrl: './page404.component.html',
  styleUrl: '../../../assets/styles/page-error.css'

})
export class Page404Component {

}
