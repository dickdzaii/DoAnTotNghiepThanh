import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { KhachhangRoutingModule } from './khachhang.routing-module';
import { TaikhoanComponent } from './taikhoan/taikhoan.component';
import { KhachhangComponent } from './khachhang.component';

import { DsdonhangComponent } from './dsdonhang/dsdonhang.component';
import { CtdonhangComponent } from './ctdonhang/ctdonhang.component';
import { LayoutsModule } from '../layouts/layouts.module';
import { DiachiComponent } from './diachi/diachi.component';




@NgModule({
  declarations: [
    TaikhoanComponent,
    KhachhangComponent,
  
    DsdonhangComponent,
    CtdonhangComponent,
    DiachiComponent
  ],
  imports: [
    CommonModule,
KhachhangRoutingModule,LayoutsModule
  ]
})
export class KhachhangModule { }