import { RequestBase, ResponseBase } from "./base";

export class WorkPrice {
    id: number;
    name: string;
    unity: string;
    exactPrice: boolean;
    contactPrice: boolean;
    price: number;
}

export class RequestGetWorkprice extends RequestBase {

}

export class ResponseGetWorkprice extends ResponseBase {
    data: WorkPrice[];
}

export class RequestAddWorkprice {
    name: string;
    unity: string;
    exactPrice: boolean;
    contactPrice: boolean;
    price: number;
}

export class ResponseAddWorkprice extends ResponseBase {

}

export class RequestEditWorkprice {
    id: number;
    name: string;
    unity: string;
    exactPrice: boolean;
    contactPrice: boolean;
    price: number;
}

export class ResponseEditWorkprice extends ResponseBase {
    
}

export class RequestDeleteWorkprice {
    id: number;
}

export class ResponseDeleteWorkprice extends ResponseBase {
    
}