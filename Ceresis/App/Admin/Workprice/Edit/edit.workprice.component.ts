import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, fadeInContent } from '@angular/material';
import { Subject, Subscription } from 'rxjs';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { WorkPrice } from '../../../DTO/workprice.dto';

@Component({
    selector: 'edit-workprice-modal',
    templateUrl: 'edit.workprice.component.html',
    styleUrls: ['./edit.workprice.component.scss']
})
export class EditWorkpriceComponent implements OnInit {

    editForm: FormGroup;
    priceContact: string = "false";
    priceExact: string = "false";
    unity: string = "шт";

    busy: Subscription;
    selectedWorkprice: WorkPrice;

    constructor(public dialogRef: MatDialogRef<EditWorkpriceComponent>, private adminService: AdmininstrationService,
        private toastr: ToastsManager,
        @Inject(MAT_DIALOG_DATA) public data: any) {

        this.selectedWorkprice = this.data.selectedWorkprice as WorkPrice;
    }

    ngOnInit() {
        this.editForm = new FormGroup({
            name: new FormControl('', [Validators.required]),
            price: new FormControl('', [Validators.required]),
        });

        this.editForm.controls["name"].setValue(this.selectedWorkprice.name);
        this.editForm.controls["price"].setValue(this.selectedWorkprice.price);

        if (this.selectedWorkprice.contactPrice) {
            this.priceContact = "true";
        }
        else {
            this.priceContact = "false";
        }

        if (this.selectedWorkprice.exactPrice) {
            this.priceExact = "true";
        }
        else {
            this.priceExact = "false";
        }

        switch (this.selectedWorkprice.unity) {
            case "шт":
                this.unity = "шт";
                break;
            case "м":
                this.unity = "м";
                break;
            case "ед":
                this.unity = "ед";
                break;
            case "100 гр":
                this.unity = "100 гр";
                break;
            default:
                this.unity = "шт"
                break;
        }
    }

    public hasError = (controlName: string, errorName: string) => {

        return this.editForm.controls[controlName].hasError(errorName);
    }


    changePriceContact(event: any) {
        if (event.value == "true") {
            this.editForm.controls.price.disable();
        }
        else {
            this.editForm.controls.price.enable();
        }
    }


    editWorkprice(createForm: any) {
        if (this.editForm.valid) {
            var editWorkprice = createForm as WorkPrice;

            this.busy = this.adminService.editWorkprice({
                id: this.selectedWorkprice.id,
                contactPrice: this.priceContact == "true",
                exactPrice: this.priceExact == "true",
                name: editWorkprice.name,
                price: editWorkprice.price,
                unity: this.unity
            }).subscribe(response => {

                if (response.isError) {
                    this.toastr.error(response.message);
                    return;
                }

                this.toastr.success("Запись успешно обновлена");
                this.dialogRef.close(true);
            });
        }
    }

    onCancel() {
        this.dialogRef.close(false);
    }
}
