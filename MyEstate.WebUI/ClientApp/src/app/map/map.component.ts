import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify/Alertify.service';
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
  estates: Estate[] = [];
  constructor(private alertify: AlertifyService, private mapService: MapService, private estateService: EstateService) {
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
    this.estateService.getEstatesAddress().subscribe((estates: Estate[]) => {
      estates.forEach(estate => {
        this.addCoordinates(estate.country + ',' + estate.city + ',' + estate.street, estate);
      });
    });
  }

  addCoordinates(address: string, estate: Estate) {
    this.mapService.getCoordinate(address).subscribe((response) => {
      estate.location = response.results[0].geometry.location;
      this.estates.push(estate);
    });
  }

  findPlace(address: string) {
    this.mapService.getCoordinate(address).subscribe((response) => {
      this.lat = response.results[0].geometry.location.lat;
      this.lng = response.results[0].geometry.location.lng;
      this.alertify.message('Now you are in ' + address);
  });
}
}
