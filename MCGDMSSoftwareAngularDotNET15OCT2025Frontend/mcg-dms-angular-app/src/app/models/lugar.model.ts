// File: src/app/models/lugar.model.ts
// Author: mcortesgranados
export interface CreateLugarDto {
  nombre: string;
  descripcion: string;
  direccion: string;
  creadorId: number;
}

export interface LugarResponse {
  $id?: string;
  id: number;
  nombre: string;
  descripcion: string;
  direccion: string;
  creadorId: number;
  creador: any | null;
  fechaCreacion: string;
}