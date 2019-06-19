import { Component } from '@angular/core';
import { Router, Route } from "@angular/router";
import { RoutesName, RoutesEnum } from "../../routes.name";

@Component({
    selector: 'admin-home-component',
    templateUrl: './admin.home.component.html',
    styleUrls: ['./admin.home.component.scss'],
})
export class AdminHomeComponent {

    constructor(private router: Router) {

    }

    getName(): string {
        if (this.router.isActive(RoutesName.Admin.EDITWORKSAMPLE, true)) {
            return "Редактирование примеров работ"
        }
        else if (this.router.isActive(RoutesName.Admin.EDITWINDOW, true)) {
            return "Редактирование ПВХ-каталога";
        }
        else if (this.router.isActive(RoutesName.Admin.EDITSPLIT, true)) {
            return "Редактирование каталога Сплит-систем";
        }
        else if (this.router.isActive(RoutesName.Admin.EDITWORKPRICE, true)) {
            return "Редактирование каталога услуг (работ)";
        }
        else if (this.router.isActive(RoutesName.Admin.EDITLOGOS, true)) {
            return "Редактирование каталога логотипов";
        }
        else {
            return "Настройки";
        }
    }
}