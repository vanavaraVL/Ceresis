import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Subject, Subscription } from 'rxjs';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { SplitHouse } from '../../../DTO/split.dto';

@Component({
    selector: 'add-workprice-modal',
    templateUrl: 'add.workprice.component.html',
    styleUrls: ['./add.workprice.component.scss']
})
export class AddWorkpriceComponent implements OnInit {

    createWindowForm: FormGroup;
    priceContact: string = "false";
    priceExact: string = "false";
    unity: string = "шт";

    busy: Subscription;

    constructor(public dialogRef: MatDialogRef<AddWorkpriceComponent>, private adminService: AdmininstrationService,
        private toastr: ToastsManager) {

    }

    ngOnInit() {
        this.createWindowForm = new FormGroup({
            name: new FormControl('', [Validators.required]),
            price: new FormControl('', [Validators.required]),
        });
    }

    public hasError = (controlName: string, errorName: string) => {

        return this.createWindowForm.controls[controlName].hasError(errorName);
    }

    changePriceContact(event: any) {
        if (event.value == "true") {
            this.createWindowForm.controls.price.disable();
        }
        else {
            this.createWindowForm.controls.price.enable();
        }
    }

    addWorkprice(createForm: any) {
        if (this.createWindowForm.valid) {
            var name = createForm.name;
            var price = +createForm.price;

            if (this.priceContact == "true")
                price = null;

            this.busy = this.adminService.addWorkprice({
                contactPrice: this.priceContact == "true",
                exactPrice: this.priceExact == "true",
                name: name,
                unity: this.unity,
                price: price
            }).subscribe(response => {

                if (response.isError) {
                    this.toastr.error(response.message);
                    return;
                }

                this.toastr.success("Запись успешно добавлена");
                this.dialogRef.close(true);
            });
        }
    }

    onCancel() {
        this.dialogRef.close(false);
    }
}