import { Component, OnDestroy, OnInit} from '@angular/core';
import { WorkPrice } from '../DTO/workprice.dto';
import { CatalogService } from '../Services/catalog.service';
import { Subscription } from 'rxjs';
import { ToastsManager } from 'ng6-toastr';
import { CookieService } from 'ngx-cookie-service';
import { Cart } from '../DTO/cart.dto';

@Component({
    templateUrl: './work.component.html'
})
export class WorkComponent implements OnInit {

    workprices: WorkPrice[] = [];
    busy: Subscription;

    constructor(private catalog: CatalogService, private toastr: ToastsManager, private cookies: CookieService) {

    }

    ngOnInit() {
        this.loadWorkprices();
    }

    loadWorkprices() {
        this.busy = this.catalog.getWorkprice().subscribe(response => {
            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.workprices = [];
            this.workprices = response.data;
        });
    }

    putToCart(index: number) {
        var selectedWorkprice = this.workprices[index];

        if (!this.cookies.check("cart")) {
            var cart = new Cart();
            cart.items = [];

            this.cookies.set("cart", JSON.stringify(cart));
        }

        var cart = JSON.parse(this.cookies.get("cart")) as Cart;

        cart.items = (cart.items || []);

        cart.items.push({ name: selectedWorkprice.name, count: 1, description: selectedWorkprice.unity, price: selectedWorkprice.price });

        this.cookies.set("cart", JSON.stringify(cart));

        this.toastr.success("Позиция была успешно добавлена в корзину");
        this.toastr.success("Вы можете посмотреть в любой момент позиции заказа в корзине");
    }
}