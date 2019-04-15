import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Estate } from '../_models/estate';
import { EstateService } from '../_services/estate/estate.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  estates: Estate[];
  constructor(private http: HttpClient, private estateService: EstateService) { }

  ngOnInit() {
    this.getEstates();
  }

  registerToggle() {
    this.registerMode = true;
  }

  getEstates() {
   this.estateService.getEstates().subscribe((estates: Estate[]) => {
      this.estates = estates;
   });
  }
}
