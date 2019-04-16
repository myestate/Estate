import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estate } from 'src/app/_models/estate';
import { PaginatedResult } from '../../_models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EstateService {
  baseUrl = environment.apiUrl + 'estates/';

constructor(private http: HttpClient) { }

  getEstates(page?, itemsPerPage?): Observable<PaginatedResult<Estate[]>> {
    const paginatedResult: PaginatedResult<Estate[]> = new PaginatedResult<Estate[]>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }
    return this.http.get<Estate[]>(this.baseUrl, { observe: 'response', params }).pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
  }

  getEstate(id: number): Observable<Estate> {
    return this.http.get<Estate>(this.baseUrl + id);
  }

  addEstate(model: Estate) {
    return this.http.post(this.baseUrl, model);
  }

  getEstatesAddress(): Observable<Estate[]> {
    return this.http.get<Estate[]>(this.baseUrl + 'address');
  }
}
