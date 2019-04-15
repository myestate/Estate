import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AlertifyService } from '../_services/alertify/Alertify.service';
import { google, LatLng } from '@agm/core/services/google-maps-types';
import { Observable } from 'rxjs';
import { MapService } from '../_services/map/map.service';
import { EstateService } from '../_services/estate/estate.service';
import { Estate } from '../_models/estate';
import { Location } from '../_models/geocode_data';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  lat: any;
  lng: any;
  address: string;
  estatesCoordinate: Location[] = [];

  constructor(private alertify: AlertifyService, private mapService: MapService, private estates: EstateService) {
    if (navigator) {
      navigator.geolocation.getCurrentPosition( pos => {
        this.lng = +pos.coords.longitude;
        this.lat = +pos.coords.latitude;
      });
    }
    }

  ngOnInit() {
    this.getAddresses();
  }

  getAddresses() {
    this.estates.getEstatesAddress().subscribe((estates: Estate[]) => {
      estates.forEach(estate => {
        this.getCoordinate(estate.country + ',' + estate.city + ',' + estate.street);
      });
    });
  }

  getCoordinate(address: string) {
    this.mapService.getCoordinate(address).subscribe((response) => {
      this.estatesCoordinate.push(response.results[0].geometry.location);
    });
  }

  findPlace(address: string) {
    this.mapService.getCoordinate(address).subscribe((response) => {
      this.lat = response.results[0].geometry.location.lat;
      this.lng = response.results[0].geometry.location.lng;
  });
}
}
