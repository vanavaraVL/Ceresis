import { Component, AfterViewInit, OnInit } from '@angular/core';
import { ScriptLoaderService } from "../Services/script.loader.services";
import { WorksampleService } from "../Services/worksample.service";
import { Subject, Subscription } from 'rxjs';
import { ToastsManager } from 'ng6-toastr';

import { WorkSample, ResponseGetWorkSample } from "../DTO/worksample.dto";

@Component({
    templateUrl: './portfolio.component.html',
    styleUrls: ['./portfolio.component.scss']
})
export class PortfolioComponent implements AfterViewInit, OnInit {

    busy: Subscription;

    workSamples: WorkSample[] = [];

    ngOnInit() {

        var self = this;

        self.scriptLoader.load(
            "https://cdnjs.cloudflare.com/ajax/libs/masonry/4.2.1/masonry.pkgd.js",
            "https://npmcdn.com/imagesloaded@4.1/imagesloaded.pkgd.min.js").then((data) => {

                console.log("script portfolio loaded", data);
                console.log("script masonry portfolio init", data);

                this.loadWorkSamples();

            }).catch(error => {
                console.log(error);
            });
    }

    loadWorkSamples() {
        var self = this;

        this.busy = this.worksample.getWorksamples().subscribe(response => {
            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.workSamples = [];
            response.data.forEach(d => {
                this.workSamples.push(d);
            });

            setTimeout(() => {
                var grid = ($('#portfolio-gallery') as any).masonry({
                    itemSelector: '.thumbnail',
                    columnWidth: 280
                });

                grid.imagesLoaded().progress(function () {
                    grid.masonry('layout');

                    self.updateFancyBox();
                });
            }, 650);
        });
    }

    ngAfterViewInit(): void {
        
    }

    updateFancyBox() {
        ($(".gallery-item") as any).fancybox({
            openEffect: "none",
            closeEffect: "none"
        });
    }

    constructor(public scriptLoader: ScriptLoaderService, private worksample: WorksampleService,
        private toastr: ToastsManager) {

    }
}