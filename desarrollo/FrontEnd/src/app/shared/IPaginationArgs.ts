import { IPaginationOptions } from "./IPaginationOptions";
import { IPaginationOrder } from "./IPaginationOrder";

export class IPaginacionArgs {
  order?: IPaginationOrder;
  filter?: any;
  paginationOptions?: IPaginationOptions;
  /** Filtro de busqueda del formulario buscar */
  SearchFilter?: string;
}