import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { HotelDto } from 'src/app/entities/HotelDto';
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

  public hotelDetailDto!: HotelDto;
  public detalleHotelForm!: FormGroup;  

  constructor(private spinner: NgxSpinnerService,
              private dataService: HotelService,
              private snackBar: SnackbarService,
              private fb: FormBuilder,
              @Inject(MAT_DIALOG_DATA) public data: any,
              private matDialogRef: MatDialogRef<HoteldetailComponent>,
              ) { }

  ngOnInit(): void {
    this.initFormHotel();
  }

  initFormHotel(){

    this.spinner.show();

    if(!(this.data && this.data.id)){
      this.snackBar.openSnackBar('No se ha facilitado id de hotel para consultar');
    }

    this.dataService.getHotelById(this.data.id).subscribe(x => {
      console.log(x)
      if (x.resultadoOperacion) {

        this.hotelDetailDto = x.respuesta;
        this.loadFormHotel(x.respuesta);
      } else {
        this.snackBar.openSnackBar('Se ha producido un error al obtener los detalles del hotel');
      }

      this.spinner.hide();
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

        newCRReq.IdHotel = this.hotelDetailDto.id;

        if(this.hotelDetailDto.idRelevance == 1)
        {
          newCRReq.IdNewRelevanceStatus = 2;
        }
        else{
          newCRReq.IdNewRelevanceStatus = 1;
        }

        

        this.spinner.show();
        this.dataService.setRelevanciaHotel(newCRReq).subscribe(res => {
          this.spinner.hide();
          if (res.resultadoOperacion) {
            this.snackBar.openSnackBar('El nivel de relevancia del hotel se actualizó correctamente');
          } else {
            this.snackBar.openSnackBar('Debido a un error no pudo actualizarse el nivel de relevancia del hotel');
          }

          this.matDialogRef.close(true);
        });        

      }
    });    
  } 

  loadFormHotel(detallesHotel : HotelDto){
    this.detalleHotelForm = this.fb.group({
      smallPhoto: [detallesHotel.shortImageData],
      largePhoto: [detallesHotel.largeImageData],
      name: [detallesHotel.name],
      description: [detallesHotel.description]
    });
  } 

}
