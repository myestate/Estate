import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user/user.service';
import { AlertifyService } from 'src/app/_services/alertify/Alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dropdown-menu',
  templateUrl: './dropdown-menu.component.html',
  styleUrls: ['./dropdown-menu.component.css']
})
export class DropdownMenuComponent implements OnInit {

  public user: User = new User();
    constructor(
    private userService: UserService,
    private alertify: AlertifyService,
    private router: Router) {
      this.userService.getUserInfo().subscribe((response: any) => {
        console.log('test ', response);
        this.user = response;
      }, error => {
        this.alertify.error(error);
      });
  }
  ngOnInit() {
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }

  deleteandlogout() {
    localStorage.removeItem('token');
    this.alertify.message('account has been deleted');
    this.router.navigate(['/home']);
  }
}
