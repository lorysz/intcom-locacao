import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  clientesFiltrados = [];
  todosClientes = [];
  frmFiltro: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
              private router: Router, private fb: FormBuilder) {

  }

  ngOnInit() {
    this.validation();
    this.carregarClientes();

    this.frmFiltro.get('nome').valueChanges.subscribe(x => {
      this.aplicarFiltro(x);
    });
  }

  validation() {
    this.frmFiltro = this.fb.group({
      nome: ['']
    });
  }

  aplicarFiltro(nome: string) {
    if (nome) {
      this.clientesFiltrados = this.clientesFiltrados.filter(loc => loc.nome.toLowerCase().startsWith(nome.toLowerCase()));
    } else {
      this.clientesFiltrados = this.todosClientes;
    }
  }

  carregarClientes() {
    this.http.get(this.baseUrl + 'api/cliente').subscribe((result: any) => {
      this.todosClientes = result;
      this.clientesFiltrados = result;
    }, error => console.error(error));
  }

  locacao(cliente: any) {
    this.router.navigate(['/locacao'], { queryParams: { nome: cliente.nome, idCliente: cliente.idCliente } });
  }
}
