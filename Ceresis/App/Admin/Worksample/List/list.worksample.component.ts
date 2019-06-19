import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild  } from '@angular/core';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { MatTableDataSource, MatSort, MatPaginator, PageEvent } from '@angular/material';
import { DataSource } from '@angular/cdk/table';
import { Subject, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import { AddWorksampleComponent } from "../Add/add.worksample.component";
import { WorkSample, RequestGetWorkSample, ResponseGetWorkSample } from "../../../DTO/worksample.dto";
import { Router } from "@angular/router";
import { RoutesEnum, RoutesName } from "../../../routes.name";
import { Paging, Sorting } from '../../../DTO/base';

@Component({
    selector: 'list-worksample-component',
    templateUrl: './list.worksample.component.html',
    styleUrls: ['./list.worksample.component.scss'],
})
export class ListWorksampleComponent implements OnInit, AfterViewInit, OnDestroy {

    busy: Subscription;

    public displayedColumns = ['imageName', 'imageData', 'description', 'imagePath', 'delete'];
    public dataSource = new WorkSampleDataSource()

    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    pagingAlias: Paging = new Paging(0, 0, 10);

    workSamples: WorkSample[] = [];

    dialogConfig: any;

    constructor(private toastr: ToastsManager, private router: Router, private adminService: AdmininstrationService,
        private dialog: MatDialog) {

    }

    ngOnInit() {
        this.loadWorkSamples();

        this.dialogConfig = {
            disableClose: false,
            data: {}
        }
    }

    ngAfterViewInit(): void {
        this.sort.sortChange.subscribe(() => this.pagingAlias.page = 0);

        this.sort.sortChange.pipe(
            tap(() => this.loadWorkSamples())).subscribe();
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

    loadWorkSamples(event?: PageEvent) {
        var paging = event != null ? new Paging(event.length, event.pageIndex, event.pageSize) : this.pagingAlias;
        var sorting = new Sorting(this.sort.active, this.sort.direction);

        this.busy = this.adminService.getWorksamples({ paging: paging, sorting: sorting }).subscribe(response => {
            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.workSamples = [];
            response.data.forEach(d => {
                this.workSamples.push(d);
            });

            this.dataSource.data.next(this.workSamples);

            this.pagingAlias = { length: response.paging.length, page: response.paging.page, pageSize: response.paging.pageSize };

            this.updateFancy();

            this.toastr.success("Примеры работы успешно получены");
        });
    }

    delteWorkItem(id: number) {
        this.busy = this.adminService.deleteWorkSample({ id: id }).subscribe(response => {

            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            var workItemIndx = this.workSamples.findIndex(w => w.id == id);
            if (workItemIndx >= 0) {
                this.workSamples.splice(workItemIndx, 1);
                this.dataSource.data.next(this.workSamples);
            }

            this.toastr.success("Запись успешно удалена");
        });
    }

    createWorksample() {
        const dialogRef = this.dialog.open(AddWorksampleComponent, this.dialogConfig);

        dialogRef.afterClosed().subscribe(result => {

            if (result == true) {
                this.loadWorkSamples();
            }
        });
    }
}

export class WorkSampleDataSource extends DataSource<WorkSample> {
    data = new Subject<WorkSample[]>();

    connect(): Subject<WorkSample[]> {
        return this.data;
    }

    disconnect() {
    }
}