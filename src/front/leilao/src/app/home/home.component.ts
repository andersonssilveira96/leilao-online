import { Component, OnInit } from '@angular/core';
import { ILeilao } from '../interfaces/ILeilao';
import { LeilaomodalComponent } from '../modal/leilaomodal/leilaomodal.component';
import { LeilaoService } from '../services/leilao.service';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ITabela } from '../interfaces/ITabela';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public leiloes: ILeilao[] = [];  
  public campos: ITabela[] = [];

  constructor(private _leilaoService: LeilaoService, 
    private _toastr: ToastrService, 
    public dialog: MatDialog) { }
  
  ngOnInit(): void {
    this.carregarCampos();
    this.carregarLeiloes();
  }

  carregarLeiloes() {
    this._leilaoService.obterTodos()
            .subscribe((data) => {
                this.leiloes = data;
            });
  }

  editar(item) {    
    this.openDialog(item);
  }

  visualizar(item) {    
    this.openDialog(item, true);
  }

  remover(item) {
    this._leilaoService.remover(item.id)
    .subscribe((data) => {
        this._toastr.success(data.mensagem);   
        this.carregarLeiloes();     
    });
  } 

  openDialog(leilao = null, visualizar = false) {
    const dialogRef = this.dialog.open(LeilaomodalComponent, {
      height: '310px',
      width: '600px',
      data: { leilao: leilao, visualizar: visualizar }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.carregarLeiloes();
    });
  }

  carregarCampos() {
    this.campos.push({ nome: 'nome', booleano: false, dinheiro: false, data: false, titulo: 'Nome' });
    this.campos.push({ nome: 'valorInicial', booleano: false, dinheiro: true, data: false, titulo: 'Valor Inicial' });    
    this.campos.push({ nome: 'usado', booleano: true, dinheiro: false, data: false, titulo: 'Usado' });    
    this.campos.push({ nome: 'usuario', booleano: false, dinheiro: false, data: false, titulo: 'Usuario' });    
    this.campos.push({ nome: 'encerrado', booleano: true, dinheiro: false, data: false, titulo: 'Encerrado' });    
  }

}
