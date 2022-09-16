import {Component, OnInit} from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subscription } from 'rxjs';
import {HotelDto} from '../entities/HotelDto';
import { HotelService } from '../services/hotelservice';
import { IPaginacionArgs } from '../shared/IPaginationArgs';
import { IPaginationOptions } from '../shared/IPaginationOptions';
import { SnackbarService } from '../shared/Snackbar.service';
import { HoteldetailComponent } from './hoteldetail/hoteldetail.component';
import { MatDialog } from '@angular/material/dialog';
import { HotelConstants } from '../shared/Constants/HotelConstants';
import { PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  private subscriptions: Subscription[]  = [];
  public pagOptions : IPaginationOptions = {pageSize: 5, currentPage:1}

  public listadoHoteles: HotelDto[] = [];
  public imageHotelNotAvaible = HotelConstants.IMAGE_HOTEL_NOT_AVAIBLE;

  constructor(private dataService: HotelService,
              private fb: FormBuilder,
              private spinner: NgxSpinnerService,
              private snackBar: SnackbarService,
              private matDialog: MatDialog) {  

  }



  displayedColumns = ['image','name', 'category', 'action'];
  dataSource = [];

  ngOnInit() {

    this.filtrar();
  }

  filtrar() {

  
    this.spinner.show();
    this.dataService.getListaHotelesPaginated(this.pagOptions).subscribe(res => {
      this.spinner.hide();
      if (res.resultadoOperacion) {

        this.listadoHoteles = res.respuesta;
        this.dataSource = res.respuesta;
        this.pagOptions = res.resultadoPaginacion;

      } else {
        this.snackBar.openSnackBar('No se han encontrado resultados debido a un error en el sistema.');
        this.listadoHoteles = [];
      }
    });
  }

  getFormData(){

  }
  
  public openHotelModal(idHotel:number): void {

    const data = {
      id:idHotel
    };

    const dialog = this.matDialog.open(HoteldetailComponent, {
      panelClass: 'custom-dialog-container',
      width: '50%',
      data,
      autoFocus : false
    });

    const sub: Subscription = dialog.afterClosed().subscribe((res: boolean) => {
      if (res) {
        this.pagOptions = {pageSize: 5, currentPage:1}
        this.filtrar();
      }
    });

    this.subscriptions.push(sub);
  }  

  pageChanged(page: PageEvent){
    if (page) {
      this.pagOptions.currentPage = ++page.pageIndex;
    }

    this.filtrar();
  }

}

