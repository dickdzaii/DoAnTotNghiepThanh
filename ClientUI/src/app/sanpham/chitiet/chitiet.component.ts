import { Component, OnInit,NgModule,Injector } from '@angular/core';
import { BaseComponent } from '../../services/base.component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import {Observable, Subject, of, from} from 'rxjs'
import { MinLengthValidator } from '@angular/forms';

@Component({
  selector: 'app-chitiet',
  templateUrl: './chitiet.component.html',
  styleUrls: ['./chitiet.component.css']
})
export class ChitietComponent extends BaseComponent implements OnInit {
 item:any;
 sptuongtu:any;
  constructor(injector: Injector) { 
    super(injector);
  }
  ngOnInit(): void {
    document.title='Chi tiết sản phẩm';
   this.item = {};
   this.sptuongtu=[];
    this._route.params.subscribe(params => {
      let id = params['id'];
      this._api.get('api/QLSanPham/detail/'+id).takeUntil(this.unsubscribe).subscribe(res => {
        this.item = res;
   
      }); 
    });
      
   }
   addToCart2(sl,it){
    
      this._cart.addToCart2(sl,it);
      alert('đã thêm '+sl+' sản phẩm vào giỏ hàng')
    }
   
}
