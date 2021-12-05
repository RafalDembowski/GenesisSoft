export interface Pagination {
    currentPage: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
}

export class PaginatedResult<T> {
    data: T;
    pagination: Pagination;

    constructor(data: T , pagination: Pagination){
        this.data = data;
        this.pagination = pagination;
    }
}

export class PagingParams {
    currentPage: number;
    pageSize: number;

    constructor(currentPage = 1 , pageSize = 10){
        this.currentPage = currentPage;
        this.pageSize = pageSize;
    }
}