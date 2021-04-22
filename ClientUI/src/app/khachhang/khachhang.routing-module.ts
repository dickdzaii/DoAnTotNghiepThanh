import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutsModule } from '../layouts/layouts.module';
import { CtdonhangComponent } from './ctdonhang/ctdonhang.component';
import { DiachiComponent } from './diachi/diachi.component';
import { DsdonhangComponent } from './dsdonhang/dsdonhang.component';
import { KhachhangComponent } from './khachhang.component';

import { TaikhoanComponent } from './taikhoan/taikhoan.component';


const routes: Routes = [
  {path:'',component:KhachhangComponent,
  children:[
    {path:'profile',component:TaikhoanComponent},
    {path:'addresses',component:DiachiComponent},
    {path:'orders',component:DsdonhangComponent},
    {path:'orders/:id',component:CtdonhangComponent}
  ]
},
 
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KhachhangRoutingModule { }
