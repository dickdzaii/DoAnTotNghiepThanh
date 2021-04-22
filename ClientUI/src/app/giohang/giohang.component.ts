import { Component, OnInit,Injector } from '@angular/core';
import { BaseComponent } from '../services/base.component';
import { Observable } from 'rxjs';
import {  combineLatest } from 'rxjs';
@Component({
  selector: 'app-giohang',
  templateUrl: './giohang.component.html',
  styleUrls: ['./giohang.component.css']
})
export class GiohangComponent extends BaseComponent implements  OnInit {
  cartitems:any;
  total:any;
  constructor(injector: Injector) { 
    super(injector);
  }

  ngOnInit(): void {
    document.title='Giỏ hàng';
    this._cart.items.subscribe((res) => {
      this.cartitems = res;
      this.total = 0;
      for(let x of this.cartitems){ 
        x.money = Number.parseInt(x.quantity) * Number.parseInt(x.giahientai.gia);
        this.total += x.quantity * x.giahientai.gia;
       
      }  
    });setTimeout(() => {
      this.loadScripts();
    },);
  } 
  clearCart() { 
    this._cart.clearCart();
    alert('Xóa thành công');
  }
  deleteItem(item){
    this._cart.deleteItem(item);
  
  }
  addQty(item, quantity){ 
    item.quantity =  quantity;
    item.money =  Number.parseInt(item.quantity) *  item.item_price;
    this._cart.addQty(item);
  }
}