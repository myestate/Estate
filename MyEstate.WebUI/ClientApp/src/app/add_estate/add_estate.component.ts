import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { AlertifyService } from '../_services/alertify/Alertify.service';
import { NgForm } from '@angular/forms';
import { Estate } from '../_models/estate';
import { AnimationStyleMetadata } from '@angular/animations';
import { EstateService } from '../_services/estate/estate.service';
import { UserService } from '../_services/user/user.service';
import { getBaseUrl } from 'src/main';

@Component({
  selector: 'app-add-estate',
  templateUrl: './add_estate.component.html',
  styleUrls: ['./add_estate.component.css']
})
export class AddEstateComponent implements OnInit {
  @Output() cancelAdding = new EventEmitter();
  estate: Estate = new Estate();
  model: any = {};

  constructor(private addService: EstateService, private alertify: AlertifyService) {   }

  ngOnInit() {
  }

  add_estate() {
    this.estate.isActive = true;
    this.estate.description = `Region: ${this.model.region}\nCondition: ${this.model.condition}\n
    Balcony: ${this.model.Balcony}\nWalls: ${this.model.Walls}\nHouse type: ${this.model.type}`;
    this.estate.street += `, ${this.model.building}`;
    this.addService.addEstate(this.estate).subscribe(() => {
      this.alertify.success('Estate successfully added');
    }, error => {
     this.alertify.error(error);
    });
    console.log(this.estate);
    console.log(this.estate.photos);
  }

  addPhoto(event) {
    let target = event.target || event.srcElement;
    this.estate.photos = target.files;
}

  cancel() {
    this.cancelAdding.emit(false);
  }
}

