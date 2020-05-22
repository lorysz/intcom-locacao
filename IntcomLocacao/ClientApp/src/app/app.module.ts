import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ClienteComponent } from './cliente/cliente.component';
import { LocacaoComponent } from './locacao/locacao.component';
import { CadastroLocacaoComponent } from './cliente/cadastro-locacao/cadastro-locacao.component';
import { CadastroDevolucaoComponent } from './locacao/cadastro-devolucao/cadastro-devolucao.component';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ConfirmationDialogComponent } from './Core/confirmation-dialog/confirmation-dialog.component';
import { ConfirmationDialogService } from './Core/confirmation-dialog/confirmation-dialog.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ClienteComponent,
    LocacaoComponent,
    CadastroLocacaoComponent,
    CadastroDevolucaoComponent,
    ConfirmationDialogComponent
  ],
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: LocacaoComponent, pathMatch: 'full' },
      { path: 'clientes', component: ClienteComponent },
      { path: 'locacao', component: CadastroLocacaoComponent },
      { path: 'devolucao', component: CadastroDevolucaoComponent },
    ])
  ],
  providers: [ConfirmationDialogService],
  entryComponents: [ ConfirmationDialogComponent ],
  bootstrap: [AppComponent]
})
export class AppModule { }
