import { Component, OnInit } from '@angular/core';
import { LoginService } from '../Usuario/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  email: string;
  contrasenia: string;

  constructor(private service: LoginService, private router: Router) { }

  ngOnInit(): void {
  }

  login(): void {
    this.service.login(this.email, this.contrasenia).subscribe(
      (res: string) => {
        localStorage.setItem('token', res);
        this.router.navigate(['/regiones']);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
}
