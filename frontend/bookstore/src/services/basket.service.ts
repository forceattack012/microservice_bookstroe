import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { BaseResponse } from 'src/models/baseResponse';
import { Basket } from 'src/models/basket';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(private http: HttpClient) { }

  createBasket(basket: Basket): Observable<BaseResponse<Basket>> {
    return this.http.post<BaseResponse<Basket>>(`/api/basket`, basket);
  }

  getBasketByUsername(username: string): Observable<BaseResponse<Basket>>{
    return this.http.get<BaseResponse<Basket>>(`/api/basket/${username}`)
  }
}
