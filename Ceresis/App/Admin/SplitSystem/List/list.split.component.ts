import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild } from '@angular/core';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { MatTableDataSource, MatSort, MatPaginator, PageEvent } from '@angular/material';
import { DataSource } from '@angular/cdk/table';
import { Subject, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import { AddWindowComponent } from "../../Window/Add/add.window.component";
import { SplitHouse, RequestGetSplitHouse, ResponseGetSplitHouse } from "../../../DTO/split.dto";
import { Router } from "@angular/router";
import { RoutesEnum, RoutesName } from "../../../routes.name";
import { Paging, Sorting } from '../../../DTO/base';
import { EditSplitHouseComponent } from '../Edit/edit.split.component';
import { AddSplitComponent } from '../Add/add.split.component';

@Component({
    selector: 'list-split-component',
    templateUrl: './list.split.component.html',
    styleUrls: ['./list.split.component.scss'],
})
export class ListSplitComponent implements OnInit, AfterViewInit, OnDestroy {

    busy: Subscription;

    public displayedColumns = ['model', 'imageUrl', 'power', 'powerRealty', 'energoEfficienty', 'noise', 'sizeExternal', 'sizeInternal', 'price', 'delete', 'update'];
    public dataSource = new WindowDataSource()

    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    pagingAlias: Paging = new Paging(0, 0, 10);

    splitHouses: SplitHouse[] = [];

    dialogConfig: any;

    constructor(private toastr: ToastsManager, private router: Router, private adminService: AdmininstrationService,
        private dialog: MatDialog) {

    }

    ngOnInit() {
        this.loadSplitHouses();

        this.dialogConfig = {
            disableClose: false,
            data: {}
        }
    }

    ngAfterViewInit(): void {
        this.sort.sortChange.subscribe(() => this.pagingAlias.page = 0);

        this.sort.sortChange.pipe(
            tap(() => this.loadSplitHouses())).subscribe();
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

    loadSplitHouses(event?: PageEvent) {
        var paging = event != null ? new Paging(event.length, event.pageIndex, event.pageSize) : this.pagingAlias;
        var sorting = new Sorting(this.sort.active, this.sort.direction);

        this.busy = this.adminService.getSplitHouses({ paging: paging, sorting: sorting }).subscribe(response => {
            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.splitHouses = [];
            response.data.forEach(d => {
                this.splitHouses.push(d);
            });

            this.dataSource.data.next(this.splitHouses);

            this.pagingAlias = { length: response.paging.length, page: response.paging.page, pageSize: response.paging.pageSize };

            this.updateFancy();

            this.toastr.success("Пример каталог сплит-систем получен");
        });
    }

    deleteSplit(id: number) {
        this.busy = this.adminService.deleteSplit({ id: id }).subscribe(response => {

            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            var windowItem = this.splitHouses.findIndex(w => w.id == id);
            if (windowItem >= 0) {
                this.splitHouses.splice(windowItem, 1);
                this.dataSource.data.next(this.splitHouses);
            }

            this.toastr.success("Запись успешно удалена");
        });
    }

    createSplit() {
        const dialogRef = this.dialog.open(AddSplitComponent, this.dialogConfig);

        dialogRef.afterClosed().subscribe(result => {

            if (result == true) {
                this.loadSplitHouses();
            }
        });
    }

    editSplit(id: number) {
        var selectedSplit = this.splitHouses.filter(w => w.id == id)[0];

        this.dialogConfig.data = {
            selectedSplit: selectedSplit
        };

        const dialogRef = this.dialog.open(EditSplitHouseComponent, this.dialogConfig);

        dialogRef.afterClosed().subscribe(result => {

            if (result == true) {
                this.loadSplitHouses();
            }
        });
    }
}

export class WindowDataSource extends DataSource<SplitHouse> {
    data = new Subject<SplitHouse[]>();

    connect(): Subject<SplitHouse[]> {
        return this.data;
    }

    disconnect() {
    }
}