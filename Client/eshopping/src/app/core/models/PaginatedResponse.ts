export interface PaginatedResponse<T>{
    pageIndex: number;
    totalCount: number;
    items: Array<T>;
}