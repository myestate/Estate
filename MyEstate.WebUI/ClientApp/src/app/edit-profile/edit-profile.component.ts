import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user/user.service';
import { AlertifyService } from '../_services/alertify/Alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {
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
