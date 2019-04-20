import { Component, OnInit, Input } from '@angular/core';
import { Estate } from '../../_models/estate';
import { EstateService } from '../../_services/estate/estate.service';
import { AlertifyService } from '../../_services/alertify/Alertify.service';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-estates',
  templateUrl: './estates.component.html',
  styleUrls: ['./estates.component.css']
})

export class EstatesComponent implements OnInit {
  @Input() type: string;
  estates: Estate[];
  pagination: Pagination;
  estateParams: any = {};

  constructor(private estateService: EstateService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.pagination = <Pagination>{ currentPage : 1, itemsPerPage : 10}
    this.resetEstateParams();
    this.loadEstatesToPage();
  }

  resetFilters() {
    this.resetEstateParams();
    this.loadEstatesToPage();
  }

  resetEstateParams() {
    this.estateParams.type = this.type;
    this.estateParams.country = "";
    this.estateParams.city = "";
    this.estateParams.street = "";
    this.estateParams.minPrice = 0;
    this.estateParams.maxPrice = 5000000;
    this.estateParams.minSquare = 0;
    this.estateParams.maxSquare = 1000;
    this.estateParams.minRooms = 1;
    this.estateParams.maxRooms = 10;
    this.estateParams.minFloors = 1;
    this.estateParams.maxFloors = 50;
    this.estateParams.orderBy = "created";
  }

  loadEstates() {
    this.estateService.getEstates()
      .subscribe(
        (res: PaginatedResult<Estate[]>) => {
        this.estates = res.result;
        this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }


  loadEstatesToPage() {
    this.estateService.getEstates(this.pagination.currentPage, this.pagination.itemsPerPage, this.estateParams)
      .subscribe(
      (res: PaginatedResult<Estate[]>) => {
        this.estates = res.result;
        this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadEstatesToPage();
  }
}
