import { Component, OnInit } from '@angular/core';
import { EmailMessage } from '../_models/emailMessage';
import { EmailService } from '../_services/email.service';

@Component({
  selector: 'app-novi-email',
  templateUrl: './novi-email.component.html',
  styleUrls: ['./novi-email.component.css']
})
export class NoviEmailComponent implements OnInit {
  model: EmailMessage = {};

  constructor(private emailService: EmailService) { }

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
  }

}
