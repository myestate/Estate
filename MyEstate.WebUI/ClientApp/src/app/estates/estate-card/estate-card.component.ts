import { Component, OnInit, Input } from '@angular/core';
import { Estate } from 'src/app/_models/estate';

@Component({
  selector: 'app-estate-card',
  templateUrl: './estate-card.component.html',
  styleUrls: ['./estate-card.component.css']
})
export class EstateCardComponent implements OnInit {
  @Input() estate: Estate;
  havePhotos: boolean = false;
  constructor() { }

  ngOnInit() {
    if (this.estate.photos.length !== 0) {
      this.havePhotos = true;
    }
  }

}
