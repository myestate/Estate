import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-estates',
  templateUrl: './estates.component.html',
  styleUrls: ['./estates.component.css']
})
export class EstatesComponent implements OnInit {
  items = [new Advertisement("../../assets/summerhouse.jpg", "Summerhouse", 10000, "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
  new Advertisement("../../assets/brickhouse.jpg", "Brickhouse", 7000, "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
  new Advertisement("../../assets/renovated.jpg", "Renovated", 9000, "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
  ];
  constructor() { }

  ngOnInit() {
  }

}

export class Advertisement {
  imageUrl: string
  title: string
  price: number
  description: string
  constructor(im, tit, pr, des) {
    this.imageUrl = im
    this.title = tit
    this.price = pr
    this.description=des
  }
}
