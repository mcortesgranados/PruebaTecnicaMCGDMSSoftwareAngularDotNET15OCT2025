// File: src/app/models/auth.model.ts
// Author: mcortesgranados
export interface AuthRequest {
  email: string;
  password: string;
}

export interface AuthResponse {
  $id?: string;
  token: string;
  usuarioId: number;
  nombre: string;
  email: string;
}