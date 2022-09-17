import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SnackbarService } from 'src/app/shared/Snackbar.service';

@Component({
  selector: 'app-confirmation-modal',
  templateUrl: './confirmation-modal.component.html',
  styleUrls: ['./confirmation-modal.component.css']
})
export class ConfirmationModalComponent implements OnInit {

  public confirmationText : string = '';
  public confirmationButtonText : string = '';
  public cancelButtonText : string = '';

  constructor(
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private matDialogRef: MatDialogRef<ConfirmationModalComponent>,
    private snackBar: SnackbarService,
    ) { }

  ngOnInit(): void {
    // Inicializar textos
    if(!(this.data && this.data.confirmationText && this.data.confirmationButtonText && this.data.cancelButtonText)){
      this.snackBar.openSnackBar('Ha ocurrido un error en el componente a mostrar');
    }else{
      this.confirmationText = this.data.confirmationText;
      this.confirmationButtonText = this.data.confirmationButtonText;
      this.cancelButtonText = this.data.cancelButtonText;
    }
  }

  buttonConfirmationClick(){
    // Evento para el caso de confirmar
    this.matDialogRef.close(true);
  }

  buttonCancelClick(){
    // Evento para el caso de cancelar
    this.matDialogRef.close(false);
  }

}
