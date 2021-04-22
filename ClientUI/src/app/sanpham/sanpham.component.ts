import { Component, OnInit,Injector,Output } from '@angular/core';
import { BaseComponent } from '../services/base.component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import {Observable, Subject, of, from} from 'rxjs';

@Component({
  selector: 'app-sanpham',
  templateUrl: './sanpham.component.html',
  styleUrls: ['./sanpham.component.css']
})

export class SanphamComponent extends BaseComponent implements OnInit {
  constructor(injector: Injector) { 
    super(injector);
  }
  list_item:any;
  menus2:any;
  ngOnInit(): void {

    this._api.get('api/Loai/all-with-children').takeUntil(this.unsubscribe).subscribe(res => {
      this.menus2 = res;
     
    }); 
  }


}
