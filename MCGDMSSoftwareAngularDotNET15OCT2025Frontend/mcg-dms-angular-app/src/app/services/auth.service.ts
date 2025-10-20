// File: src/app/services/auth.service.ts
// Author: mcortesgranados
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { environment } from '../../environments/environment';
import { AuthRequest, AuthResponse } from '../models/auth.model';

const TOKEN_KEY = 'access_token';
const USER_KEY = 'auth_user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  login(payload: AuthRequest): Observable<AuthResponse> {
    const url = `${this.baseUrl}/Auth/login`;
    return this.http.post<AuthResponse>(url, payload).pipe(
      tap(res => {
        localStorage.setItem(TOKEN_KEY, res.token);
        localStorage.setItem(USER_KEY, JSON.stringify({
          usuarioId: res.usuarioId,
          nombre: res.nombre,
          email: res.email
        }));
      })
    );
  }

  logout() {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(USER_KEY);
  }

  getToken(): string | null {
    return localStorage.getItem(TOKEN_KEY);
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  getUser() {
    const raw = localStorage.getItem(USER_KEY);
    return raw ? JSON.parse(raw) : null;
  }
}