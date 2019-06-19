import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cart, CartItem, RequestCreateCart, ResponseCreateCart } from '../DTO/cart.dto';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CustomerService {

    constructor(private http: HttpClient) {

    }

    createOrder(request: RequestCreateCart): Observable<ResponseCreateCart> {
        return this.http.post<ResponseCreateCart>(window.settings.BaseUrlAPI + "api/v1.0/customer/create", request);
    }
}