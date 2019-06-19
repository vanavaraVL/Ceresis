import { RequestBase, ResponseBase } from "./base";

export class LogoType {
    id: number;
    name: string;
    description: string;
    imageUrl: string;
    category: string;
    type: string;
    typeValue: number;
}

export class RequestGetLogotypes extends RequestBase {
}

export class ResponseGetLogotypes extends ResponseBase {
    data: LogoType[];
}

export class RequestAddLogotype {
    name: string;
    description: string;
    fileName: string;
    fileData: string;
    typeValue: number;
}

export class ResponseAddLogotype extends ResponseBase {

}

export class RequestDeleteLogotype {
    id: number;
}

export class ResponseDeleteLogotype extends ResponseBase {

}