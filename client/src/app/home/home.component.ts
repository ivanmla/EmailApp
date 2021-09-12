import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  eMailMode = false;

  constructor(){}

  ngOnInit() {
  }

  eMailToggle() {
    this.eMailMode = !this.eMailMode;
  }

  cancelEmailMode(event: boolean){
    this.eMailMode = event;
  }

}
