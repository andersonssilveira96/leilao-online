import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Md5 } from 'ts-md5';
import { IRetorno } from '../interfaces/IRetorno';
import { IUsuario } from '../interfaces/IUsuario';
import { AppService } from '../services/app.service';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public form: FormGroup = new FormGroup({
    email: new FormControl(),
    senha: new FormControl()
  });

  constructor(private _usuarioService: UsuarioService, 
    private _appService: AppService,
    private _router: Router,
    private _toastr: ToastrService) { } 

  ngOnInit() { }

  logar() {

    if(!this.form.valid) 
      return this._toastr.warning('formulário inválido!'); 
          
    const md5 = new Md5();

    let usuario: IUsuario = {   
      email: this.form.controls.email.value,        
      senha: md5.appendStr(this.form.controls.senha.value).end()
    }

    this._usuarioService.autenticar(usuario)
          .subscribe((data: IRetorno) => {
              this._appService.token = data.mensagem;
              sessionStorage.setItem('token', this._appService.token)           
              this._router.navigate(['/home']);        
          },
          (data) => {                   
              this._toastr.warning(data.error.mensagem);           
          });
  }

}
