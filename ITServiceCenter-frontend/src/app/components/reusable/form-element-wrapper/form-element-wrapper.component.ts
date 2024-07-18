import {Component, Input} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {JsonPipe, NgIf} from "@angular/common";
import {Poruke} from "../../../services/Poruke";


@Component({
  selector: 'app-form-element-wrapper',
  standalone: true,
  imports: [
    FormsModule,
    JsonPipe,
    NgIf
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

  getValidationMessage() {
    const objKeys = Object.keys(this.validation);
    if (objKeys.length !== 0) {
      return this.validation[objKeys[0]];
    } else {
      return "";
    }
  }
}
