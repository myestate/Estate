import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { google, LatLng, Geometry, GoogleMap } from '@agm/core/services/google-maps-types';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  lat: any;
  lng: any;
  baseUrl =  environment.googleMapAPIUrl;

  constructor(private http: HttpClient) {
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
    this.http.get<GoogleMap>(this.baseUrl + 'address=' + address + '&key=' + environment.googleMapAPIKey)
      .subscribe((res: GoogleMap) => {
        console.log(res);
      });
  }
}
