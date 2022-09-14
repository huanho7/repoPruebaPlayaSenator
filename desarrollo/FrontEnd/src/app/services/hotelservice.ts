import { HttpClient, HttpParams } from '@angular/common/http';
import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IPaginacionArgs } from '../shared/IPaginationArgs';
import { ChangeRelevanceRequestViewModel } from '../ViewModels/ChangeRelevanceRequestViewModel';

@Injectable({
  providedIn: 'root',
})
export class HotelService {

  constructor(private _httpClient: HttpClient) {
  }

  // Obtenemos la lista de hoteles
  getListaHoteles(args: IPaginacionArgs, busqueda: any): Observable<any> {

    let rutaBackend : string = environment.rutaBackEndDev;

    // Filtro
    let params = new HttpParams();

    if (busqueda) {
      busqueda.run != null ? (params = params.append('run', busqueda.run)) : null;
      busqueda.nombreApellido != null ? (params = params.append('nombreApellido', busqueda.nombreApellido)) : null;
      busqueda.idSolicitud != null ? (params = params.append('idSolicitud', busqueda.idSolicitud)) : null;
      busqueda.idTipoTramite != null ? (params = params.append('idTipoTramite', busqueda.idTipoTramite)) : null;
      busqueda.idClaseLicencia != null ? (params = params.append('idClaseLicencia', busqueda.idClaseLicencia)) : null;
    }
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
  // getHotelById(args: IPaginacionArgs, busqueda: any): Observable<any> {

  //   let rutaBackend : string = environment.rutaBackEndDev;

  //   // Filtro
  //   let params = new HttpParams();

  //   if (busqueda) {
  //     busqueda.run != null ? (params = params.append('run', busqueda.run)) : null;
  //     busqueda.nombreApellido != null ? (params = params.append('nombreApellido', busqueda.nombreApellido)) : null;
  //     busqueda.idSolicitud != null ? (params = params.append('idSolicitud', busqueda.idSolicitud)) : null;
  //     busqueda.idTipoTramite != null ? (params = params.append('idTipoTramite', busqueda.idTipoTramite)) : null;
  //     busqueda.idClaseLicencia != null ? (params = params.append('idClaseLicencia', busqueda.idClaseLicencia)) : null;
  //   }

  //   return this._httpClient.get<any>(rutaBackend + '/GetHoteles'/*, args, { params: params }*/);
  // }
}