import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { GeocodeData } from 'src/app/_models/geocode_data';
@Injectable()
export class MapService {
  baseUrl =  environment.googleMapAPIUrl;
  constructor(private http: HttpClient) {}

getCoordinate(address: string): Observable<GeocodeData> {
 return this.http.get<GeocodeData>(this.baseUrl + 'address=' + address + '&key=' + environment.googleMapAPIKey);
}
}
