import {Component, Input} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {JsonPipe, NgIf} from "@angular/common";
import {Poruke} from "../../../helpers/Poruke";


@Component({
  selector: 'app-form-element-wrapper',
  standalone: true,
  imports: [
    FormsModule,
    JsonPipe,
    NgIf,
  ],
  templateUrl: './form-element-wrapper.component.html',
  styleUrl: './form-element-wrapper.component.css'
})
export class FormElementWrapperComponent {

  @Input() labelFor: string = "";
  @Input() label: string = "";
  @Input() className: string = "";
  @Input() imePolje: any = null;
  @Input() validation: any = null;
  @Input() JelPopunjeno: boolean = false;
  protected readonly Poruke = Poruke;

}
