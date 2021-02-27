import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  constructor(private router: Router) {
    
  }

  ngOnInit(): void {
    var currentUserStorage = localStorage.getItem('currentUser');
    var token = null;

    if (currentUserStorage) {
      var currentUser = JSON.parse(currentUserStorage);
      token = currentUser.token;
    }

    if (!token) {
      this.router.navigate(['autenticacao']);
    }      
 }
}
