import { Component, OnInit } from '@angular/core';
import { EstateAgent } from 'src/app/_models/estateAgent';
import { EstateAgentService } from '../../_services/estateAgent/estateAgent.service';
import { AlertifyService } from '../../_services/alertify/Alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-estate_agents',
  templateUrl: './estate_agents.component.html',
  styleUrls: ['./estate_agents.component.css']
})
export class Estate_agentsComponent implements OnInit {

  estateAgents: EstateAgent[];

  constructor(private estateAgentService: EstateAgentService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.estateAgents = data['estateAgents'];
    });
  }

  loadEstates() {
    this.estateAgentService.getEstateAgents().subscribe((estateAgents: EstateAgent[]) => {
      this.estateAgents = estateAgents;
    }, error => {
      this.alertify.error(error);
    });
  }

}



