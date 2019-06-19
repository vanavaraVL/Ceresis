import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginRequest, LoginResponse } from '../DTO/login.dto';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';
import { RequestGetWorkSample, ResponseGetWorkSample, RequestDeleteWorkSample, ResponseDeleteWorkSample, RequestCreateWorksample, ResponseCreateWorksample } from "../DTO/worksample.dto";
import { RequestGetWindowPlastic, ResponseGetWindowPlastic, RequestDeleteWindowPlastic, ResponseDeleteWindowPlastic, RequestCreateWindowPlastic, ResponseCreateWindowPlastic, RequestUpdateWindowPlastic, ResponseUpdateWindowPlastic } from '../DTO/catalog.dto';
import { RequestEditSplitHouse, ResponseEditSplitHouse, RequestCreateSplitHouse, ResponseCreateSplitHouse, RequestGetSplitHouse, ResponseGetSplitHouse, RequestDeleteSplitHouse, ResponseDeleteSplitHouse } from '../DTO/split.dto';
import { RequestGetWorkprice, ResponseGetWorkprice, RequestEditWorkprice, ResponseEditWorkprice, RequestDeleteWorkprice, ResponseDeleteWorkprice, RequestAddWorkprice, ResponseAddWorkprice } from '../DTO/workprice.dto';
import { RequestGetLogotypes, ResponseGetLogotypes, RequestDeleteLogotype, ResponseDeleteLogotype, RequestAddLogotype, ResponseAddLogotype } from '../DTO/logotypes.dto';
import { RequestCreateCart } from '../DTO/cart.dto';

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

    getWorksamples(request: RequestGetWorkSample): Observable<ResponseGetWorkSample> {
        return this.http.post<ResponseGetWorkSample>(window.settings.BaseUrlAPI + "api/v1.0/administration/worksamples", request);
    }

    deleteWorkSample(request: RequestDeleteWorkSample): Observable<ResponseDeleteWorkSample> {
        return this.http.delete<ResponseDeleteWorkSample>(window.settings.BaseUrlAPI + `api/v1.0/administration/worksamples/${request.id}`);
    }

    createWorksample(request: RequestCreateWorksample): Observable<ResponseCreateWorksample> {
        return this.http.post<ResponseDeleteWorkSample>(window.settings.BaseUrlAPI + "api/v1.0/administration/worksamples/new", request);
    }

    getWindows(request: RequestGetWindowPlastic): Observable<ResponseGetWindowPlastic> {
        return this.http.post<ResponseGetWindowPlastic>(window.settings.BaseUrlAPI + "api/v1.0/administration/windows", request);
    }

    getSplitHouses(request: RequestGetSplitHouse): Observable<ResponseGetSplitHouse> {
        return this.http.post<ResponseGetSplitHouse>(window.settings.BaseUrlAPI + "api/v1.0/administration/splithouse", request);
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
        return this.http.post<ResponseGetWorkprice>(window.settings.BaseUrlAPI + "api/v1.0/administration/workprice", request);
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
        return this.http.post<ResponseGetLogotypes>(window.settings.BaseUrlAPI + "api/v1.0/administration/logos", request);
    }

    deleteLogo(request: RequestDeleteLogotype): Observable<ResponseDeleteLogotype> {
        return this.http.delete<ResponseDeleteLogotype>(window.settings.BaseUrlAPI + `api/v1.0/administration/logos/${request.id}`);
    }

    createLogo(request: RequestAddLogotype): Observable<ResponseAddLogotype> {
        return this.http.post<ResponseAddLogotype>(window.settings.BaseUrlAPI + "api/v1.0/administration/logos/new", request);
    }
}