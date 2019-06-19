import { Injectable } from "@angular/core";
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { ToastsManager } from 'ng6-toastr';
import { Router } from "@angular/router";
import { AuthService } from "../Services/auth.service";
import { Location } from '@angular/common';
import { RoutesEnum, RoutesName } from "../routes.name";

import "rxjs/add/operator/catch";
import "rxjs/add/observable/throw";
import { catchError, map } from 'rxjs/operators';

@Injectable()
export class RequestInterceptor implements HttpInterceptor {
    constructor(private toaster: ToastsManager,
        private router: Router,
        private location: Location,
        private authService: AuthService) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        req = req.clone({
            setHeaders: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.authService.info().token || ''}`
            }
        });

        return next.handle(req)
            .pipe(
                map((response: any) => {
                    return response;
                }),
                catchError((err: HttpErrorResponse) => {
                    if (err instanceof HttpErrorResponse) {

                        if (err.status === 401) {
                            localStorage.removeItem('currentUser');

                            if (this.location.path().toLowerCase().indexOf('admin') > -1) {
                                this.toaster.error('Неверный логин/пароль');
                            } else {
                                this.toaster.error('Указанный email не существует');
                                this.router.navigate([RoutesName.HOME], {});
                            }
                        } else {
                            if (err.error && err.error.Error) {
                                console.log(err);
                            }
                        }
                    }

                    return Observable.throw(err);
                })
            );
    }
}