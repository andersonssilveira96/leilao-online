import { Injectable } from '@angular/core';

@Injectable()
export class AppService {
    token: string = sessionStorage.getItem('token');

    deslogar() {
        this.token = '';
        sessionStorage.removeItem('token');
    }
}