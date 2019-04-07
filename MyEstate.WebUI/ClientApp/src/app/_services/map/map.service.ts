import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class MapService {
  baseUrl =  environment.googleMapAPIUrl;
  constructor(private http: HttpClient) {}

getCoordinate(address: string) {
  this.http.get(this.baseUrl + 'address=' + address + '&key=' + environment.googleMapAPIKey)
    .subscribe((res) => {
      console.log(res);
    });
}
}
