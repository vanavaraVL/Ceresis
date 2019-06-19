import { ResponseBase } from './base';

export class CartItem {
    name: string;
    count: number;
    price: number;
    description: string;
}

export class Cart {
    items: CartItem[];
}

export class RequestCreateCart {
    data: Cart;
    email: string;
    phone: string;
    name: string;
    description: string;
}

export class ResponseCreateCart extends ResponseBase {
    
}