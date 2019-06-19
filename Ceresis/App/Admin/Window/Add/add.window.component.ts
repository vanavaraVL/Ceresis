import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Subject, Subscription } from 'rxjs';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { WindowPlastic } from '../../../DTO/catalog.dto';

@Component({
    selector: 'add-window-modal',
    templateUrl: 'add.window.component.html',
    styleUrls: ['./add.window.component.scss']
})
export class AddWindowComponent implements OnInit {

    createWindowForm: FormGroup;
    fileToUpload: string = "";
    fileNameToUpload: string = "";
    hasSetup: string = "true";

    busy: Subscription;
    selectedWindow: WindowPlastic;

    constructor(public dialogRef: MatDialogRef<AddWindowComponent>, private adminService: AdmininstrationService,
        private toastr: ToastsManager) {

    }

    ngOnInit() {
        this.createWindowForm = new FormGroup({
            name: new FormControl('', [Validators.required]),
            image: new FormControl('', [Validators.required]),
            size: new FormControl('', [Validators.required]),
            feature: new FormControl('', [Validators.required]),
            price: new FormControl('', [Validators.required]),
        });
    }

    public hasError = (controlName: string, errorName: string) => {
        return this.createWindowForm.controls[controlName].hasError(errorName);
    }

    addWindow(createForm: any) {
        if (this.createWindowForm.valid) {
            var name = createForm.name;
            var fileName = this.fileNameToUpload;
            var fileData = this.fileToUpload;
            var feature = createForm.feature;
            var size = createForm.size;
            var price = +createForm.price;

            this.busy = this.adminService.createWindow({
                fileData: fileData,
                fileName: fileName,
                name: name,
                feature: feature,
                size: size,
                total: price,
                hasSetup: this.hasSetup == "true"
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
