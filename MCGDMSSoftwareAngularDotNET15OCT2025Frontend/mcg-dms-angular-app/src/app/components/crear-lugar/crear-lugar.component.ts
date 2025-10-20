// src/app/components/crear-lugar/crear-lugar.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { LugaresService } from '../../services/lugares.service';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { CreateLugarDto, LugarResponse } from '../../models/lugar.model';

@Component({
  selector: 'app-crear-lugar',
  templateUrl: './crear-lugar.component.html',
  standalone: true,              // <-- Make standalone
  imports: [
    CommonModule,                // <-- Needed for *ngIf, *ngFor
    ReactiveFormsModule           // <-- Needed for formGroup, formControlName
  ]
})
export class CrearLugarComponent {
  lugarForm: FormGroup;
  respuesta: LugarResponse | null = null;
  error: string | null = null;
  cargando = false;

  constructor(
    private fb: FormBuilder,
    private lugaresService: LugaresService,
    private authService: AuthService
  ) {
    const user = this.authService.getUser();
    this.lugarForm = this.fb.group({
      nombre: ['', Validators.required],
      descripcion: [''],
      direccion: [''],
      creadorId: [user ? user.usuarioId : 1, [Validators.required]]
    });
  }

  submit() {
    if (!this.authService.isAuthenticated()) {
      this.error = 'Debes iniciar sesión primero.';
      return;
    }

    if (this.lugarForm.invalid) {
      this.lugarForm.markAllAsTouched();
      return;
    }
    this.cargando = true;
    this.error = null;
    const dto: CreateLugarDto = this.lugarForm.value;

    this.lugaresService.createLugar(dto).subscribe({
      next: (res) => {
        this.respuesta = res;
        this.cargando = false;
      },
      error: (err) => {
        this.error = err?.error?.message || err?.message || 'Error en la petición';
        this.cargando = false;
      }
    });
  }
}
