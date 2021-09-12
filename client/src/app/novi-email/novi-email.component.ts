import { Component, OnInit } from '@angular/core';
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

  constructor(private emailService: EmailService, private router: Router, private tostr: ToastrService) { }

  ngOnInit(): void {
  }

  newEmail() {
    this.emailService.sendMail(this.model).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
      this.tostr.error(error.error);
    })
  }

  cancel() {
    console.log('canceled');
    this.router.navigateByUrl('/');
  }

}
