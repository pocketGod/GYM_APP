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

  private getHttpOptions() {
    const token = localStorage.getItem('user_auth_token');
    let headers = new HttpHeaders();
    if (token) {
      headers = headers.set('Authorization', `Bearer ${token}`);
    }
    return { headers };
  }

  protected get<T>(endpoint: string): Observable<T> {
    return this.http.get<ApiResponse<T>>(`${this.apiUrl}${endpoint}`, this.getHttpOptions()).pipe(
      map(response => {        
        if (response.status === 5 || (response.status >= 200 && response.status <= 300)) {          
          return response.result;
        } else {
          throw new Error(response.exception || 'Unknown error');
        }
      }),
      catchError(err => {
        console.log('get http response error',err)
        return throwError(err);
      })
    );
  }

  protected post<T>(endpoint: string, body: any): Observable<T> {
    return this.http.post<ApiResponse<T>>(`${this.apiUrl}${endpoint}`, body, this.getHttpOptions()).pipe(
      map(response => {  
        if (response.status === 5 || (response.status >= 200 && response.status <= 300)) {
          return response.result;
        } else {
          throw new Error(response.exception || 'Unknown error');
        }
      }),
      catchError(err => {
        console.log('post http response error', err)
        return throwError(err)
      })
    );
  }
}
