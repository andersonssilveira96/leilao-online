import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private _appService: AppService, private router: Router) { }

  ngOnInit(): void { }

  sair() {
    this._appService.deslogar();
    this.router.navigate(['/login']);
  }

}
