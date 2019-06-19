import { Component, AfterViewInit, OnDestroy , OnInit} from '@angular/core';
import { CatalogService } from "../../Services/catalog.service";
import { Subscription } from 'rxjs';
import { ToastsManager } from 'ng6-toastr';
import { WindowPlastic } from "../../DTO/catalog.dto";
import { Cart, CartItem } from "../../DTO/cart.dto";
import { CookieService } from 'ngx-cookie-service';

import * as AOS from 'AOS';
import { setTimeout } from 'timers';
let scrollify = require("jquery-scrollify");

@Component({
    selector: 'app-window',
    templateUrl: './window.component.html'
})
export class WindowComponent implements AfterViewInit, OnDestroy, OnInit {

    busy: Subscription;
    windows: WindowPlastic[];

    constructor(private catalogService: CatalogService, private toastr: ToastsManager, private cookies: CookieService) {

    }

    ngOnDestroy(): void {
        scrollify.disable();
        console.log("scrollify disabled in window");
    }

    ngOnInit() {
        this.getWindows();
    }

    ngAfterViewInit(): void {
        setTimeout(() => {
            this.initAOS();
            this.initScroll();
        }, 100);
    }

    initAOS() {
        AOS.init();

        console.log("aos initialized in window");
    }

    initScroll() {
        scrollify({
            section: "section",
        });

        scrollify.enable();

        console.log("scroll initialized in window");
    }

    updateScroll() {
        scrollify.update();
    }

    nextScroll() {
        scrollify.next();
    }

    getWindows() {
        this.busy = this.catalogService.getWindows().subscribe(response => {

            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.windows = [];
            this.windows = response.data;

            setTimeout(() => {
                this.initAOS();
                this.initScroll();
                this.updateScroll();
            }, 100);
        });
    }

    addToChart(index: number) {
        var selectedWindow = this.windows[index];

        if (!this.cookies.check("cart")) {
            var cart = new Cart();
            cart.items = [];

            this.cookies.set("cart", JSON.stringify(cart));
        }

        var cart = JSON.parse(this.cookies.get("cart")) as Cart;

        cart.items = (cart.items || []);

        cart.items.push({ name: selectedWindow.name, count: 1, description: selectedWindow.feature, price: selectedWindow.totalValue });

        this.cookies.set("cart", JSON.stringify(cart));

        this.toastr.success("Позиция была успешно добавлена в корзину");
        this.toastr.success("Вы можете посмотреть в любой момент позиции заказа в корзине");
    }
}