import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/user';


@Component({
  selector: 'app-estate_agentsCard',
  templateUrl: './estate_agentsCard.component.html',
  styleUrls: ['./estate_agentsCard.component.css']
})
export class Estate_agentsCardComponent implements OnInit {
  
  @Input() agent: Agent;

  constructor() { }

  ngOnInit() {
  }

}

export class Agent {
  imageUrl: string
  name: string
  age: number
  description: string
  constructor(im, name, age, des) {
    this.imageUrl = im
    this.name = name
    this.age = age
    this.description=des
  }
}