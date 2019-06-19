import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Subject, Subscription } from 'rxjs';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';

@Component({
    selector: 'add-logos-modal',
    templateUrl: 'add.logotypes.component.html',
    styleUrls: ['./add.logotypes.component.scss']
})
export class AddLogosComponent implements OnInit {

    createLogoForm: FormGroup;
    fileToUpload: string = "";
    fileNameToUpload: string = "";
    logoType: string = "10";

    busy: Subscription;

    constructor(public dialogRef: MatDialogRef<AddLogosComponent>, private adminService: AdmininstrationService,
        private toastr: ToastsManager) {

    }

    ngOnInit() {
        this.createLogoForm = new FormGroup({
            name: new FormControl('', [Validators.required]),
            image: new FormControl('', [Validators.required]),
            description: new FormControl(''),
        });
    }

    public hasError = (controlName: string, errorName: string) => {
        return this.createLogoForm.controls[controlName].hasError(errorName);
    }

    addLogos(createLogos: any) {
        if (this.createLogoForm.valid) {
            var name = createLogos.name;
            var fileName = this.fileNameToUpload;
            var fileData = this.fileToUpload;
            var description = createLogos.description;

            this.busy = this.adminService.createLogo({
                description: description,
                fileData: fileData,
                fileName: fileName,
                name: name,
                typeValue: +this.logoType
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
