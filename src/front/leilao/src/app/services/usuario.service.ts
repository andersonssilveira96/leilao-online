import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUsuario } from '../interfaces/IUsuario';

@Injectable()
export class UsuarioService {

    constructor(private _httpClient: HttpClient) {  }
    
    autenticar(obj: IUsuario) : Observable<any> {
        return this._httpClient.post(`usuario`, obj)
    }
   
}