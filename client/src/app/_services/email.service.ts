import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmailMessage } from '../_models/emailMessage';

@Injectable({
  providedIn: 'root'
})

export class EmailService {
  baseUrl='https://localhost:5001/api/email/';

  constructor(private http: HttpClient) { }  
  
  getMails() {
    return this.http.get<EmailMessage[]>(this.baseUrl + 'get');
  }

  sendMail(model:EmailMessage) {
    return this.http.post(this.baseUrl + 'send', model);
  }

}
