import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  newEmailMode = false;

  constructor(){}

  ngOnInit() {
  }

  eMailToggle() {
    this.newEmailMode = !this.newEmailMode;
  }

  cancelNewEmailMode(event: boolean){
    this.newEmailMode = event;
  }

}
