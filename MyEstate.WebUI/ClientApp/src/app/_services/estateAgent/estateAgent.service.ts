import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EstateAgent } from 'src/app/_models/estateAgent';

@Injectable({
  providedIn: 'root'
})
export class EstateAgentService {
  baseUrl = environment.apiUrl + 'estateAgents/';

constructor(private http: HttpClient) { }

  getEstateAgents(): Observable<EstateAgent[]> {
    return this.http.get<EstateAgent[]>(this.baseUrl);
  }

  getEstateAgent(id: number): Observable<EstateAgent> {
    return this.http.get<EstateAgent>(this.baseUrl + id);
  }

  addEstateAgent(model: EstateAgent) {
    return this.http.post(this.baseUrl, model);
  }

}
