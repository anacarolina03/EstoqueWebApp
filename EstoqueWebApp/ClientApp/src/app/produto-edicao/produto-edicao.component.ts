import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AutenticacaoComponent } from '../autenticacao/autenticacao.component';

@Component({
  selector: 'app-produto-edicao',
  templateUrl: './produto-edicao.component.html',
  styleUrls: ['./produto-edicao.component.css']
})
export class ProdutoEdicaoComponent implements OnInit {

  public produto: any = { codProduto: 0, descricao: "", preco: null, marca: "", dataLancamento: null };
  public tiposProduto: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activateRoute: ActivatedRoute, private router: Router) {
    if (this.getId() != 0) {
      this.consultar();
    }

    this.http.get<any>(this.baseUrl + 'tipoProduto', { headers: AutenticacaoComponent.getHeaders() }).subscribe(result => {
      this.tiposProduto = result;
    }, error => console.error(error));
  }

  getId(): number {
    return parseInt(this.activateRoute.snapshot.paramMap.get('id'));
  }

  consultar() {
    this.http.get<any>(this.baseUrl + 'produto/' + this.getId(), { headers: AutenticacaoComponent.getHeaders() }).subscribe(result => {
      this.produto = result;
    }, error => console.error(error));
  }

  salvar() {
    if (this.getId() != 0) {
      this.http.put<any>(this.baseUrl + 'produto/' + this.getId(), this.produto, { headers: AutenticacaoComponent.getHeaders() }).subscribe(result => {
        this.router.navigate(['produto-listagem']);
      }, error => console.error(error));
    } else {
      this.http.post<any>(this.baseUrl + 'produto', this.produto, { headers: AutenticacaoComponent.getHeaders() }).subscribe(result => {
        this.router.navigate(['produto-listagem']);
      }, error => console.error(error));

    }
  }

  ngOnInit() {
  }
}
