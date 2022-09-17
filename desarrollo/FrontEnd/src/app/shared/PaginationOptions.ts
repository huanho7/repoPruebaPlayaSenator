export class PaginationOptions {
    pageSize: number;
    currentPage: number;
    totalItemsCount?: number;
    hasPreviousPage?: number;
    hasNextPage?: number;
    currentItemsCount?: number;
  
    constructor(pageSize: number, currentPage: number, totalItemsCount?: number, hasPreviousPage?: number, hasNextPage?: number, currentItemsCount?:number) {
      this.pageSize = pageSize;
      this.currentPage = currentPage;
      this.totalItemsCount = totalItemsCount;
      this.hasPreviousPage = hasPreviousPage;
      this.hasNextPage = hasNextPage;
      this.currentItemsCount = currentItemsCount;
    }
  }