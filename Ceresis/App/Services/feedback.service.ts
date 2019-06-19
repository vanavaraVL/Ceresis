import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FeedBackRequest, FeedBackResponse } from '../DTO/feedback.dto';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class FeedbackService {

    constructor(private http: HttpClient) {

    }

    sendQuestion(request: FeedBackRequest): Observable<FeedBackResponse> {
        return this.http.post<FeedBackResponse>(window.settings.BaseUrlAPI + "api/v1.0/feedback/send", request);
    }
}