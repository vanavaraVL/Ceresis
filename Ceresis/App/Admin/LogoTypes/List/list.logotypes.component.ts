import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild } from '@angular/core';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { MatTableDataSource, MatSort, MatPaginator, PageEvent } from '@angular/material';
import { DataSource } from '@angular/cdk/table';
import { Subject, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import { AddLogosComponent } from "../Add/add.logotypes.component";
import { LogoType, RequestGetLogotypes, ResponseGetLogotypes } from "../../../DTO/logotypes.dto";
import { Router } from "@angular/router";
import { RoutesEnum, RoutesName } from "../../../routes.name";
import { Paging, Sorting } from '../../../DTO/base';

@Component({
    selector: 'list-logotypes-component',
    templateUrl: './list.logotypes.component.html',
    styleUrls: ['./list.logotypes.component.scss'],
})
export class ListLogotypesComponent implements OnInit, AfterViewInit, OnDestroy {

    busy: Subscription;

    public displayedColumns = ['name', 'imageUrl', 'description', 'category', 'imageData', 'delete'];
    public dataSource = new LogoDataSource()

    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    pagingAlias: Paging = new Paging(0, 0, 10);

    logos: LogoType[] = [];

    dialogConfig: any;

    constructor(private toastr: ToastsManager, private router: Router, private adminService: AdmininstrationService,
        private dialog: MatDialog) {

    }

    ngOnInit() {
        this.loadLogos();

        this.dialogConfig = {
            disableClose: false,
            data: {}
        }
    }

    ngAfterViewInit(): void {
        this.sort.sortChange.subscribe(() => this.pagingAlias.page = 0);

        this.sort.sortChange.pipe(
            tap(() => this.loadLogos())).subscribe();
    }

    ngOnDestroy() {
        this.sort.sortChange.unsubscribe();

        $((".gallery-item") as any).off();
    }

    updateFancy() {
        setTimeout(() => {
            ($(".gallery-item") as any).fancybox({
                openEffect: "elastic",
                closeEffect: "none"
            });
        }, 650);
    }

    loadLogos(event?: PageEvent) {
        var paging = event != null ? new Paging(event.length, event.pageIndex, event.pageSize) : this.pagingAlias;
        var sorting = new Sorting(this.sort.active, this.sort.direction);

        this.busy = this.adminService.getLogos({ paging: paging, sorting: sorting }).subscribe(response => {
            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.logos = [];
            response.data.forEach(d => {
                this.logos.push(d);
            });

            this.dataSource.data.next(this.logos);

            this.pagingAlias = { length: response.paging.length, page: response.paging.page, pageSize: response.paging.pageSize };

            this.updateFancy();

            this.toastr.success("Примеры работы успешно получены");
        });
    }

    deleteLogo(id: number) {
        this.busy = this.adminService.deleteLogo({ id: id }).subscribe(response => {

            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            var workItemIndx = this.logos.findIndex(w => w.id == id);
            if (workItemIndx >= 0) {
                this.logos.splice(workItemIndx, 1);
                this.dataSource.data.next(this.logos);
            }

            this.toastr.success("Запись успешно удалена");
        });
    }

    createLogo() {
        const dialogRef = this.dialog.open(AddLogosComponent, this.dialogConfig);

        dialogRef.afterClosed().subscribe(result => {

            if (result == true) {
                this.loadLogos();
            }
        });
    }
}

export class LogoDataSource extends DataSource<LogoType> {
    data = new Subject<LogoType[]>();

    connect(): Subject<LogoType[]> {
        return this.data;
    }

    disconnect() {
    }
}