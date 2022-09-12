import {Component, OnInit} from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import {HotelDto} from '../entities/HotelDto';
import { HotelService } from '../services/hotelservice';
import { IPaginacionArgs } from '../shared/IPaginationArgs';
import { IPaginationOptions } from '../shared/IPaginationOptions';
import { SnackbarService } from '../shared/Snackbar.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  pageSize : number = 10; 
  currentPage = 1;
  route = '';

  //public busquedaForm: FormGroup;

  public listadoHoteles: HotelDto[] = [];

  constructor(private dataService: HotelService,
              private fb: FormBuilder,
              private spinner: NgxSpinnerService,
              private snackBar: SnackbarService) {

    // this.busquedaForm = this.fb.group({
    //   // run: ['', [validarDigitoVerificador]],
    //   // nombreApellido: ['', [Validators.minLength(3), Validators.maxLength(60)]],
    //   // idSolicitud: [''],
    //   // idTramite: [''],
    //   // tipoTramite: [''],
    //   // estadoTramite: [''],
    //   // estadoSolicitud: [''],
    //   // claseLicencia: [''],
    //   // fechaInicio: ['']
    // })   

  }



  displayedColumns = ['name', 'category', 'status', 'action'];
  dataSource = [
    {Id: 1, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 2, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 3, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 4, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 5, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1}
  ];
  //dataSource = new PostDataSource(this.dataService);

  ngOnInit() {
    // this.getEstadosTramites();
    // this.getTipoTramites();
    // this.getClasesLicencias();

    this.filtrar();
  }

  filtrar() {
    // this.mensaje = 'Buscando resultados...';
    // this.pageSize = parseInt(this.pages.value, 0);

    const argumentos: IPaginacionArgs = {
      filter: null,
      paginationOptions: new IPaginationOptions(this.pageSize, this.currentPage, this.route),
      order: undefined
    };
  
    //let busquedaFormValue = this.getFormData();
  
    this.spinner.show();
    this.dataService.getListaHoteles(argumentos, null).subscribe(res => {
      this.spinner.hide();
      if (res.resultadoOperacion) {

        //this.respuestaPaginacion = res.data.Respuesta;
        //this.listadoHoteles = this.respuestaPaginacion.items;
        this.listadoHoteles = res.respuesta;
        this.dataSource = res.respuesta;
        //this.length = this.respuestaPaginacion.meta.totalItems;
        //this.currentPage = this.respuestaPaginacion.meta.currentPage;
  
        //this.mostrandoInicio = res.data.Respuesta.meta.currentPage * res.data.Respuesta.meta.itemsPerPage - res.data.Respuesta.meta.itemsPerPage + 1;
        // this.mostrandoFin = res.data.Respuesta.meta.currentPage * res.data.Respuesta.meta.itemsPerPage > this.length
        //     ? this.length
        //     : res.data.Respuesta.meta.currentPage * res.data.Respuesta.meta.itemsPerPage;
      } else {
        this.snackBar.openSnackBar(res.data.Error);
        // this.length = 0;
        this.listadoHoteles = [];
        // this.mensaje = 'No se han encontrado resultados debido a un error en el sistema.';
      }
    });
  }

  getFormData(){
    // const _fecha = this.busquedaForm.get(['fechaInicio'])?.value ?
    // this.datePipe.transform(this.busquedaForm.get(['fechaInicio'])?.value, 'yyyy-MM-dd')
    // : null;    

    // let busquedaFormValue = {
    //   run: this.busquedaForm.get('run').value,
    //   nombreApellido: this.busquedaForm.get('nombreApellido').value,
    //   idSolicitud: this.busquedaForm.get('idSolicitud').value,
    //   idTipoTramite: this.busquedaForm.get('tipoTramite').value,
    //   idClaseLicencia: this.busquedaForm.get('claseLicencia').value,
    //   idEstadoTramite: this.busquedaForm.get('estadoTramite').value,
    //   fechaSolicitud: _fecha
    // }

    // return busquedaFormValue
  }  

}

