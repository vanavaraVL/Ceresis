import { ResponseBase, RequestBase, Sorting } from "./base";

export class WorkSample {
    imageName: string;
    description: string;
    imagePath: string;
    id: number;
}

export class RequestGetWorkSample extends RequestBase {
}

export class ResponseGetWorkSample extends ResponseBase {
    data: WorkSample[];
}

export class RequestDeleteWorkSample {
    id: number;
}

export class ResponseDeleteWorkSample extends ResponseBase {
    
}

export class RequestCreateWorksample {
    name: string;
    description: string;
    fileName: string;
    fileData: string;
}

export class ResponseCreateWorksample extends ResponseBase {
    
}