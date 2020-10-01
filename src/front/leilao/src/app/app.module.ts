import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material/material.module';
import { HomeComponent } from './home/home.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Interceptor } from './interceptor/interceptor.service';
import { UsuarioService } from './services/usuario.service';
import { LeilaoService } from './services/leilao.service';
import { CommonModule, DatePipe } from '@angular/common';
import { AppService } from './services/app.service';
import { ToastrModule } from 'ngx-toastr';
import { SharedModule } from './_shared/shared.module';


import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarModule } from '@ngx-loading-bar/core';
import { PadraoGuard } from './guards/padrao.guard';
import { LeilaomodalComponent } from './modal/leilaomodal/leilaomodal.component';
import { CurrencyMaskInputMode, NgxCurrencyModule } from "ngx-currency";
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';

registerLocaleData(localePt, 'pt-BR');

export const customCurrencyMaskConfig = {
    align: "left",
    allowNegative: true,
    allowZero: true,
    decimal: ",",
    precision: 2,
    prefix: "R$ ",
    suffix: "",
    thousands: ".",
    nullable: true,
    min: null,
    max: null,
    inputMode: CurrencyMaskInputMode.FINANCIAL
};

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,    
    HomeComponent, 
    LeilaomodalComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(), 
    SharedModule,
    LoadingBarModule,
    LoadingBarHttpClientModule,
    NgxCurrencyModule.forRoot(customCurrencyMaskConfig)  
  ],
  providers: [  
    { provide: HTTP_INTERCEPTORS, useClass: Interceptor, multi: true },  
    { provide: LOCALE_ID, useValue: 'pt-BR'}, 
    UsuarioService,
    LeilaoService,
    DatePipe,
    AppService,
    PadraoGuard  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
