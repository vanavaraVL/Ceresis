import { Component, Renderer, AfterViewInit, OnDestroy, OnInit } from '@angular/core';
import { ScriptLoaderService } from "../../Services/script.loader.services";
import { CatalogService } from "../../Services/catalog.service";
import { SplitHouse, ResponseGetSplitHouse } from '../../DTO/split.dto';

import * as AOS from 'AOS';
import { Subscription } from 'rxjs';
import { ToastsManager } from 'ng6-toastr';
import { CookieService } from 'ngx-cookie-service';
import { Cart } from '../../DTO/cart.dto';
import { settings } from 'cluster';
import { setTimeout } from 'timers';

let scrollify = require("jquery-scrollify");

@Component({
    selector: 'app-house-hold',
    templateUrl: './house-hold.component.html',
    styleUrls: ['./house-hold.component.scss']
})
export class HouseHoldComponent implements AfterViewInit, OnDestroy, OnInit {

    splitHouses: SplitHouse[] = [];
    busy: Subscription;

    constructor(private catalog: CatalogService, private toastr: ToastsManager, private cookies: CookieService) {

    }

    ngOnDestroy(): void {

        scrollify.disable();
        console.log("scrollify disabled in house hold");
    }

    ngOnInit() {
        this.loadSplitHouses();
    }

    ngAfterViewInit(): void {
        setTimeout(() => {
            this.initAOS();
            this.initScroll();
        }, 100);
    }

    initAOS() {
        AOS.init();

        console.log("aos initialized in house");
    }

    initScroll() {
        scrollify({
            section: "section",
        });

        scrollify.enable();

        console.log("scroll initialized in house");
    }

    updateScroll() {
        scrollify.update();
    }

    nextScroll() {
        scrollify.next();
    }

    loadSplitHouses() {
        this.busy = this.catalog.getSplitHouse().subscribe(response => {

            this.splitHouses = [];

            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.splitHouses = response.data;

            setTimeout(() => {
                this.updateScroll();
            }, 100);
        });
    }

    putToCart(index: number) {
        var selectedSplit = this.splitHouses[index];

        if (!this.cookies.check("cart")) {
            var cart = new Cart();
            cart.items = [];

            this.cookies.set("cart", JSON.stringify(cart));
        }

        var cart = JSON.parse(this.cookies.get("cart")) as Cart;

        cart.items = (cart.items || []);

        cart.items.push({ name: selectedSplit.model, count: 1, description: selectedSplit.power, price: selectedSplit.price });

        this.cookies.set("cart", JSON.stringify(cart));

        this.toastr.success("Позиция была успешно добавлена в корзину");
        this.toastr.success("Вы можете посмотреть в любой момент позиции заказа в корзине");
    }
}