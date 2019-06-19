import { Component, ViewEncapsulation, AfterViewInit } from '@angular/core';
import { Cart, CartItem, RequestCreateCart, ResponseCreateCart } from "../DTO/cart.dto";
import { Subscription } from 'rxjs/Subscription';
import { ToastsManager } from 'ng6-toastr';
import { CustomerService } from "../Services/customer.service";
import { CookieService } from 'ngx-cookie-service';
import { Location } from '@angular/common';

@Component({
    selector: 'cart-component',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.scss'],
})
export class CartComponent {

    busy: Subscription;
    cart: Cart;

    requestDescription: string;
    requestEmail: string;
    requestPhone: string;
    requestFirstName: string;
    requestLastName: string;

    constructor(private customerService: CustomerService, private toastr: ToastsManager, private cookies: CookieService,
        private location: Location) {
        this.cart = JSON.parse(this.cookies.get("cart")) as Cart;
    }

    create() {

        this.busy = this.customerService.createOrder({
            data: this.cart,
            description: this.requestDescription,
            email: this.requestEmail,
            name: this.requestFirstName + " " + (this.requestLastName || ""),
            phone: this.requestPhone
        }).subscribe(response => {

            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.toastr.success("Спасибо за ваш заказ");
            this.toastr.success("Мы свяжемся с Вами в ближайшее время");

            this.cookies.deleteAll("cart");

            this.location.back();
        });
    }

    back() {
        this.location.back();
    }

    removeItem(index: number) {
        this.cart.items.splice(index, 1);

        this.cookies.set("cart", JSON.stringify(this.cart));
    }

    getTotalPrice(): string {
        var price = "";

        var selectedPrice = 0;
        var nonSelectedPrice = "";
        this.cart.items.forEach(item => {
            if (item.price) {
                selectedPrice += (item.price * (item.count || 1));
            }
            else if (nonSelectedPrice.length == 0) {
                nonSelectedPrice = " (дополнительно по прейскуранту)";
            }
        });

        if (this.cart.items.length == 0) return "₽ 0.0";

        var resultPrice = ((selectedPrice == 0 ? "" : "₽ " + selectedPrice) + nonSelectedPrice);
        return resultPrice;
    }
}