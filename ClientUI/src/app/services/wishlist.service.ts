import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class WishlistService {
  private itemsSubject = new BehaviorSubject<any[]>([]);
  items = this.itemsSubject.asObservable();
  constructor() {
    let local_storage = JSON.parse(localStorage.getItem('wishlist'));
    if (!local_storage) {
      local_storage = [];
    }
    this.itemsSubject.next(local_storage); 
  }
  
  addToWishlist(item) {
  
    
    let local_storage:any;
    if (localStorage.getItem('wishlist') == null) {
      local_storage = [item];
    } else {
      local_storage = JSON.parse(localStorage.getItem('wishlist'));
      let ok = true;
      for (let x of local_storage) {
        if (x.maSanPham == item.maSanPham) {
         
          ok = false;
          break;
        }
      }
      if(ok){
        local_storage.push(item); 
      } 
    }
    localStorage.setItem('wishlist', JSON.stringify(local_storage));
    this.itemsSubject.next(local_storage);
  }

  getItems() {
    if (localStorage.getItem('wishlist') == null) {
      return [];
    } else {
      return JSON.parse(localStorage.getItem('wishlist'));
    }
  }

  deleteItem(maSanPham) {
    let local_storage = this.getItems().filter((x) => x.maSanPham != maSanPham);
    localStorage.setItem('wishlist', JSON.stringify(local_storage));
    this.itemsSubject.next(local_storage);
  }
 
  numberOfItems() {
    let local_storage = JSON.parse(localStorage.getItem('wishlist'));
    return local_storage.length;
  }

  clearWishlist() {
   localStorage.removeItem('wishlist');
   this.itemsSubject.next(null);
  }
}