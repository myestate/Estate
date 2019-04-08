import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AlertifyService } from '../_services/alertify/Alertify.service';
import { google, LatLng } from '@agm/core/services/google-maps-types';
import { Observable } from 'rxjs';
import { MapService } from '../_services/map/map.service';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  lat: any;
  lng: any;
  constructor(private alertify: AlertifyService, private mapService: MapService) {
    if (navigator) {
      navigator.geolocation.getCurrentPosition( pos => {
        this.lng = +pos.coords.longitude;
        this.lat = +pos.coords.latitude;
      });
    }
    }

  ngOnInit() {
    this.getCoordinate('Львів, Лукаша, 4');
  }

  getCoordinate(address: string) {
    this.mapService.getCoordinate(address).subscribe((response) => {
      console.log(response.results[0].geometry.location.lat);
      console.log(response.results[0].geometry.location.lng);
      this.lat = response.results[0].geometry.location.lat;
      this.lng = response.results[0].geometry.location.lng;
    });
  }
}
