import { Component, OnInit, Input } from '@angular/core';
import { Estate } from 'src/app/_models/estate';

@Component({
  selector: 'app-estate-card',
  templateUrl: './estate-card.component.html',
  styleUrls: ['./estate-card.component.css']
})
export class EstateCardComponent implements OnInit {
  @Input() estate: Estate;
  constructor() { }

  ngOnInit() {
  }

}
