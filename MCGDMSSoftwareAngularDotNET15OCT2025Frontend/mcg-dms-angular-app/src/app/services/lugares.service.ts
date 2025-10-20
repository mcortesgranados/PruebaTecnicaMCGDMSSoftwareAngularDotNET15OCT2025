// File: src/app/services/lugares.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateLugarDto, LugarResponse } from '../models/lugar.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LugaresService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  // Crear un nuevo lugar
  createLugar(lugar: CreateLugarDto): Observable<LugarResponse> {
    const url = `${this.baseUrl}/Lugares/crear`;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': '*/*'
    });
    return this.http.post<LugarResponse>(url, lugar, { headers });
  }

  // Asociar un recuerdo a un lugar
  asociarRecuerdo(data: { recuerdoId: number; lugarId: number; asociadoPorId: number }): Observable<any> {
    const url = `${this.baseUrl}/Lugares/asociar`;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': '*/*'
    });
    return this.http.post<any>(url, data, { headers });
  }
}
