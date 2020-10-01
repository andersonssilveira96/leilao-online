import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ILeilao } from '../interfaces/ILeilao';

@Injectable()
export class LeilaoService {

    constructor(private _httpClient: HttpClient) {  }

    obterTodos() : Observable<any> {
       return this._httpClient.get('leilao')
    }

    obterPorId(id: string) : Observable<any> {
        return this._httpClient.get(`leilao/${id}`)
    }

    remover(id: string) : Observable<any> {
        return this._httpClient.delete(`leilao/${id}`)
    }

    adicionar(obj: ILeilao) : Observable<any> {
        return this._httpClient.post(`leilao`, obj)
    }

    atualizar(obj: ILeilao) : Observable<any> {
        return this._httpClient.put(`leilao/${obj.id}`, obj)
    }
}