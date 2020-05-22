import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogService } from '../../Core/confirmation-dialog/confirmation-dialog.service';

@Component({
  selector: 'app-cadastro-locacao',
  templateUrl: './cadastro-locacao.component.html',
  styleUrls: ['./cadastro-locacao.component.css']
})
export class CadastroLocacaoComponent implements OnInit {
  frmLocacao: FormGroup;
  filmes = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private route: ActivatedRoute, private fb: FormBuilder, private toastr: ToastrService,
    private confirmationDialogService: ConfirmationDialogService) { }

  ngOnInit() {
    this.validation();

    this.route.queryParams
      .subscribe(params => {
        this.frmLocacao.get('nome').setValue(params.nome);
        this.frmLocacao.get('idCliente').setValue(parseInt(params.idCliente));
      });

    this.carregarFilmes();
  }

  validation() {
    this.frmLocacao = this.fb.group({
      idLocacao: [],
      idCliente: [],
      idFilme: [, [Validators.required]],
      dataLocacao: [, [Validators.required]],
      nome: ['', [Validators.required]]
    });
  }

  carregarFilmes() {
    this.http.get(this.baseUrl + 'api/filme').subscribe((result: any) => {
      this.filmes = result;
    }, error => console.error(error));
  }

  salvar() {
    if (this.frmLocacao.valid) {
      const idFilme = this.frmLocacao.get('idFilme').value;
      this.frmLocacao.get('idFilme').setValue(parseInt(idFilme));
      this.http.post(this.baseUrl + 'api/locacao', this.frmLocacao.value).subscribe((result: any) => {
        switch (result.erro) {
          case 0:
            this.toastr.success(result.msg, 'Sucesso');
            this.frmLocacao.get('idFilme').setValue('');
            this.frmLocacao.get('idLocacao').setValue('');
            break;
          case 1:
            this.toastr.info(result.msg, 'Info');
            break;
          case 2:
            this.confirmationDialogService.confirm('Deseja continuar?', result.msg)
              .then((confirmed) => {
                if(confirmed) {
                  this.frmLocacao.get('idLocacao').setValue(result.idLocacao);
                  this.http.put(this.baseUrl + 'api/locacao', this.frmLocacao.value).subscribe((result: any) => {

                    this.http.post(this.baseUrl + 'api/locacao', this.frmLocacao.value).subscribe((result: any) => {
                      this.toastr.success('Dados salvo com sucesso', 'Sucesso');
                      this.frmLocacao.get('idFilme').setValue('');
                      this.frmLocacao.get('idLocacao').setValue('');
                    }, error => this.toastr.error('Problemas para salvar a locação.', 'Erro'));
  
                  }, error => this.toastr.error('Problemas para salvar a locação.', 'Erro'));
                }
              })
              .catch(() => { });

            break;

          default:
            this.toastr.error(result.msg, 'Erro');
            break;
        }

      }, error => this.toastr.error('Problemas para salvar a locação.', 'Erro'));
    }
  }

  openConfirmationDialog(descricao: string) {
    this.confirmationDialogService.confirm('Deseja continuar?', descricao)
      .then((confirmed) => console.log('User confirmed:', confirmed))
      .catch(() => console.log('User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'));
  }
}
