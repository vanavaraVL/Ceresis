import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseGetWindowPlastic } from '../DTO/catalog.dto';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';
import { ResponseGetWorkSample } from "../DTO/worksample.dto";
import { ResponseGetSplitHouse } from '../DTO/split.dto';
import { ResponseGetWorkprice } from '../DTO/workprice.dto';
import { ResponseGetLogotypes } from '../DTO/logotypes.dto';

@Injectable()
export class CatalogService {

    constructor(private http: HttpClient) {

    }

    getWindows(): Observable<ResponseGetWindowPlastic> {
        return this.http.get<ResponseGetWindowPlastic>(window.settings.BaseUrlAPI + "api/v1.0/catalog/windows/all");
    }

    getSplitHouse(): Observable<ResponseGetSplitHouse> {
        return this.http.get<ResponseGetSplitHouse>(window.settings.BaseUrlAPI + "api/v1.0/catalog/splithouse/all");
    }

    getWorkprice(): Observable<ResponseGetWorkprice> {
        return this.http.get<ResponseGetWorkprice>(window.settings.BaseUrlAPI + "api/v1.0/catalog/workprice/all");
    }

    getLogos(): Observable<ResponseGetLogotypes> {
        return this.http.get<ResponseGetLogotypes>(window.settings.BaseUrlAPI + "api/v1.0/catalog/logos/all");
    }
}