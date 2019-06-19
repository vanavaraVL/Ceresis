import { Component, ViewEncapsulation, AfterViewInit, ViewContainerRef } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { ScriptLoaderService } from "../Services/script.loader.services";

import { ToastsManager } from 'ng6-toastr';

import * as AOS from 'AOS';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    encapsulation: ViewEncapsulation.None,
})
export class AppComponent implements AfterViewInit {


    ngAfterViewInit(): void {
        setTimeout(() => {
            AOS.init();
            console.log("aos initialized");
        }, 600);
    }

    constructor(public router: Router, public scriptLoader: ScriptLoaderService, public toastr: ToastsManager, vRef: ViewContainerRef) {

        this.toastr.setRootViewContainerRef(vRef);

        this.router.events.subscribe((event) => {
            if (!(event instanceof NavigationEnd)) {
                return;
            }

            window.scrollTo(0, 0);
        });
    }
}