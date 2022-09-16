export class IPaginationOptions {
    pageSize: number;
    currentPage: number;
    totalItemsCount?: number;
    hasPreviousPage?: number;
    hasNextPage?: number;
  
    constructor(pageSize: number, currentPage: number, totalItemsCount?: number, hasPreviousPage?: number, hasNextPage?: number) {
      this.pageSize = pageSize;
      this.currentPage = currentPage;
      this.totalItemsCount = totalItemsCount;
      this.hasPreviousPage = hasPreviousPage;
      this.hasNextPage = hasNextPage;
    }
  }