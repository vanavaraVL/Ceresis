export class ResponseBase {
    isError: boolean;
    message: string;
    paging: Paging;
}

export class RequestBase {
    paging?: Paging;
    sorting?: Sorting;
}

export class Paging {

    constructor(length: number, page: number, pageSize: number) {
        this.length = length;
        this.page = page;
        this.pageSize = pageSize;
    }

    length: number;
    page: number;
    pageSize: number;
}

export class Sorting {

    constructor(name: string, direction: string) {
        this.name = name;
        this.direction = direction;
    }

    name: string;
    direction: string;
}