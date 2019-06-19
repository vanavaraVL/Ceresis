import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild } from '@angular/core';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { MatTableDataSource, MatSort, MatPaginator, PageEvent } from '@angular/material';
import { DataSource } from '@angular/cdk/table';
import { Subject, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import { AddWindowComponent } from "../../Window/Add/add.window.component";
import { WorkPrice, RequestGetWorkprice, ResponseGetWorkprice } from "../../../DTO/workprice.dto";
import { Router } from "@angular/router";
import { RoutesEnum, RoutesName } from "../../../routes.name";
import { Paging, Sorting } from '../../../DTO/base';
import { EditWorkpriceComponent } from '../Edit/edit.workprice.component';
import { AddWorkpriceComponent } from '../Add/add.workprice.component';

@Component({
    selector: 'list-workprice-component',
    templateUrl: './list.workprice.component.html',
    styleUrls: ['./list.workprice.component.scss'],
})
export class ListWorkpriceComponent implements OnInit, AfterViewInit, OnDestroy {

    busy: Subscription;

    public displayedColumns = ['name', 'unity', 'price', 'delete', 'update'];
    public dataSource = new WindowDataSource()

    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    pagingAlias: Paging = new Paging(0, 0, 10);

    workPrices: WorkPrice[] = [];

    dialogConfig: any;

    constructor(private toastr: ToastsManager, private router: Router, private adminService: AdmininstrationService,
        private dialog: MatDialog) {

    }

    ngOnInit() {
        this.loadWorkprices();

        this.dialogConfig = {
            disableClose: false,
            data: {}
        }
    }

    ngAfterViewInit(): void {
        this.sort.sortChange.subscribe(() => this.pagingAlias.page = 0);

        this.sort.sortChange.pipe(
            tap(() => this.loadWorkprices())).subscribe();
    }

    ngOnDestroy() {
        this.sort.sortChange.unsubscribe();
    }
    
    loadWorkprices(event?: PageEvent) {
        var paging = event != null ? new Paging(event.length, event.pageIndex, event.pageSize) : this.pagingAlias;
        var sorting = new Sorting(this.sort.active, this.sort.direction);

        this.busy = this.adminService.getWorkprice({ paging: paging, sorting: sorting }).subscribe(response => {
            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.workPrices = [];
            response.data.forEach(d => {
                this.workPrices.push(d);
            });

            this.dataSource.data.next(this.workPrices);

            this.pagingAlias = { length: response.paging.length, page: response.paging.page, pageSize: response.paging.pageSize };

            this.toastr.success("Пример каталога описания работ получен");
        });
    }

    deleteWorkprice(id: number) {
        this.busy = this.adminService.deleteWorkprice({ id: id }).subscribe(response => {

            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            var windowItem = this.workPrices.findIndex(w => w.id == id);
            if (windowItem >= 0) {
                this.workPrices.splice(windowItem, 1);
                this.dataSource.data.next(this.workPrices);
            }

            this.toastr.success("Запись успешно удалена");
        });
    }

    createWorkprice() {
        const dialogRef = this.dialog.open(AddWorkpriceComponent, this.dialogConfig);

        dialogRef.afterClosed().subscribe(result => {

            if (result == true) {
                this.loadWorkprices();
            }
        });
    }

    editWorkprice(id: number) {
        var selectedWorkprice = this.workPrices.filter(w => w.id == id)[0];

        this.dialogConfig.data = {
            selectedWorkprice: selectedWorkprice
        };

        const dialogRef = this.dialog.open(EditWorkpriceComponent, this.dialogConfig);

        dialogRef.afterClosed().subscribe(result => {

            if (result == true) {
                this.loadWorkprices();
            }
        });
    }
}

export class WindowDataSource extends DataSource<WorkPrice> {
    data = new Subject<WorkPrice[]>();

    connect(): Subject<WorkPrice[]> {
        return this.data;
    }

    disconnect() {
    }
}