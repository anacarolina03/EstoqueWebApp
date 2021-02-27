import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-autenticacao',
  templateUrl: './autenticacao.component.html',
  styleUrls: ['./autenticacao.component.css']
})
export class AutenticacaoComponent implements OnInit {

  public usuario: any = { nomeUsuario: "", senha: "" };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activateRoute: ActivatedRoute, private router: Router) {
    localStorage.removeItem('currentUser');
  }

  logar() {
    this.http.post<any>(this.baseUrl + 'Autenticacao', this.usuario).subscribe(result => {
      localStorage.setItem('currentUser', JSON.stringify({ token: result.token }));
      this.router.navigate(['/']);
    }, error =>
        alert("Usuário ou senha inválidos.")
        );
  }

  public static getHeaders() {
    var currentUserStorage = localStorage.getItem('currentUser');
    var token = "";

    if (currentUserStorage) {
      var currentUser = JSON.parse(currentUserStorage);
      token = currentUser.token;
    }

    var reqHeader = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + token
    });

    return reqHeader;
  }

  ngOnInit() {
  }
}
