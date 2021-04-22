import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DangnhapdangkyComponent } from './dangnhapdangky/dangnhapdangky.component';
import { GiohangComponent } from './giohang/giohang.component';
import { HomeComponent } from './home/home.component';
import { Page404Component } from './layouts/page404/page404.component';
import { DanhsachComponent } from './sanpham/danhsach/danhsach.component';
import { WishlistComponent } from './wishlist/wishlist.component';


const routes: Routes = [
  {path:'',component:HomeComponent},
  
  {path:'login',component:DangnhapdangkyComponent},
  {path:'shop',loadChildren:()=>import('./sanpham/sanpham.module').then(x=>x.SanphamModule)},
  {path:'customer',loadChildren:()=>import('./khachhang/khachhang.module').then(x=>x.KhachhangModule)},
  {path:'cart',loadChildren:()=>import('./giohang/giohang.module').then(x=>x.GiohangModule)},
  {path:'wishlist',component:WishlistComponent},
  {path:'**',component:Page404Component}
  
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
