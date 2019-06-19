import { Component, OnInit, Inject  } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Subject, Subscription } from 'rxjs';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { WindowPlastic } from '../../../DTO/catalog.dto';

@Component({
    selector: 'edit-window-modal',
    templateUrl: 'edit.window.component.html',
    styleUrls: ['./edit.window.component.scss']
})
export class EditWindowComponent implements OnInit {

    editForm: FormGroup;
    fileToUpload: string = "";
    fileNameToUpload: string = "";
    hasSetup: string = "true";

    busy: Subscription;
    selectedWindow: WindowPlastic;

    constructor(public dialogRef: MatDialogRef<EditWindowComponent>, private adminService: AdmininstrationService,
        private toastr: ToastsManager,
        @Inject(MAT_DIALOG_DATA) public data: any) {

        this.selectedWindow = this.data.selectedWindow as WindowPlastic;
    }

    ngOnInit() {
        this.editForm = new FormGroup({
            name: new FormControl('', [Validators.required]),
            image: new FormControl(''),
            size: new FormControl('', [Validators.required]),
            feature: new FormControl('', [Validators.required]),
            price: new FormControl('', [Validators.required]),
        });

        this.editForm.controls["feature"].setValue(this.selectedWindow.feature);
        this.editForm.controls["image"].setValue(this.selectedWindow.imageUrl);
        this.editForm.controls["name"].setValue(this.selectedWindow.name);
        this.editForm.controls["size"].setValue(this.selectedWindow.size);
        this.editForm.controls["price"].setValue(this.selectedWindow.totalValue);

        this.hasSetup = "" + this.selectedWindow.hasSetup;
    }

    public hasError = (controlName: string, errorName: string) => {
        return this.editForm.controls[controlName].hasError(errorName);
    }

    editWindowForm(createForm: any) {
        if (this.editForm.valid) {
            var name = createForm.name;
            var fileName = this.fileNameToUpload;
            var fileData = this.fileToUpload;
            var feature = createForm.feature;
            var size = createForm.size;
            var price = +createForm.price;

            this.busy = this.adminService.editWindow({
                id: this.selectedWindow.id,
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

                this.toastr.success("Запись успешно обновлена");
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
