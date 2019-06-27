import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { LoginRequest, LoginResponse } from '../DTO/login.dto';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';
import { RequestGetWorkSample, ResponseGetWorkSample, RequestDeleteWorkSample, ResponseDeleteWorkSample, RequestCreateWorksample, ResponseCreateWorksample } from "../DTO/worksample.dto";
import { RequestGetWindowPlastic, ResponseGetWindowPlastic, RequestDeleteWindowPlastic, ResponseDeleteWindowPlastic, RequestCreateWindowPlastic, ResponseCreateWindowPlastic, RequestUpdateWindowPlastic, ResponseUpdateWindowPlastic } from '../DTO/catalog.dto';
import { RequestEditSplitHouse, ResponseEditSplitHouse, RequestCreateSplitHouse, ResponseCreateSplitHouse, RequestGetSplitHouse, ResponseGetSplitHouse, RequestDeleteSplitHouse, ResponseDeleteSplitHouse } from '../DTO/split.dto';
import { RequestGetWorkprice, ResponseGetWorkprice, RequestEditWorkprice, ResponseEditWorkprice, RequestDeleteWorkprice, ResponseDeleteWorkprice, RequestAddWorkprice, ResponseAddWorkprice } from '../DTO/workprice.dto';
import { RequestGetLogotypes, ResponseGetLogotypes, RequestDeleteLogotype, ResponseDeleteLogotype, RequestAddLogotype, ResponseAddLogotype } from '../DTO/logotypes.dto';
import { RequestCreateCart } from '../DTO/cart.dto';
import { RequestBase } from '../DTO/base';

@Injectable()
export class AdmininstrationService {

    constructor(private http: HttpClient) {

    }

    login(request: LoginRequest): Observable<boolean> {
        return this.http.post<LoginResponse>(window.settings.BaseUrlAPI + "api/v1.0/customer/login", request).pipe(
            map((response: LoginResponse) => {
                const token = response && response.token;
                if (token) {
                    localStorage.setItem('currentUser', JSON.stringify(
                        { username: response.email, token: response.token, roles: response.roles })
                    );
                    return true;
                } else {
                    return false;
                }
            }));
    }

    makeCall(): Observable<boolean> {
        return this.http.post<boolean>(window.settings.BaseUrlAPI + "api/v1.0/administration/call", null);
    }

    fillRequestParams(request: RequestBase): HttpParams {

        let params = new HttpParams();

        // fill paging
        if (request.paging && request.paging.length) {
            params = params.append('Paging.Length', request.paging.length.toString());
        }

        if (request.paging && request.paging.page) {
            params = params.append('Paging.Page', request.paging.page.toString());
        }

        if (request.paging && request.paging.pageSize) {
            params = params.append('Paging.PageSize', request.paging.pageSize.toString());
        }

        // fill sorting
        if (request.sorting && request.sorting.name) {
            params = params.append('Sorting.Name', request.sorting.name);
        }

        if (request.sorting && request.sorting.direction) {
            params = params.append('Sorting.Direction', request.sorting.direction);
        }

        return params;
    }

    getWorksamples(request: RequestGetWorkSample): Observable<ResponseGetWorkSample> {

        let params = this.fillRequestParams(request);
        
        return this.http.get<ResponseGetWorkSample>(window.settings.BaseUrlAPI + "api/v1.0/administration/worksamples", { params: params });
    }

    deleteWorkSample(request: RequestDeleteWorkSample): Observable<ResponseDeleteWorkSample> {
        return this.http.delete<ResponseDeleteWorkSample>(window.settings.BaseUrlAPI + `api/v1.0/administration/worksamples/${request.id}`);
    }

    createWorksample(request: RequestCreateWorksample): Observable<ResponseCreateWorksample> {
        return this.http.post<ResponseDeleteWorkSample>(window.settings.BaseUrlAPI + "api/v1.0/administration/worksamples/new", request);
    }

