import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estate } from '../_models/estate';

@Injectable({
  providedIn: 'root'
})
export class EstateService {
  baseUrl = environment.apiUrl + 'estates/';

  constructor(private http: HttpClient) { }

  getEstates(): Observable<Estate[]> {
    return this.http.get<Estate[]>(this.baseUrl);
  }

  getEstate(id: number): Observable<Estate> {
    return this.http.get<Estate>(this.baseUrl + id);
  }

  addEstate(model: any) {
    return this.http.post(this.baseUrl + 'addestate', model);
  }
}
