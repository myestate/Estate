import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { AlertifyService } from '../_services/alertify/Alertify.service';
import { NgForm, } from '@angular/forms';
import { Estate } from '../_models/estate';
import { AnimationStyleMetadata } from '@angular/animations';
import { EstateService } from '../_services/estate/estate.service';
import { UserService } from '../_services/user/user.service';
import {FileUploader} from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Photo } from '../_models/photo';
import { FormControl } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';


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
     addressForm: FormGroup;
     estateForm: FormGroup;
     sellingForm: FormGroup;

  constructor(private addService: EstateService, private alertify: AlertifyService,
      private authService: AuthService) {   }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  ngOnInit() {
    this.initializeUploader();
    this.addressForm = new FormGroup({
    country: new FormControl('', Validators.required),
    city:  new FormControl('', Validators.required),
    street:  new FormControl('', Validators.required),
    region: new FormControl(),
    building: new FormControl('', Validators.min(0)),
   });
   console.log(this.authService.decodedToken.nameid);
   this.estateForm = new FormGroup({
    title: new FormControl('', Validators.required),
    description:  new FormControl('', Validators.required),
    square:  new FormControl('', Validators.required || Validators.min(0)),
    rooms: new FormControl('', Validators.required || Validators.min(0)),
    floors: new FormControl('', Validators.min(0)),
    flat: new FormControl()
   });

   this.sellingForm = new FormGroup({
    type: new FormControl('', Validators.required),
    price: new FormControl('', Validators.min(0) || Validators.required)
   });
  }

  Capitalize(str: string) {
    return str.charAt(0).toUpperCase() + str.slice(1);
  }

  add_estate() {
    if (this.addressForm.valid && this.sellingForm.valid && this.estateForm.valid) {
      this.estate = Object.assign({}, this.addressForm.value, this.estateForm.value, this.sellingForm.value);
      this.estate.isActive = true;
      this.addService.addEstate(this.estate).subscribe(() => {
      console.log(this.estate.type);
      this.alertify.success('Estate successfully added');
      this.uploader.uploadAll();
    }, error => {
     this.alertify.error(error);
    });
    }
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'estates/' + this.authService.decodedToken.nameid + '/photos',
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
