import { Component, ViewEncapsulation, AfterViewInit } from '@angular/core';
import { LoginRequest, LoginResponse } from "../../DTO/login.dto";
import { AdmininstrationService } from '../../Services/administration.service';
import { Subscription } from 'rxjs/Subscription';
import { ToastsManager } from 'ng6-toastr';

import { Router } from "@angular/router";

import { RoutesEnum, RoutesName } from "../../routes.name";

@Component({
    selector: 'login-component',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
})
export class LoginComponent {

    request: LoginRequest = new LoginRequest();
    busy: Subscription;

    constructor(private adminService: AdmininstrationService, private toastr: ToastsManager, private router: Router) {

    }

    login() {

        this.busy = this.adminService.login(this.request).subscribe(response => {
            if (!response)
                this.toastr.error('Ошибка входа');
            else {
                this.toastr.success("Вход выполнен");

                let element: HTMLElement = document.getElementById("closeBtnId") as HTMLElement;
                element.click();

                this.router.navigate([RoutesName.Admin.ADMIN], {});
            }
        });
    }
}