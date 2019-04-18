import { Component, OnInit, Input } from '@angular/core';
import { Estate } from '../../_models/estate';
import { EstateService } from '../../_services/estate/estate.service';
import { AlertifyService } from '../../_services/alertify/Alertify.service';
import { ActivatedRoute, Params } from '@angular/router';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user/user.service';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-estates-detail',
  templateUrl: './estates-detail.component.html',
  styleUrls: ['./estates-detail.component.css']
})
export class EstatesDetailComponent implements OnInit {
  @Input() type: string;
  estate: Estate;
  user: User;
  havePhotos: boolean = false;

  id: number;
  constructor(private userService: UserService, private estateService: EstateService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
    });
    this.loadEstate(this.id);
  }

  loadEstate(id: number) {
    this.estateService.getEstate(id).subscribe((estate: Estate) => {
      this.estate = estate;
      if (estate.photos.length!==0) {
        this.havePhotos = true;
      }
      this.userService.getUser(estate.ownerId).subscribe((user: User) => {
        this.user = user;
      });
    }, error => {
      this.alertify.error(error);
    });
  }

}
