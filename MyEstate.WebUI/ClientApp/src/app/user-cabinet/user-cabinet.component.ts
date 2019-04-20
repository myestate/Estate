import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user/user.service';
import { AlertifyService } from 'src/app/_services/alertify/Alertify.service';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth/auth.service';

@Component({
  selector: 'app-user-cabinet',
  templateUrl: './user-cabinet.component.html',
  styleUrls: ['./user-cabinet.component.css']
})
export class UserCabinetComponent implements OnInit {
  user: User;
  toogleHelp: boolean;
  toogleSetting: boolean;
  photoUrl: string;
  constructor(private userService: UserService, private alertify: AlertifyService,
    private route: Router, private authService: AuthService) { }

  ngOnInit() {
   this.getUserInfo();
  }

  getUserInfo() {
    this.userService.getUser(this.authService.decodedToken.nameid).subscribe((user: User) => {
      this.user = user;
      this.photoUrl = this.user.photoUrl;
      console.log(this.user.photoUrl);
    });
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.route.navigate(['/home']);
  }

}
