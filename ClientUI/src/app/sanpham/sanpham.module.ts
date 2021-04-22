import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DanhsachComponent } from './danhsach/danhsach.component';
import { ChitietComponent } from './chitiet/chitiet.component';
import { SanphamRoutingModule} from '../sanpham/sanpham-routing.module';
import { SptheoloaiComponent } from './sptheoloai/sptheoloai.component';
import { SptheohangComponent } from './sptheohang/sptheohang.component';
import {  ReactiveFormsModule } from '@angular/forms';
import { Sanphamtheoloai2Component } from './sanphamtheoloai2/sanphamtheoloai2.component';
import { SanphamComponent } from './sanpham.component';
import { LayoutsModule } from '../layouts/layouts.module';
import { SpcungloaiComponent } from './spcungloai/spcungloai.component';
import { Sanphamtheoloai1Component } from './sanphamtheoloai1/sanphamtheoloai1.component';



@NgModule({
  declarations: [
    SanphamComponent,
    DanhsachComponent,
    ChitietComponent,
     SptheoloaiComponent, 
     SptheohangComponent, Sanphamtheoloai2Component, SpcungloaiComponent, Sanphamtheoloai1Component
  ],
  imports: [
    CommonModule,
SanphamRoutingModule,
ReactiveFormsModule,LayoutsModule
  ]
})
export class SanphamModule { }