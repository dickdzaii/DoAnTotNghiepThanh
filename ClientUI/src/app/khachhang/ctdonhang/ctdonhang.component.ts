import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/services/base.component';

@Component({
  selector: 'app-ctdonhang',
  templateUrl: './ctdonhang.component.html',
  styleUrls: ['./ctdonhang.component.css']
})
export class CtdonhangComponent extends BaseComponent implements OnInit {
donhang:any;
  constructor(injector:Injector) {
    super(injector);
  }

  ngOnInit(): void {
    this._route.params.subscribe(params => {
      let id = params['id'];
      this._api.get('api/qldonhang/by-id/'+id).takeUntil(this.unsubscribe).subscribe(res => {
        this.donhang = res;
        this.loadScripts();
      }); 
    });
  }

}
