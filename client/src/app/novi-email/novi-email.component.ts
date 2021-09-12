import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmailMessage } from '../_models/emailMessage';
import { Importance } from '../_models/importance';
import { EmailService } from '../_services/email.service';

@Component({
  selector: 'app-novi-email',
  templateUrl: './novi-email.component.html',
  styleUrls: ['./novi-email.component.css']
})
export class NoviEmailComponent implements OnInit {
  model: EmailMessage = {};

  constructor(private emailService: EmailService, private router: Router) { }

  ngOnInit(): void {
  }

  newEmail() {
    this.emailService.sendMail(this.model).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

  cancel() {
    console.log('canceled');
    this.router.navigateByUrl('/');
  }

}
