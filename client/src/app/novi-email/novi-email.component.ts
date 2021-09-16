import { Component, EventEmitter, OnInit, Output, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { EmailMessage } from '../_models/emailMessage';
import { EmailService } from '../_services/email.service';

@Component({
  selector: 'app-novi-email',
  templateUrl: './novi-email.component.html',
  styleUrls: ['./novi-email.component.css']
})
export class NoviEmailComponent implements OnInit {
  @Output() cancelNewEmailMode = new EventEmitter();
  model: EmailMessage = {};
  emailForm: FormGroup;
  validationErrors: string[] = [];
  modalRef?: BsModalRef;
  saveAlert = false;

  constructor(private emailService: EmailService, private tostr: ToastrService, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.initialzeForm();
  }

  initialzeForm() {
    this.emailForm = new FormGroup({
      from: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(100)]),
      to: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(100)]),
      cc: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      importance: new FormControl('low'),
      subject: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      content: new FormControl('', [Validators.required, Validators.maxLength(500)]),
    });    
  }

  newEmail() {
    this.emailService.sendMail(this.emailForm.value).subscribe(response => {
      this.saveAlert = true;
    }, error => {
      this.validationErrors = error;
    })
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  confirmCancel() {
    this.modalRef.hide();
    this.cancelNewEmailMode.emit(false);
  }

  onClosed(dismissedAlert: any): void {
    this.saveAlert = false;
    this.initialzeForm();
    this.validationErrors = [];
  }

}
