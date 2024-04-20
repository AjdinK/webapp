import {Component, Injectable} from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-potvrda-dijalog',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './potvrda-dijalog.component.html',
  styleUrl: './potvrda-dijalog.component.css'
})

@Injectable()
export class PotvrdaDijalogComponent {

  constructor(private modalService: NgbModal) { }

  public confirm(
    title: string,
    message: string,
    btnOkText: string = 'Da',
    btnCancelText: string = 'Ne',
    dialogSize: 'sm'|'lg' = 'sm'): Promise<boolean> {
    const modalRef = this.modalService.open(PotvrdaDijalogComponent, { size: dialogSize });
    modalRef.componentInstance.title = title;
    modalRef.componentInstance.message = message;
    modalRef.componentInstance.btnOkText = btnOkText;
    modalRef.componentInstance.btnCancelText = btnCancelText;

    return modalRef.result;
  }
}
