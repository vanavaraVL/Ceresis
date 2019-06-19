import { Component } from '@angular/core';
import { Router } from "@angular/router";

import { RoutesEnum, RoutesName } from "../../routes.name";

@Component({
    selector: 'app-product-select',
    templateUrl: './product.select.component.html'
})
export class ProductSelectComponent {

    constructor(public router: Router) {

    }

    goTo(route: RoutesEnum) {

        switch (route) {
            case RoutesEnum.Split:
                this.router.navigate([RoutesName.SPLIT], {});
                break;
            case RoutesEnum.Window:
                this.router.navigate([RoutesName.WINDOW], {});
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
            case RoutesEnum.Portfolio:
                this.router.navigate([RoutesName.PORTFOLIO], {});
                break;
            case RoutesEnum.HouseHold:
                this.router.navigate([RoutesName.HOUSEHOLD], {});
                break;
        }
    }
}