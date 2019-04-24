import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user/user.service';
import { AlertifyService } from 'src/app/_services/alertify/Alertify.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth/auth.service';

@Component({
  selector: 'app-changepassword',
  templateUrl: './changepassword.component.html',
  styleUrls: ['./changepassword.component.css']
})
export class ChangepasswordComponent implements OnInit {

  user: User;
  passwordtype_old = 'password';
  passwordtype_new = 'password';
  oldPassword = '';
  newPassword = '';

  constructor(private userService: UserService, private alertify: AlertifyService,
    private router: Router, private authService: AuthService) { }

  ngOnInit() {
    this.getUserInfo();
  }

  getUserInfo() {
    this.userService.getUser(this.authService.decodedToken.nameid).subscribe((user: User) => {
      this.user = user;
    });
  }

  hideShow(password: string): string {
    if (password === 'password') {
      password = 'text';
    } else {
      password = 'password';
    }
    return password;
  }

  confirm_password() {
    this.userService.updateUserPassword(this.oldPassword, this.newPassword).subscribe((response: any) => {
      console.log(response);
      this.user = response;
      this.router.navigate(['/home']);
    }, error => {
    this.alertify.message('Password is incorect');
    });
  }

}
