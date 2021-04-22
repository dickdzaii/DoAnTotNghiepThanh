import { Component, OnInit,Injector } from '@angular/core';
import { BaseComponent } from 'src/app/services/base.component';

@Component({
  selector: 'app-page404',
  templateUrl: './page404.component.html',
  styleUrls: ['./page404.component.css']
})
export class Page404Component extends BaseComponent implements OnInit {

  constructor(injector: Injector) { 
    super(injector);
  }

  ngOnInit(): void {
    this.loadScripts();
  }

}
