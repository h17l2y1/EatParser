import { Component, OnInit } from '@angular/core';
import { SetService } from 'src/app/shared/service/set.service';
import { RolsView } from 'src/app/shared/model/rol/rols.view';

@Component({
  selector: 'app-set',
  templateUrl: './set.component.html',
  styleUrls: ['./set.component.css']
})
export class SetComponent implements OnInit {

  public allRolSetView: RolsView;

  constructor(private setService: SetService) { }

  ngOnInit() {
  }

}
