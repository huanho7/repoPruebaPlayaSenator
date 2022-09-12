import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-hoteldetail',
  templateUrl: './hoteldetail.component.html',
  styleUrls: ['./hoteldetail.component.css']
})
export class HoteldetailComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
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
      }
    });    
  }  

}
