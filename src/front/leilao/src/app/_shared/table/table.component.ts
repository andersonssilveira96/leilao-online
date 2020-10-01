import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { ILeilao } from 'src/app/interfaces/ILeilao';
import { ITabela } from 'src/app/interfaces/ITabela';


@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit, AfterViewInit  {
  @Input() data: ILeilao[]; 
  @Input() campos: ITabela[];

  dataSource;
  displayedColumns: string[] = [];

  @Output() editarClicked: EventEmitter<any> = new EventEmitter<any>();
  @Output() deletarClicked: EventEmitter<any> = new EventEmitter<any>();
  @Output() visualizarClicked: EventEmitter<any> = new EventEmitter<any>();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor() { }

  ngOnInit(): void {   
    this.displayedColumns = this.campos.map(x => x.nome);
    this.displayedColumns.push('acoes');
    this.dataSource = new MatTableDataSource<ILeilao>(this.data)
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnChanges() {
    this.dataSource = new MatTableDataSource<ILeilao>(this.data)
    this.dataSource.paginator = this.paginator;
  }

  editar(item) {
    this.editarClicked.emit(item);
  }

  remover(item) {
    this.deletarClicked.emit(item);
  }

  visualizar(item) {
    this.visualizarClicked.emit(item);
  } 

}
