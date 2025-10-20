// src/app/components/login/login.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; // <-- Import CommonModule

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule  // <-- Add CommonModule so *ngIf, *ngFor work
  ]
})
export class LoginComponent {
  loginForm: FormGroup;
  cargando = false;
  error: string | null = null;
  usuarioNombre: string | null = null;

  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
    const user = this.authService.getUser();
    this.usuarioNombre = user ? user.nombre : null;
  }

  submit() {
    if (this.loginForm.invalid) return;
    this.cargando = true;
    this.error = null;

    this.authService.login(this.loginForm.value).subscribe({
      next: (res) => {
        this.usuarioNombre = res.nombre;
        this.cargando = false;
      },
      error: (err) => {
        this.error = err?.error?.message || err?.message || 'Error en login';
        this.cargando = false;
      }
    });
  }

  logout() {
    this.authService.logout();
    this.usuarioNombre = null;
  }
}
