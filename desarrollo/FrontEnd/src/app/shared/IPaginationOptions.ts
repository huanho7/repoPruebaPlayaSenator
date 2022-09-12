export class IPaginationOptions {
    limit: number;
    page: number;
    route?: string;
  
    constructor(limit: number, page: number, route?: string) {
      this.limit = limit;
      this.page = page;
      this.route = route;
    }
  }