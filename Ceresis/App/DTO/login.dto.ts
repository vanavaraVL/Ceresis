import { ResponseBase } from './base';


export class LoginRequest {
    email: string;
    password: string;
}

export class LoginResponse extends ResponseBase {
    email: string;
    token: string;
    roles: string[];
}