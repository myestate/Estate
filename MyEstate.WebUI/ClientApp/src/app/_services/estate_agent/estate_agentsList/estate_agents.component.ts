import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-estate_agents',
  templateUrl: './estate_agents.component.html',
  styleUrls: ['./estate_agents.component.css']
})
export class Estate_agentsComponent implements OnInit {

  agents = [
    new Agent("../../assets/summerhouse.jpg", "Anna Petrenko", 32, "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
    new Agent("../../assets/brickhouse.jpg", "Vasyl Ivanechuk", 40, "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
    new Agent("../../assets/renovated.jpg", "Maria Vuichyshyn", 55, "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
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
    this.description = des
  }
}