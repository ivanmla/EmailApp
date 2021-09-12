import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmailMessage } from '../_models/emailMessage';

@Injectable({
  providedIn: 'root'
})
export class EmailService {
  baseUrl='https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  sendMail(model:EmailMessage) {
    return this.http.post(this.baseUrl + 'email/send', model);
  }

  // getMails(){
  //   this.http.get('https://localhost:5001/api/email/get').subscribe(response => {
  //     this.emails = response;
  //   }, error => {
  //     console.log(error);
  //   })
  // }
  getMails(){
    return this.http.get(this.baseUrl + 'email/get');
  }

}
