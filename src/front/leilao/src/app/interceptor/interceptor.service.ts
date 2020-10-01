import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppService } from '../services/app.service';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';

@Injectable()
export class Interceptor implements HttpInterceptor {
    constructor(private _appService: AppService, private _router: Router) { }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        request = request.clone({
            url: environment.url + request.url,
            setHeaders: {
                Authorization: `Bearer ${this._appService.token}`
            }
        });

        return next.handle(request).pipe(tap(() => {},
            (err: any) => {
                if (err instanceof HttpErrorResponse) {
                    if (err.status !== 401) {
                        return;
                    }
                    this._router.navigate(['login']);
                }
            }
        ));
    }
}