    getWindows(request: RequestGetWindowPlastic): Observable<ResponseGetWindowPlastic> {

        let params = this.fillRequestParams(request);

        return this.http.get<ResponseGetWindowPlastic>(window.settings.BaseUrlAPI + "api/v1.0/administration/windows", { params: params });
    }

    getSplitHouses(request: RequestGetSplitHouse): Observable<ResponseGetSplitHouse> {

        let params = this.fillRequestParams(request);

        return this.http.get<ResponseGetSplitHouse>(window.settings.BaseUrlAPI + "api/v1.0/administration/splithouse", { params: params });
    }

    deleteWindow(request: RequestDeleteWindowPlastic): Observable<ResponseDeleteWindowPlastic> {
        return this.http.delete<ResponseDeleteWindowPlastic>(window.settings.BaseUrlAPI + `api/v1.0/administration/windows/${request.id}`);
    }

    deleteSplit(request: RequestDeleteSplitHouse): Observable<ResponseDeleteSplitHouse> {
        return this.http.delete<ResponseDeleteSplitHouse>(window.settings.BaseUrlAPI + `api/v1.0/administration/splithouse/${request.id}`);
    }

    createWindow(request: RequestCreateWindowPlastic): Observable<ResponseCreateWindowPlastic> {
        return this.http.post<ResponseCreateWindowPlastic>(window.settings.BaseUrlAPI + "api/v1.0/administration/windows/new", request);
    }

    editWindow(request: RequestUpdateWindowPlastic): Observable<ResponseUpdateWindowPlastic> {
        return this.http.post<ResponseCreateWindowPlastic>(window.settings.BaseUrlAPI + `api/v1.0/administration/windows/update/${request.id}`, request);
    }

    editSplitHouse(request: RequestEditSplitHouse): Observable<ResponseEditSplitHouse> {
        return this.http.post<ResponseEditSplitHouse>(window.settings.BaseUrlAPI + `api/v1.0/administration/splithouse/update/${request.id}`, request);
    }

    createSplitHouse(request: RequestCreateSplitHouse): Observable<ResponseCreateSplitHouse> {
        return this.http.post<ResponseCreateWindowPlastic>(window.settings.BaseUrlAPI + "api/v1.0/administration/splithouse/new", request);
    }

    getWorkprice(request: RequestGetWorkprice): Observable<ResponseGetWorkprice> {

        let params = this.fillRequestParams(request);

        return this.http.get<ResponseGetWorkprice>(window.settings.BaseUrlAPI + "api/v1.0/administration/workprice", { params: params });
    }

    editWorkprice(request: RequestEditWorkprice): Observable<ResponseEditWorkprice> {
        return this.http.post<ResponseEditWorkprice>(window.settings.BaseUrlAPI + `api/v1.0/administration/workprice/update/${request.id}`, request);
    }

    deleteWorkprice(request: RequestDeleteWorkprice): Observable<ResponseDeleteWorkprice> {
        return this.http.delete<ResponseDeleteWorkprice>(window.settings.BaseUrlAPI + `api/v1.0/administration/workprice/${request.id}`);
    }

    addWorkprice(request: RequestAddWorkprice): Observable<ResponseAddWorkprice> {
        return this.http.post<ResponseAddWorkprice>(window.settings.BaseUrlAPI + "api/v1.0/administration/workprice/new", request);
    }

    getLogos(request: RequestGetLogotypes): Observable<ResponseGetLogotypes> {

        let params = this.fillRequestParams(request);

        return this.http.get<ResponseGetLogotypes>(window.settings.BaseUrlAPI + "api/v1.0/administration/logos", { params: params });
    }

    deleteLogo(request: RequestDeleteLogotype): Observable<ResponseDeleteLogotype> {
        return this.http.delete<ResponseDeleteLogotype>(window.settings.BaseUrlAPI + `api/v1.0/administration/logos/${request.id}`);
    }

    createLogo(request: RequestAddLogotype): Observable<ResponseAddLogotype> {
        return this.http.post<ResponseAddLogotype>(window.settings.BaseUrlAPI + "api/v1.0/administration/logos/new", request);
    }
}