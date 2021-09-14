import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmailMessage } from '../_models/emailMessage';
import { EmailService } from '../_services/email.service';

@Component({
  selector: 'app-novi-email',
  templateUrl: './novi-email.component.html',
  styleUrls: ['./novi-email.component.css']
})
export class NoviEmailComponent implements OnInit {
  model: EmailMessage = {};
  emailForm: FormGroup;
  validationErrors: string[];

  constructor(private emailService: EmailService, private router: Router, private tostr: ToastrService) { }

  ngOnInit(): void {
    this.initialzeForm();
  }

  initialzeForm() {
    this.emailForm = new FormGroup({
      from: new FormControl('', [Validators.required, Validators.email]),
      to: new FormControl('', [Validators.required, Validators.email]),
      cc: new FormControl(''),
      importance: new FormControl('low'),
      subject: new FormControl(''),
      content: new FormControl('')
    });    
  }

  newEmail() {
    this.emailService.sendMail(this.emailForm.value).subscribe(response => {
      console.log(response);
    }, error => {
      this.validationErrors = error;
    })
  }

  cancel() {
    console.log('canceled');
    this.router.navigateByUrl('/');
  }

}
