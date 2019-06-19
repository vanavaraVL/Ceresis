import { Component, Renderer, AfterViewInit, OnDestroy, OnInit } from '@angular/core';
import { ScriptLoaderService } from "../../Services/script.loader.services";

import * as AOS from 'AOS';
import { CatalogService } from '../../Services/catalog.service';
import { LogoType } from '../../DTO/logotypes.dto';
import { ToastsManager } from 'ng6-toastr';
import { settings } from 'cluster';
import { setTimeout } from 'timers';
let scrollify = require("jquery-scrollify");

@Component({
    selector: 'app-split',
    templateUrl: './split.component.html',
    styleUrls: ['./split.component.scss']
})
export class SplitComponent implements AfterViewInit, OnDestroy, OnInit {

    logos: LogoType[] = [];

    ngOnDestroy(): void {
        scrollify.disable();
        console.log("scrollify disabled in split");
    }

    ngOnInit() {
        this.loadLogos();
    }

    ngAfterViewInit(): void {
        setTimeout(() => {
            this.initAOS();
            this.initScroll();
            this.initFancy();
        }, 100);
    }

    initAOS() {
        AOS.init();

        console.log("aos initialized in split");
    }

    initScroll() {
        scrollify.enable();

        scrollify({
            section: "section",
        });

        console.log("scroll initialized in split");
    }

    updateScroll() {
        scrollify.update();
    }

    initFancy() {
        ($(".gallery_product") as any).fancybox({
            openEffect: "elastic",
            closeEffect: "none"
        });
    }

    filterData(filter: string, event: any) {

        var visible;

        if (filter == "all") {
            visible = $('.gallery_product');
        }
        else {
            visible = $('.gallery_product').hide(500).filter('.' + filter);
        }

        visible.show(1000);

        $(".filter-button").removeClass("active");
        let oldClasses = event.target.getAttribute('class');
        this.render.setElementAttribute(event.target, "class", oldClasses + ' active');

        setTimeout(() => {
            this.initAOS();
            this.updateScroll();
            this.initFancy();
        }, 100);
    }

    nextScroll() {
        scrollify.next();
    }

    loadLogos() {
        this.catalog.getLogos().subscribe(response => {

            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.logos = response.data;

            setTimeout(() => {
                this.initFancy();
                this.updateScroll();
            }, 100);
        });
    }

    constructor(private render: Renderer, public scriptLoader: ScriptLoaderService, private catalog: CatalogService, private toastr: ToastsManager) {

    }
}