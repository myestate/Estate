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
    this.getLastAddedEstate(6);
  }

  registerToggle() {
    this.registerMode = true;
  }

  getLastAddedEstate(num: number) {
   for (let index = 0; index < num; index++) {
    this.estateService.getEstate(index).subscribe((estate: Estate) => {
      this.estates[index] = estate;
    });
   }
  }
}
