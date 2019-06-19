import { ResponseBase } from './base';

export class FeedBackDTO {
    name: string;
    email: string;
    phone: string;
    message: string;
}

export class FeedBackRequest {
    name: string;
    email: string;
    phone: string;
    message: string;
}

export class FeedBackResponse extends ResponseBase {

}