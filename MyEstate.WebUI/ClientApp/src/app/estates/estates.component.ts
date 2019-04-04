import { Component, OnInit, Input } from '@angular/core';
import { EstateService } from '../_services/estate.service';

@Component({
  selector: 'app-estates',
  templateUrl: './estates.component.html',
  styleUrls: ['./estates.component.css']
})

export class EstatesComponent implements OnInit {
  @Input() type: string;

  constructor(private estateService: EstateService) { }
  
  estates(){
    return this.estateService.getEstates();
  }

  newsList = [
// tslint:disable-next-line: max-line-length
    new News('Metro in Lviv!', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.'),
// tslint:disable-next-line: max-line-length
    new News('New feature in program', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.'),
// tslint:disable-next-line: max-line-length
    new News('Hello world', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.'),
  ];

  ngOnInit() {
  }

}

export class News {
  title: string;
  content: string;
  constructor(title: string, content: string) {
    this.title = title;
    this.content = content;
  }
}
