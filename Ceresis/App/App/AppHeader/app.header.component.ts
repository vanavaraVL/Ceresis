import { Component } from '@angular/core';
import { Router } from "@angular/router";

import { RoutesEnum, RoutesName } from "../../routes.name";
import { ToastsManager } from 'ng6-toastr';
import { CookieService } from 'ngx-cookie-service';
import { Cart, CartItem } from "../../DTO/cart.dto";
import { fail } from 'assert';


@Component({
    selector: 'app-header',
    templateUrl: './app.header.component.html',
    styleUrls: ['./app.header.component.scss']
})
export class AppHeaderComponent {

    public currentState: RoutesEnum = RoutesEnum.Home;

    constructor(public router: Router, private toastr: ToastsManager, private cookies: CookieService) {

    }

    goTo(route: RoutesEnum) {

        this.currentState = route;

        switch (route) {
            case RoutesEnum.Home:
                this.router.navigate([RoutesName.HOME], {});
                break;
            case RoutesEnum.Contacts:
                this.router.navigate([RoutesName.CONTACTS], {});
                break;
            case RoutesEnum.Goszakaz:
                this.router.navigate([RoutesName.GOSZAKAZ], {});
                break;
            case RoutesEnum.Production:
                this.router.navigate([RoutesName.PRODUCTION], {});
                break;
            case RoutesEnum.Work:
                this.router.navigate([RoutesName.WORK], {});
                break;
        }
    }

    login() {
        console.log("login");
    }

    orders() {

        //this.cookies.deleteAll("cart");

        if (!this.cookies.check("cart")) {
            this.toastr.error("В Вашей корзине ничего нет для заказа");
            return;
        }

        var cart = JSON.parse(this.cookies.get("cart")) as Cart;

        if ((cart.items || []).length == 0) {
            this.toastr.error("Корзина пуста");
            return;
        }

        //var cart = new Cart();

        //cart.items = [];

        //cart.items.push({ name: "Забор", count: 1, description: "Воздухозаборник", price: 100 });
        //cart.items.push({ name: "Забор - 2", count: 1, description: "Воздухозаборник", price: null });

        //this.cookies.set("cart", JSON.stringify(cart));

        this.router.navigate([RoutesName.CART], {});
    }

    getCartItems() {
        if (!this.cookies.check("cart")) {
            return 0;
        }

        var cart = JSON.parse(this.cookies.get("cart")) as Cart;

        if ((cart.items || []).length == 0) {
            return 0;
        }

        return cart.items.length;
    }

    hasCartItems(): boolean {
        if (!this.cookies.check("cart")) {
            return false;
        }

        var cart = JSON.parse(this.cookies.get("cart")) as Cart;

        if ((cart.items || []).length == 0) {
            return false;
        }

        return true;
    }
}