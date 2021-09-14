import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmailService } from '../_services/email.service';

@Component({
  selector: 'app-arhiva',
  templateUrl: './arhiva.component.html',
  styleUrls: ['./arhiva.component.css']
})
export class ArhivaComponent implements OnInit {
  title = 'Email app';
  emails: any;

  constructor(private emailService: EmailService, private router: Router){}

  ngOnInit() {
    this.getEmails();
  }

  getEmails(){
    this.emailService.getMails().subscribe(response => {
      this.emails = response;
    }, error => {
      console.log(error);
      this.router.navigateByUrl('/server-error');
    })
  }

}
