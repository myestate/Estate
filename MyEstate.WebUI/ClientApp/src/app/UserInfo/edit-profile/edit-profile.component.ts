import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user/user.service';
import { AlertifyService } from 'src/app/_services/alertify/Alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent {
  public user: User = new User();
  username: string;

  constructor(private userService: UserService,
    private alertify: AlertifyService,
    private route: Router) {
      this.userService.getUserInfo().subscribe((response: any) => {
        this.user = response;
      }, error => {
        this.alertify.error(error);
      });
      // this.username = this.user === undefined ? 'Enter user name' : this.user.username;
     }

  confirm_profile_button()  {
    this.userService.updateUserInfo(this.user).subscribe((response: any) => {
      console.log(response);
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
