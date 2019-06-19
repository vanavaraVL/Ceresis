import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild } from '@angular/core';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { MatTableDataSource, MatSort, MatPaginator, PageEvent } from '@angular/material';
import { DataSource } from '@angular/cdk/table';
import { Subject, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import { AddWindowComponent } from "../../Window/Add/add.window.component";
import { WindowPlastic, ResponseGetWindowPlastic, RequestGetWindowPlastic } from "../../../DTO/catalog.dto";
import { Router } from "@angular/router";
import { RoutesEnum, RoutesName } from "../../../routes.name";
import { Paging, Sorting } from '../../../DTO/base';
import { EditWindowComponent } from '../Edit/edit.window.component';

@Component({
    selector: 'list-window-component',
    templateUrl: './list.window.component.html',
    styleUrls: ['./list.window.component.scss'],
})
export class ListWindowsComponent implements OnInit, AfterViewInit, OnDestroy {

    busy: Subscription;

    public displayedColumns = ['name', 'feature', 'size', 'total', 'imageUrl', 'hasSetup', 'delete', 'update'];
    public dataSource = new WindowDataSource()

    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    pagingAlias: Paging = new Paging(0, 0, 10);

    windows: WindowPlastic[] = [];

    dialogConfig: any;

    constructor(private toastr: ToastsManager, private router: Router, private adminService: AdmininstrationService,
        private dialog: MatDialog) {

    }

    ngOnInit() {
        this.loadWindows();

        this.dialogConfig = {
            disableClose: false,
            data: {}
        }
    }

    ngAfterViewInit(): void {
        this.sort.sortChange.subscribe(() => this.pagingAlias.page = 0);

        this.sort.sortChange.pipe(
            tap(() => this.loadWindows())).subscribe();
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

    loadWindows(event?: PageEvent) {
        var paging = event != null ? new Paging(event.length, event.pageIndex, event.pageSize) : this.pagingAlias;
        var sorting = new Sorting(this.sort.active, this.sort.direction);

        this.busy = this.adminService.getWindows({ paging: paging, sorting: sorting }).subscribe(response => {
            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.windows = [];
            response.data.forEach(d => {
                this.windows.push(d);
            });

            this.dataSource.data.next(this.windows);

            this.pagingAlias = { length: response.paging.length, page: response.paging.page, pageSize: response.paging.pageSize };

            this.updateFancy();

            this.toastr.success("Примеры каталог пластиковых окон получен");
        });
    }

    deleteWindow(id: number) {
        this.busy = this.adminService.deleteWindow({ id: id }).subscribe(response => {

            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            var windowItem = this.windows.findIndex(w => w.id == id);
            if (windowItem >= 0) {
                this.windows.splice(windowItem, 1);
                this.dataSource.data.next(this.windows);
            }

            this.toastr.success("Запись успешно удалена");
        });
    }

    createWindow() {
        const dialogRef = this.dialog.open(AddWindowComponent, this.dialogConfig);

        dialogRef.afterClosed().subscribe(result => {

            if (result == true) {
                this.loadWindows();
            }
        });
    }

    editWindow(id: number) {
        var selectedWindow = this.windows.filter(w => w.id == id)[0];

        this.dialogConfig.data = {
            selectedWindow: selectedWindow
        };

        const dialogRef = this.dialog.open(EditWindowComponent, this.dialogConfig);

        dialogRef.afterClosed().subscribe(result => {

            if (result == true) {
                this.loadWindows();
            }
        });
    }
}

export class WindowDataSource extends DataSource<WindowPlastic> {
    data = new Subject<WindowPlastic[]>();

    connect(): Subject<WindowPlastic[]> {
        return this.data;
    }

    disconnect() {
    }
}