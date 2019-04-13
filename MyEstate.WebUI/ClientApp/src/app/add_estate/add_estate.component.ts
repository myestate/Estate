import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { AlertifyService } from '../_services/alertify/Alertify.service';
import { NgForm } from '@angular/forms';
import { Estate } from '../_models/estate';
import { AnimationStyleMetadata } from '@angular/animations';
import { EstateService } from '../_services/estate/estate.service';

@Component({
  selector: 'app-add_estate',
  templateUrl: './add_estate.component.html',
  styleUrls: ['./add_estate.component.css']
})
export class Add_estateComponent implements OnInit {
  @Output() cancelAdding = new EventEmitter();
  model: Estate;

  constructor(private addService: EstateService, private alertify: AlertifyService) {   }

  ngOnInit() {
  }

  add_estate() {
    this.addService.addEstate(this.model).subscribe(() => {
      this.alertify.success('Estate successfully added');
    }, error => {
     this.alertify.error(error);
    });
    console.log(this.model);
  }

  cancel() {
    this.cancelAdding.emit(false);
  }
}

