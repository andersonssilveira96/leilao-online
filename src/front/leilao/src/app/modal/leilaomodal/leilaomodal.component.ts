import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ILeilao } from 'src/app/interfaces/ILeilao';
import { LeilaoService } from 'src/app/services/leilao.service';

@Component({
  selector: 'app-leilaomodal',
  templateUrl: './leilaomodal.component.html',
  styleUrls: ['./leilaomodal.component.scss']
})
export class LeilaomodalComponent implements OnInit {

  public form: FormGroup = new FormGroup({
    id: new FormControl(),
    nome: new FormControl(),
    valorInicial: new FormControl(), 
    usado: new FormControl(), 
    usuarioResponsavelId: new FormControl(),
    usuario: new FormControl(),
    dataAbertura: new FormControl(),
    dataFinalizacao: new FormControl()
  });

  public leilao: ILeilao;
  public readonly: boolean;
  
  constructor(@Inject(MAT_DIALOG_DATA) public data: any, 
              private _leilaoService: LeilaoService,
              private _toastr: ToastrService,
              public dialog: MatDialog) { }


  ngOnInit(): void {

    this.leilao = this.data.leilao;
    this.readonly = this.data.visualizar; 

    if(!this.leilao)
      return;
      
    this._leilaoService.obterPorId(this.leilao.id)
            .subscribe((data) => {
                this.form = new FormGroup({
                  id: new FormControl({ value: data?.id, disabled: this.readonly }),
                  nome: new FormControl({ value: data?.nome, disabled: this.readonly }),
                  valorInicial: new FormControl({ value: data?.valorInicial, disabled: this.readonly }), 
                  usado: new FormControl({ value: data?.usado, disabled: this.readonly }), 
                  usuarioResponsavelId: new FormControl({ value: data?.usuarioResponsavelId, disabled: this.readonly }),
                  usuario: new FormControl({ value: data?.usuario, disabled: true }),
                  dataAbertura: new FormControl({ value: new Date(data?.dataAbertura), disabled: this.readonly }),
                  dataFinalizacao: new FormControl({ value: new Date(data?.dataFinalizacao),  disabled: this.readonly })
                });
            });   
  }

  salvar() {
    let leilao: ILeilao = {
      id: this.form.controls.id.value,
      nome: this.form.controls.nome.value,
      dataAbertura: this.form.controls.dataAbertura.value,
      dataFinalizacao: this.form.controls.dataFinalizacao.value,
      usado: this.form.controls.usado.value ?? false,
      valorInicial: this.form.controls.valorInicial.value,
      usuarioResponsavelId: this.form.controls.usuarioResponsavelId.value,
      usuario: this.form.controls.usuario.value,
      encerrado: false
    };

    if(this.leilao?.id)
      this.editar(leilao);
    else
      this.cadastrar(leilao);
  }
  
  editar(leilao: ILeilao) {
    this._leilaoService.atualizar(leilao)
          .subscribe((data) => {
            this._toastr.success(data.mensagem);
            this.dialog.closeAll();
          },
          (data) => {
            for(var item of data.error.erros) {
              this._toastr.warning(item);
            }
          });
  }

  cadastrar(leilao: ILeilao) {
   
    if(!this.form.valid)
      return this._toastr.warning('Formulário inválido, todos os campos são obrigatórios');
  
    this._leilaoService.adicionar(leilao)
        .subscribe((data) => {
          this._toastr.success(data.mensagem);
          this.dialog.closeAll();
        },
        (data) => {         
          for(var item of data.error.erros) {
            this._toastr.warning(item);
          }
        });
  }
}
