import { Injectable } from '@angular/core';
import { HttpHandlerService } from 'src/app/shared/services/http-handler.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends HttpHandlerService {

  constructor() {
    super();
  }
}
