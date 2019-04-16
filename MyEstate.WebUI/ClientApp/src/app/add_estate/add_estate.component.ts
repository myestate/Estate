import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { AlertifyService } from '../_services/alertify/Alertify.service';
import { NgForm } from '@angular/forms';
import { Estate } from '../_models/estate';
import { AnimationStyleMetadata } from '@angular/animations';
import { EstateService } from '../_services/estate/estate.service';
import { UserService } from '../_services/user/user.service';
import {FileUploader} from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Photo } from '../_models/photo';

@Component({
  selector: 'app-add-estate',
  templateUrl: './add_estate.component.html',
  styleUrls: ['./add_estate.component.css']
})
export class AddEstateComponent implements OnInit {
  @Output() cancelAdding = new EventEmitter();
   uploader: FileUploader;
    estate: Estate = new Estate();
    model: any = {};
    photos: Photo[] = [];
    hasBaseDropZoneOver = false;
    baseUrl = environment.apiUrl;

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  constructor(private addService: EstateService, private alertify: AlertifyService,
      private authService: AuthService) {   }

  ngOnInit() {
    this.initializeUploader();
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

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'users/' + this.authService.decodedToken.nameid + '/photos',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };

    this.uploader.onSuccessItem = (item, responce, status, headers) => {
      if  (responce) {
        const res: Photo = JSON.parse(responce);
        const photo = {
          id: res.id,
          url: res.url,
          dateAdded: res.dateAdded,
          description: res.description,
          isMain: res.isMain
        };
        this.photos.push(photo);
      }
    };
  }

  cancel() {
    this.cancelAdding.emit(false);
  }
}

