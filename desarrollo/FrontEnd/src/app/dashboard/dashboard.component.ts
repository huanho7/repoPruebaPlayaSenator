import {Component, OnInit} from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subscription } from 'rxjs';
import {HotelDto} from '../entities/HotelDto';
import { HotelService } from '../services/hotelservice';
import { PaginationOptions } from '../shared/PaginationOptions';
import { SnackbarService } from '../shared/Snackbar.service';
import { HoteldetailComponent } from './hoteldetail/hoteldetail.component';
import { MatDialog } from '@angular/material/dialog';
import { HotelConstants } from '../shared/Constants/HotelConstants';
import { PageEvent } from '@angular/material/paginator';
import { HotelFilterQueryParametersViewModel } from '../ViewModels/HotelFilterQueryParametersViewModel';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  private subscriptions: Subscription[]  = [];
  
  public hotelfilterQuery : HotelFilterQueryParametersViewModel = {
    FilterName:undefined,
    FilterTop:undefined,
    PagOptions:{
      pageSize: 5, 
      currentPage:1
    }
  }

  public filtroForm!: FormGroup;
  public listadoHoteles: HotelDto[] = [];
  public imageHotelNotAvaible = HotelConstants.IMAGE_HOTEL_NOT_AVAIBLE;

  constructor(private dataService: HotelService,
              private fb: FormBuilder,
              private spinner: NgxSpinnerService,
              private snackBar: SnackbarService,
              private matDialog: MatDialog) { 

                // Inicializar filtros 
                this.filtroForm = this.fb.group({
                  name: [''],
                  top: [false]
                });
  }



  displayedColumns = ['image','name', 'category', 'action'];
  dataSource = [];

  ngOnInit() {

    this.filtrar();
  }

  filtrar() {

    console.log(this.filtroForm.controls['top']?.value);

    // Se recuperan primero los parámetros de búsqueda (si existen)
    this.hotelfilterQuery.FilterName = this.filtroForm.controls['name']?.value;
    this.hotelfilterQuery.FilterTop = this.filtroForm.controls['top']?.value;

    this.spinner.show();
    this.dataService.getListaHotelesPaginated(this.hotelfilterQuery).subscribe(res => {
      this.spinner.hide();
      if (res.resultadoOperacion) {

        this.listadoHoteles = res.respuesta;
        this.dataSource = res.respuesta;
        this.hotelfilterQuery.PagOptions = res.resultadoPaginacion;

      } else {
        this.snackBar.openSnackBar('No se han encontrado resultados debido a un error en el sistema.');
        this.listadoHoteles = [];
      }
    });
  }
  
  public openHotelModal(idHotel:number): void {

    const data = {
      id:idHotel
    };

    const dialog = this.matDialog.open(HoteldetailComponent, {
      panelClass: 'custom-dialog-container',
      width: '40%',
      data,
      autoFocus : false
    });

    const sub: Subscription = dialog.afterClosed().subscribe((res: boolean) => {
      if (res) {
        this.hotelfilterQuery.PagOptions = {pageSize: 5, currentPage:1}
        this.filtrar();
      }
    });

    this.subscriptions.push(sub);
  }  

  pageChanged(page: PageEvent){
    if (page) {
      this.hotelfilterQuery.PagOptions.currentPage = ++page.pageIndex;
    }

    this.filtrar();
  }

  buscarHoteles(){
    // Para buscar desde la primera página
    this.hotelfilterQuery.PagOptions = {pageSize: 5, currentPage:1}

    this.filtrar();
  }

}

