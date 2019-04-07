import { Component, OnInit, Input } from '@angular/core';
import { Estate } from '../../_models/estate';
import { EstateService } from '../../_services/estate/estate.service';
import { AlertifyService } from '../../_services/alertify/Alertify.service';

@Component({
  selector: 'app-estates',
  templateUrl: './estates.component.html',
  styleUrls: ['./estates.component.css']
})

export class EstatesComponent implements OnInit {
  @Input() type: string;
  estates: Estate[];


  newsList = [
// tslint:disable-next-line: max-line-length
    new News('Metro in Lviv!', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.'),
// tslint:disable-next-line: max-line-length
    new News('New feature in program', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.'),
// tslint:disable-next-line: max-line-length
    new News('Hello world', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.'),
  ];
  constructor(private estateService: EstateService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadEstates();
  }

  loadEstates() {
    this.estateService.getEstates().subscribe((estates: Estate[]) => {
      this.estates = estates;
    }, error => {
      this.alertify.error(error);
    });
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
