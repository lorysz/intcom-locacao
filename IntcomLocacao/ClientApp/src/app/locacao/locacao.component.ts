import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-locacao',
  templateUrl: './locacao.component.html',
  styleUrls: ['./locacao.component.css']
})
export class LocacaoComponent implements OnInit {

  locacoesFiltradas = [];
  todasLocacoes = [];
  frmFiltro: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private router: Router, private fb: FormBuilder) { }

  ngOnInit() {
    this.validation();
    this.carregarLocacoes();

    this.frmFiltro.get('nome').valueChanges.subscribe(x => {
      const status = this.frmFiltro.get('status').value;
      this.aplicarFiltro(status);
    });

    this.frmFiltro.get('status').valueChanges.subscribe(stats => {
      this.aplicarFiltro(stats);
    });
  }

  validation() {
    this.frmFiltro = this.fb.group({
      nome: [''],
      status: ['T']
    });
  }

  aplicarFiltro(status: string) {
    if (status === 'D') {
      this.locacoesFiltradas = this.todasLocacoes.filter(loc => loc.dataDevolucao);
    } else if (status === 'L') {
      this.locacoesFiltradas = this.todasLocacoes.filter(loc => !loc.dataDevolucao);
    } else {
      this.locacoesFiltradas = this.todasLocacoes;
    }
    const nome = this.frmFiltro.get('nome').value;

    if (nome) {
      this.locacoesFiltradas = this.locacoesFiltradas.filter(loc => loc.cliente.toLowerCase().startsWith(nome.toLowerCase()));
    }
  }

  devolucao(locacao: any) {
    this.router.navigate(['/devolucao'], { queryParams: { idLocacao: locacao.idLocacao } });
  }

  carregarLocacoes() {
    this.http.get(this.baseUrl + 'api/locacao').subscribe((result: any) => {
      this.todasLocacoes = result;
      this.locacoesFiltradas = result;
    }, error => console.error(error));
  }

}
