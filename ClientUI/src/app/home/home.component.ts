import { Component, OnInit, AfterViewInit, Injector } from '@angular/core';
import { BaseComponent } from '../services/base.component';
import { Observable } from 'rxjs';
import {  combineLatest } from 'rxjs';
import 'rxjs/add/operator/takeUntil';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent extends BaseComponent implements OnInit {
  dmuccha:any; 
  spchay:any;
  thang:any;

  constructor(injector: Injector) { 
    super(injector);
  }
 
  ngOnInit(): void {
    document.title='Trang chủ - Emarket';
    this.thang=0;
    this._api.get('api/Loai/all-with-children').takeUntil(this.unsubscribe).subscribe(res => {
      this.dmuccha = res;
      setTimeout(() => {
        this.loadScripts();
       });
    });
    this.spBanChay(); 
   
}

 spBanChay(){
   this.thang=new Date();
   let t=this.thang.getMonth()+1;
  this._api.get('api/QLSanPham/ban-chay/s0001/'+t).takeUntil(this.unsubscribe).subscribe(res => {
    this.spchay = res;

  }); 
 } 
  addToCart(it) { 
    this._cart.addToCart(it);
    alert('Thêm thành công!'); 
  }
  addToWishlist(it) { 
    this._wishlist.addToWishlist(it);
    alert('đã thêm vào danh sách yêu thích!'); 
  }

}