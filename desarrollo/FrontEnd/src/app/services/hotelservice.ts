import { HttpClient, HttpParams } from '@angular/common/http';
import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaginationOptions } from '../shared/PaginationOptions';
import { ChangeRelevanceRequestViewModel } from '../ViewModels/ChangeRelevanceRequestViewModel';
import { HotelFilterQueryParametersViewModel } from '../ViewModels/HotelFilterQueryParametersViewModel';

@Injectable({
  providedIn: 'root',
})
export class HotelService {

  constructor(private _httpClient: HttpClient) {
  }

  // Obtenemos la lista de hoteles
  getListaHoteles(): Observable<any> {

    let rutaBackend : string = environment.rutaBackEndDev;

    let response = this._httpClient.get<any>(rutaBackend + '/GetHoteles'/*, args, { params: params }*/);
    return response;
  }

  // Actualizamos la relevancia del hotel
  setRelevanciaHotel(changeRelevanceRequestViewModel:ChangeRelevanceRequestViewModel): Observable<any> {

    let rutaBackend : string = environment.rutaBackEndDev;

    let response = this._httpClient.post<any>(rutaBackend + '/ChangeRelevancePost', changeRelevanceRequestViewModel);
    return response;
  }

  // // Obtenemos un hotel por su id
  getHotelById(idHotel:number): Observable<any> {

    let rutaBackend : string = environment.rutaBackEndDev;

    return this._httpClient.get<any>(rutaBackend + '/GetHotelById/' + idHotel);
  }

  // Obtenemos la lista de hoteles paginada
  getListaHotelesPaginated(searchFilter : HotelFilterQueryParametersViewModel): Observable<any> {

    let rutaBackend : string = environment.rutaBackEndDev;

    let response = this._httpClient.post<any>(rutaBackend + '/GetHotelesPaginado', searchFilter);
    return response;
  }  
}