import { Component, OnInit, Input } from '@angular/core';
import { Estate } from '../../_models/estate';
import { EstateService } from '../../_services/estate/estate.service';
import { AlertifyService } from '../../_services/alertify/Alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-estates-detail',
  templateUrl: './estates-detail.component.html',
  styleUrls: ['./estates-detail.component.css']
})
export class EstatesDetailComponent implements OnInit {
  @Input() type: string;
  estate: Estate;
  id: number;
  constructor(private estateService: EstateService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.id = data['id'];
    });
    this.loadEstate(this.id);
  }

  loadEstate(id: number) {
    this.estateService.getEstate(id).subscribe((estate: Estate) => {
      this.estate = estate;
    }, error => {
      this.alertify.error(error);
    });
  }

}
