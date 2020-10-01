import { DOCUMENT } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  
  public mostrar: boolean;

  constructor(private router: Router, @Inject(DOCUMENT) private _document: Document) { 
    
    this.router.events.subscribe(
      (event: any) => {
        if (event instanceof NavigationEnd) {
          if(this.router.url.indexOf('login') > -1) {
            this._document.body.classList.replace('no-background','background'); 
            this.mostrar = false;   
          }           
          else {
            this._document.body.classList.replace('background','no-background');
            this.mostrar = true;
          }           
        }
      }
    );
  }  

}
