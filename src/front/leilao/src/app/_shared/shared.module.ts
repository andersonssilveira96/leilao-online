import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from '../app-routing.module';
import { MaterialModule } from '../material/material.module';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { TableComponent } from './table/table.component';

@NgModule({
    declarations: [
        FooterComponent,
        HeaderComponent,
        TableComponent
    ], 
    imports: [
        MaterialModule,
        AppRoutingModule,
        CommonModule,     
        BrowserModule,
        BrowserAnimationsModule,
    ],
    exports: [
        FooterComponent,
        HeaderComponent,
        TableComponent
    ]
  })
  export class SharedModule {}