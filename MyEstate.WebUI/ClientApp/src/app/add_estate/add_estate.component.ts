import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { AlertifyService } from '../_services/alertify/Alertify.service';
import { NgForm } from '@angular/forms';
import { Estate } from '../_models/estate';
import { AnimationStyleMetadata } from '@angular/animations';
import { EstateService } from '../_services/estate/estate.service';
import { UserService } from '../_services/user/user.service';
import { getBaseUrl } from 'src/main';
import { NG_TRIGGER_CLASSNAME } from '@angular/animations/browser/src/util';

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

  Capitalize(str: string) {
    return str.charAt(0).toUpperCase() + str.slice(1);
  }

  add_estate() {
    this.estate.isActive = true;
    this.estate.country = this.Capitalize(this.estate.country);
    this.estate.city = this.Capitalize(this.estate.city);
    this.estate.street = this.Capitalize(this.estate.street);
    this.estate.description = `Region: ${this.model.region}\nCondition: ${this.model.condition}\n` +
    `Balcony: ${this.model.balcony}\nWalls: ${this.model.walls}\nHouse type: ${this.model.type}`;
    this.estate.street += `, ${this.model.building}`;
    
    this.addService.addEstate(this.estate).subscribe(() => {
      this.alertify.success('Estate successfully added');
    }, error => {
     this.alertify.error(error);
    });
    console.log(this.estate);
    console.log(this.estate.photos);
  }

  cancel() {
    this.cancelAdding.emit(false);
  }
}

