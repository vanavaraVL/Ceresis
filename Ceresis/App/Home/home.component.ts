import { Component, AfterViewInit, OnDestroy } from '@angular/core';
import { ScriptLoaderService } from "../Services/script.loader.services";

import * as AOS from 'AOS';
let scrollify = require("jquery-scrollify");

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styles: ['@import "https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.2.0/assets/owl.theme.default.css";',
             '@import "https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css";',
             '@import "https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.2.0/assets/owl.carousel.css";']
})
export class HomeComponent implements AfterViewInit, OnDestroy {

    ngOnDestroy(): void {
        scrollify.disable();
        console.log("scrollify disabled in home");
    }

    ngAfterViewInit(): void {

        scrollify({
            section: "section",
        });

        scrollify.enable();

        console.log("scrollify enable in home");
        
        this.scriptLoader.load(
            "https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.2.0/owl.carousel.js").then((data) => {

                this.scriptLoader.load("../../Scripts/home.component.load.js").then((data) => {
                    console.log("script home loaded", data);

                    $.getScript("../../Scripts/home.component.load.js");

                    setTimeout(() => {
                        AOS.init();

                        scrollify.update();

                        console.log("aos initialized in home and scrollify has been updated");
                    }, 600);

                    

                    $('.navbar').addClass("sticky");
                    $('body').addClass('loaded');
                });
            }).catch(error => {
                console.log(error);
            });
    }

    constructor(public scriptLoader: ScriptLoaderService) {
        
    }
}