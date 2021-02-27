import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AutenticacaoComponent } from '../autenticacao/autenticacao.component';

@Component({
  selector: 'app-produto-listagem',
  templateUrl: './produto-listagem.component.html',
  styleUrls: ['./produto-listagem.component.css']
})
export class ProdutoListagemComponent implements OnInit {

  public produtos: any;
  tiposProduto: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    this.consultar();
  }

  private consultar() {
    var currentUserStorage = localStorage.getItem('currentUser');
    var token = null;

    if (currentUserStorage) {
      var currentUser = JSON.parse(currentUserStorage);
      token = currentUser.token;
    }

    if (!token) {
      this.router.navigate(['autenticacao']);
    } else {
      this.http.get<any>(this.baseUrl + 'produto', { headers: AutenticacaoComponent.getHeaders() }).subscribe(result => {
        this.produtos = result;
      }, error => console.error(error));
    }
  }

  editar(id: number) {
    this.router.navigate(['produto-edicao/' + id]);
  }

  excluir(id: number) {
    this.http.delete<any>(this.baseUrl + 'produto/' + id, { headers: AutenticacaoComponent.getHeaders() }).subscribe(result => {
      this.consultar();
    }, error => console.error(error));
  }

  ngOnInit() {
  }
}
