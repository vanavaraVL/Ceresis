import { ResponseBase, RequestBase } from "./base";

export class WindowPlastic {
    id: number;
    name: string;
    feature: string;
    size: string;
    total: string;
    totalValue: number;
    imageUrl: string;
    hasSetup: boolean;
}

export class ResponseGetWindowPlastic extends ResponseBase {
    data: WindowPlastic[];
}

export class RequestGetWindowPlastic extends RequestBase {

}

export class RequestDeleteWindowPlastic {
    id: number;
}

export class ResponseDeleteWindowPlastic extends ResponseBase {
    
}

export class RequestCreateWindowPlastic {
    name: string;
    feature: string;
    size: string;
    total: number;
    fileName: string;
    fileData: string;
    hasSetup: boolean;
}

export class ResponseCreateWindowPlastic extends ResponseBase {

}

export class RequestUpdateWindowPlastic {
    id: number;
    name: string;
    feature: string;
    size: string;
    total: number;
    fileName: string;
    fileData: string;
    hasSetup: boolean;
}

export class ResponseUpdateWindowPlastic extends ResponseBase {

}