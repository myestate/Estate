import { Component, OnInit, Input } from '@angular/core';
import { EstateAgent } from 'src/app/_models/estateAgent';

@Component({
  selector: 'app-estate_agentsCard',
  templateUrl: './estate_agentsCard.component.html',
  styleUrls: ['./estate_agentsCard.component.css']
})
export class Estate_agentsCardComponent implements OnInit {
  
  @Input() estateAgent: EstateAgent;

  constructor() { }

  ngOnInit() {
  }

}

