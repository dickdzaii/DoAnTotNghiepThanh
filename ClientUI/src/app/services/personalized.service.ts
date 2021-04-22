import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonalizedService {
  private itemsSubject = new BehaviorSubject<any[]>([]);
  items = this.itemsSubject.asObservable();
  constructor() {
    let local_storage = JSON.parse(localStorage.getItem('sp-vua-xem'));
    let Spvuaxem:any[];
    if (!local_storage) {
      local_storage = [];
    }
    if(!Spvuaxem){ 
      Spvuaxem=[];
    }
    this.itemsSubject.next(local_storage); 
  }
  Sanphamvuaxem(sp){
    let local_storage:any;
    let spvuaxem:any;
    if (localStorage.getItem('psnlz'+'makhach') == null) {
      local_storage = [sp];
    }
  }
  addToCart(item) {
    debugger;
    item.quantity = 1;
    let local_storage:any;
    if (localStorage.getItem('cart') == null) {
      local_storage = [item];
    } else {
      local_storage = JSON.parse(localStorage.getItem('cart'));
      let ok = true;
      for (let x of local_storage) {
        if (x.item_id == item.item_id) {
          x.quantity += 1;
          ok = false;
          break;
        }
      }
      if(ok){
        local_storage.push(item); 
      } 
    }
    localStorage.setItem('cart', JSON.stringify(local_storage));
    this.itemsSubject.next(local_storage);
  }

  getItems() {
    if (localStorage.getItem('cart') == null) {
      return [];
    } else {
      return JSON.parse(localStorage.getItem('cart'));
    }
  }

  deleteItem(item_id) {
    let local_storage = this.getItems().filter((x) => x.item_id != item_id);
    localStorage.setItem('cart', JSON.stringify(local_storage));
    this.itemsSubject.next(local_storage);
  }

  addQty(item) {
    let local_storage = JSON.parse(localStorage.getItem('cart'));
    for (let x of local_storage) {
      if (x.item_id == item.item_id) {
        x.quantity = item.quantity;
        break;
      }
    }
    localStorage.setItem('cart', JSON.stringify(local_storage));
    this.itemsSubject.next(local_storage);
  }

}
