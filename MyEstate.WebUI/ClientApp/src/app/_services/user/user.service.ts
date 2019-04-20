import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../../_models/user';
import {JwtHelperService} from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'users/getusers');
  }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }

  getUserInfo(): Observable<User> {
    const headers = new HttpHeaders();

    const token = localStorage.getItem('token');
    headers.append('Authorization', token);

    return this.http.get<User>(this.baseUrl + 'users/getuserinfo', { headers: headers });
  }

  updateUserInfo(user: User): Observable<User>  {
    return this.http.put<User>(this.baseUrl + 'users', user);
  }
}
