import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ApiResponse } from 'src/app/models/common/ApiResponse.model';

@Injectable({
  providedIn: 'root'
})
export class HttpHandlerService {

  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  protected get<T>(endpoint: string): Observable<T> {
    return this.http.get<ApiResponse<T>>(`${this.apiUrl}${endpoint}`, this.getHttpOptions()).pipe(
      map(response => this.checkResponseStatus(response)),
      catchError(err => this.handleError(err))
    );
  }

  protected post<T>(endpoint: string, body: any): Observable<T> {
    return this.http.post<ApiResponse<T>>(`${this.apiUrl}${endpoint}`, body, this.getHttpOptions()).pipe(
      map(response => this.checkResponseStatus(response)),
      catchError(err => this.handleError(err))
    );
  }

  
  private getHttpOptions() {
    const token = localStorage.getItem('user_auth_token');
    let headers = new HttpHeaders();
    if (token) {
      headers = headers.set('Authorization', `Bearer ${token}`);
    }
    return { headers };
  }

  private checkResponseStatus<T>(response: ApiResponse<T>): T {
    switch (response.status) {
      case 0: // Network error
        throw new Error('Network Error');
      case 5:  // Custom (valid)
        return response.result;
      case 200:
        // Success
        return response.result;
      case 400:
        // Bad Request
        throw new Error('Bad Request');
      case 401:
        // Unauthorized
        throw new Error('Unauthorized');
      case 404:
        // Not Found
        throw new Error('Not Found');
      default:
        throw new Error(response.exception || 'Unknown error');
    }
  }

  private handleError(err: any) {
    if (err.status === 0) {
      console.log('Network Error');
    }
    console.log('HTTP response error', err);
    return throwError(err);
  }
}
