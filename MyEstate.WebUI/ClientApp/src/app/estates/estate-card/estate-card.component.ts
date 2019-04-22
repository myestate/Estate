import { Component, OnInit, Input } from '@angular/core';
import { Estate } from 'src/app/_models/estate';
import { AuthService } from '../../_services/auth/auth.service';

@Component({
  selector: 'app-estate-card',
  templateUrl: './estate-card.component.html',
  styleUrls: ['./estate-card.component.css']
})
export class EstateCardComponent implements OnInit {
  @Input() estate: Estate;
  havePhotos: boolean = false;
  constructor(public authService: AuthService) { }

  ngOnInit() {
    if (this.estate.photos.length !== 0) {
      this.havePhotos = true;
    }
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
