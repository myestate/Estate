import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user/user.service';
import { AlertifyService } from 'src/app/_services/alertify/Alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-cabinet',
  templateUrl: './user-cabinet.component.html',
  styleUrls: ['./user-cabinet.component.css']
})
export class UserCabinetComponent implements OnInit {

  user: User;

  constructor(private userService: UserService, private alertify: AlertifyService,
    private route: Router) { }

  ngOnInit() {
    this.userService.getUserInfo().subscribe((response: any) => {
      this.user = response;
    }, error => {
      this.alertify.error(error);
    });
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.route.navigate(['/home']);
  }

}
