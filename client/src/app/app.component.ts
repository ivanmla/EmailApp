import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Email app';
  emails: any;

  constructor(private http: HttpClient){}

  ngOnInit() {
    this.getEmails();
  }

  getEmails(){
    this.http.get('https://localhost:5001/api/email/get').subscribe(response => {
      this.emails = response;
    }, error => {
      console.log(error);
    })
  }
}
