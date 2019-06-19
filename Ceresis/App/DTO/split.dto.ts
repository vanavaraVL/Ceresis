import { ResponseBase, RequestBase } from "./base";

export class RequestGetSplitHouse extends RequestBase {

}

export class ResponseGetSplitHouse extends ResponseBase {
    data: SplitHouse[];
}

export class SplitHouse {
    energoEfficienty: string;
    imageUrl: string;
    model: string;
    noise: number;
    power: string;
    powerRealty: string;
    price: number;
    sizeExternal: string;
    sizeInternal: string;
    id: number;
}

export class RequestEditSplitHouse {
    energoEfficienty: string;
    fileName: string;
    fileData: string;
    model: string;
    noise: number;
    power: string;
    powerRealty: string;
    price: number;
    sizeExternal: string;
    sizeInternal: string;
    id: number;
}

export class RequestCreateSplitHouse {
    energoEfficienty: string;
    fileName: string;
    fileData: string;
    model: string;
    noise: number;
    power: string;
    powerRealty: string;
    price: number;
    sizeExternal: string;
    sizeInternal: string;
}

export class ResponseCreateSplitHouse extends ResponseBase {
    
}

export class ResponseEditSplitHouse extends ResponseBase {

}

export class RequestDeleteSplitHouse {
    id: number;
}

export class ResponseDeleteSplitHouse extends ResponseBase {
    
}