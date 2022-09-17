import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subscription } from 'rxjs';
import { HotelDto } from 'src/app/entities/HotelDto';
import { HotelService } from 'src/app/services/hotelservice';
import { ConfirmationModalComponent } from 'src/app/shared-components/confirmation-modal/confirmation-modal.component';
import { SnackbarService } from 'src/app/shared/Snackbar.service';
import { ChangeRelevanceRequestViewModel } from 'src/app/ViewModels/ChangeRelevanceRequestViewModel';
import { HotelConstants } from '../../shared/Constants/HotelConstants';

@Component({
  selector: 'app-hoteldetail',
  templateUrl: './hoteldetail.component.html',
  styleUrls: ['./hoteldetail.component.css']
})
export class HoteldetailComponent implements OnInit {

  // Inicialización de variables
  public imageHotelNotAvaible = HotelConstants.IMAGE_HOTEL_NOT_AVAIBLE;
  public hotelDetailDto!: HotelDto;
  public detalleHotelForm!: FormGroup;  
  private subscriptions: Subscription[]  = [];

  constructor(private spinner: NgxSpinnerService,
              private dataService: HotelService,
              private snackBar: SnackbarService,
              private fb: FormBuilder,
              @Inject(MAT_DIALOG_DATA) public data: any,
              private matDialogRef: MatDialogRef<HoteldetailComponent>,
              private matDialog: MatDialog
              ) {

                this.detalleHotelForm = this.fb.group({
                  smallPhoto: [''],
                  largePhoto: [''],
                  name: [''],
                  description: ['']
                });

               }

  ngOnInit(): void {
    this.initFormHotel();
  }

  initFormHotel(){
    // Se recogen los datos
    this.spinner.show();

    if(!(this.data && this.data.id)){
      this.snackBar.openSnackBar('No se ha facilitado id de hotel para consultar');
    }

    this.dataService.getHotelById(this.data.id).subscribe(x => {

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


    const data = {
      confirmationText : "¿Desea realmente cambiar la relevancia del hotel seleccionado?",
      confirmationButtonText : "Sí",
      cancelButtonText : "No"
    };

    const dialog = this.matDialog.open(ConfirmationModalComponent, {
      panelClass: 'custom-dialog-container',
      width: '30%',
      height: '20%',
      data,
      autoFocus : false
    });

    const sub: Subscription = dialog.afterClosed().subscribe((res: boolean) => {
      if (res == true) {
        let newCRReq : ChangeRelevanceRequestViewModel = new ChangeRelevanceRequestViewModel();

        newCRReq.IdHotel = this.hotelDetailDto.id;

        if(this.hotelDetailDto.idRelevance == HotelConstants.RELEVANCE_ID_HIGH)
        {
          newCRReq.IdNewRelevanceStatus = HotelConstants.RELEVANCE_ID_LOW;
        }
        else{
          newCRReq.IdNewRelevanceStatus = HotelConstants.RELEVANCE_ID_HIGH;
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
      else{

      }
    });

    this.subscriptions.push(sub);
   
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
