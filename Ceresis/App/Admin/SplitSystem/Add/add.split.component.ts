import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Subject, Subscription } from 'rxjs';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { SplitHouse } from '../../../DTO/split.dto';

@Component({
    selector: 'add-split-modal',
    templateUrl: 'add.split.component.html',
    styleUrls: ['./add.split.component.scss']
})
export class AddSplitComponent implements OnInit {

    createWindowForm: FormGroup;
    fileToUpload: string = "";
    fileNameToUpload: string = "";
    hasSetup: string = "true";

    busy: Subscription;

    constructor(public dialogRef: MatDialogRef<AddSplitComponent>, private adminService: AdmininstrationService,
        private toastr: ToastsManager) {

    }

    ngOnInit() {
        this.createWindowForm = new FormGroup({
            energoEfficienty: new FormControl('', [Validators.required]),
            image: new FormControl('', [Validators.required]),
            model: new FormControl('', [Validators.required]),
            noise: new FormControl('', [Validators.required]),
            power: new FormControl('', [Validators.required]),
            powerRealty: new FormControl('', [Validators.required]),
            price: new FormControl('', [Validators.required]),
            sizeExternal: new FormControl('', [Validators.required]),
            sizeInternal: new FormControl('', [Validators.required]),
        });
    }

    public hasError = (controlName: string, errorName: string) => {
        return this.createWindowForm.controls[controlName].hasError(errorName);
    }

    addSplitHouse(createForm: any) {
        if (this.createWindowForm.valid) {
            var fileName = this.fileNameToUpload;
            var fileData = this.fileToUpload;

            var addSplit = createForm as SplitHouse;

            this.busy = this.adminService.createSplitHouse({
                fileData: fileData,
                fileName: fileName,
                energoEfficienty: addSplit.energoEfficienty,
                model: addSplit.model,
                noise: createForm.noise,
                power: addSplit.power,
                powerRealty: addSplit.powerRealty,
                price: +createForm.price,
                sizeExternal: addSplit.sizeExternal,
                sizeInternal: addSplit.sizeInternal
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

    handleFileInput(files: FileList) {
        const self = this;
        const file = files.item(0);

        self.fileNameToUpload = file.name;

        const reader = new FileReader();
        reader.readAsDataURL(file);

        reader.onload = function () {
            self.fileToUpload = reader.result;
        }
    }

    onCancel() {
        this.dialogRef.close(false);
    }
}
