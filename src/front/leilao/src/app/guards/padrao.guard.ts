import { CanActivate, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { AppService } from '../services/app.service';

@Injectable()
export class PadraoGuard implements CanActivate {
   
    constructor(private _appService: AppService, private _router: Router) { }

    canActivate() {
        return this._appService.token ? true : this._router.navigate(['/login']);
    }
}