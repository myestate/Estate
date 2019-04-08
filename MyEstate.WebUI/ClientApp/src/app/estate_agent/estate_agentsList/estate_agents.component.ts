import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';

@Component({
  selector: 'app-estate_agents',
  templateUrl: './estate_agents.component.html',
  styleUrls: ['./estate_agents.component.css']
})
export class Estate_agentsComponent implements OnInit {

  agents = [
    
    new Agent("../../assets/ivan.jpg", "Ivan Petrenko", 35, "I'm very good estate agent."),
    new Agent("../../assets/natalia.jpg", "Natalia Ivanchuk", 25, "I'm very good estate agent."),
    new Agent("../../assets/nastia.jpg", "Nastia Dotsenko", 28, "I'm very good estate agent."),
  ];

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