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
  private headers: HttpHeaders;

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

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
    return this.http.put<User>(this.baseUrl + 'users/' + user.id, user, {headers: this.headers});
  }

  updateUserPassword(oldPassword: string, newPassword: string): Observable<User>  {
    const headers = new HttpHeaders();

    const token = localStorage.getItem('token');
    headers.append('Authorization', token);
    const passwordInfo = {oldPass: oldPassword, newPass: newPassword };

    return this.http.post<User>(this.baseUrl + 'users', passwordInfo, {headers: headers});
  }
}
