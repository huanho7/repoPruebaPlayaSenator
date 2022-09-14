import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { HotelService } from 'src/app/services/hotelservice';
import { SnackbarService } from 'src/app/shared/Snackbar.service';
import { ChangeRelevanceRequestViewModel } from 'src/app/ViewModels/ChangeRelevanceRequestViewModel';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-hoteldetail',
  templateUrl: './hoteldetail.component.html',
  styleUrls: ['./hoteldetail.component.css']
})
export class HoteldetailComponent implements OnInit {

  public detalleHotelForm!: FormGroup;  

  constructor(private spinner: NgxSpinnerService,
              private dataService: HotelService,
              private snackBar: SnackbarService,
              private fb: FormBuilder
              ) { }

  ngOnInit(): void {
    this.initFormHotel();
  }

  initFormHotel(){
    this.detalleHotelForm = this.fb.group({
      foto: ['foto'],
      nombre: ['ejemplo'],
      descripcion: ['descripcionej']
    });
  }

  CambiarRelevanciaHotel(){
    Swal.fire({

      title: '¿Confirma que desea cambiar la relevancia del hotel?',
      confirmButtonText: "Si",
      cancelButtonText: "No",
      showCancelButton: true,
    }).then((swal: { isConfirmed: any; }) => {
      if (swal.isConfirmed) {
        //this.matDialogRef.close()
        let newCRReq : ChangeRelevanceRequestViewModel = new ChangeRelevanceRequestViewModel();

        newCRReq.IdHotel = 1;
        newCRReq.IdNewRelevanceStatus = 2;

        this.spinner.show();
        this.dataService.setRelevanciaHotel(newCRReq).subscribe(res => {
          this.spinner.hide();
          if (res.resultadoOperacion) {
            this.snackBar.openSnackBar('El nivel de relevancia del hotel se actualizó correctamente');
          } else {
            this.snackBar.openSnackBar('Debido a un error no pudo actualizarse el nivel de relevancia del hotel');
          }
        });        

      }
    });    
  }  

}
