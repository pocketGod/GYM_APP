import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpHandlerService {

  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getHttpOptions() {
    const token = localStorage.getItem('auth_token');
    let headers = new HttpHeaders();
    if (token) {
      headers = headers.set('Authorization', `Bearer ${token}`);
    }
    return { headers };
  }

  get(endpoint: string) {
    return this.http.get(`${this.apiUrl}${endpoint}`, this.getHttpOptions());
  }

  post(endpoint: string, body: any) {
    return this.http.post(`${this.apiUrl}${endpoint}`, body, this.getHttpOptions());
  }
}
