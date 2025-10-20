// File: src/app/components/asociar-recuerdo/asociar-recuerdo.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { LugaresService } from '../../services/lugares.service';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-asociar-recuerdo',
  templateUrl: './asociar-recuerdo.component.html',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class AsociarRecuerdoComponent {
  asociarForm: FormGroup;
  respuesta: any = null;
  error: string | null = null;
  cargando = false;

  constructor(
    private fb: FormBuilder,
    private lugaresService: LugaresService,
    private authService: AuthService
  ) {
    const user = this.authService.getUser();
    this.asociarForm = this.fb.group({
      recuerdoId: [null, [Validators.required]],
      lugarId: [null, [Validators.required]],
      asociadoPorId: [user ? user.usuarioId : 1, [Validators.required]]
    });
  }

  submit() {
    if (!this.authService.isAuthenticated()) {
      this.error = 'Debes iniciar sesión primero.';
      return;
    }

    if (this.asociarForm.invalid) {
      this.asociarForm.markAllAsTouched();
      return;
    }

    this.cargando = true;
    this.error = null;
    const dto = this.asociarForm.value;

    this.lugaresService.asociarRecuerdo(dto).subscribe({
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
