import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cadastro-devolucao',
  templateUrl: './cadastro-devolucao.component.html',
  styleUrls: ['./cadastro-devolucao.component.css']
})
export class CadastroDevolucaoComponent implements OnInit {

  frmDevolucao: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
              private fb: FormBuilder, private route: ActivatedRoute, private toastr: ToastrService, private router: Router) { }

  ngOnInit() {
    this.validation();

    this.route.queryParams
      .subscribe(params => {
        this.frmDevolucao.get('idLocacao').setValue(parseInt(params.idLocacao));
        this.carregarDadosLocacao(parseInt(params.idLocacao));
      });
  }

  validation() {
    this.frmDevolucao = this.fb.group({
      cliente: [''],
      filme: [''],
      idLocacao: [],
      dataLocacao: [''],
      dataDevolucao: ['', [Validators.required]]
    });
  }

  carregarDadosLocacao(idLocacao: number) {
    this.http.get(`${this.baseUrl}api/locacao/${idLocacao}`).subscribe((result: any) => {
      this.frmDevolucao.patchValue({
        cliente: result.cliente,
        filme: result.filme,
        dataLocacao: result.dataLocacao.split(' ')[0]
      });

    }, error => this.toastr.error('Problemas para carregar os dados da locação.', 'Erro'));
  }

  salvar() {
    if (this.frmDevolucao.valid) {
      this.http.put(`${this.baseUrl}api/locacao`, this.frmDevolucao.value).subscribe((result: any) => {
        this.toastr.success('Devolução feita com sucesso.', 'Sucesso');
        this.router.navigate(['/']);
      }, error => this.toastr.error('Problemas para salvar a devolução.', 'Erro'));
    }
  }

}
