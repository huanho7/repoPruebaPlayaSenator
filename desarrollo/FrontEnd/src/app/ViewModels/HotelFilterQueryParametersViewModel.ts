import { PaginationOptions } from "../shared/PaginationOptions";

export class HotelFilterQueryParametersViewModel{
    FilterName? : string;
    FilterTop? : boolean;
    PagOptions : PaginationOptions; 
    
    constructor(PagOptions:PaginationOptions, FilterName?:string, FilterTop?:boolean ){
        this.FilterName = FilterName,
        this.FilterTop = FilterTop,
        this.PagOptions = PagOptions
    }
}