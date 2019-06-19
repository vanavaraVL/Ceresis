import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginRequest, LoginResponse } from '../DTO/login.dto';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';
import { ResponseGetWorkSample } from "../DTO/worksample.dto";

@Injectable()
export class WorksampleService {

    constructor(private http: HttpClient) {

    }
    
    getWorksamples(): Observable<ResponseGetWorkSample> {
        return this.http.get<ResponseGetWorkSample>(window.settings.BaseUrlAPI + "api/v1.0/worksample");
    }
}