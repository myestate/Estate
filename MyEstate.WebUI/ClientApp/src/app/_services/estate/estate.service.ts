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

  getEstates(page?, itemsPerPage?, estateParams?): Observable<PaginatedResult<Estate[]>> {
    const paginatedResult: PaginatedResult<Estate[]> = new PaginatedResult<Estate[]>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }
    if (estateParams != null) {
      params = params.append('type', estateParams.type);
      params = params.append('country', estateParams.country);
      params = params.append('city', estateParams.city);
      params = params.append('street', estateParams.street);
      params = params.append('minPrice', estateParams.minPrice);
      params = params.append('maxPrice', estateParams.maxPrice);
      params = params.append('minSquare', estateParams.minSquare);
      params = params.append('maxSquare', estateParams.maxSquare);
      params = params.append('minRooms', estateParams.minRooms);
      params = params.append('maxRooms', estateParams.maxRooms);
      params = params.append('minFloors', estateParams.minFloors);
      params = params.append('maxFloors', estateParams.maxFloors);
      params = params.append('orderBy', estateParams.orderBy);
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
