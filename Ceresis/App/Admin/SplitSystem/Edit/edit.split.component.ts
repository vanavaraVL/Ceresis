import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Subject, Subscription } from 'rxjs';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';
import { SplitHouse } from '../../../DTO/split.dto';

@Component({
    selector: 'edit-split-modal',
    templateUrl: 'edit.split.component.html',
    styleUrls: ['./edit.split.component.scss']
})
export class EditSplitHouseComponent implements OnInit {

    editForm: FormGroup;
    fileToUpload: string = "";
    fileNameToUpload: string = "";

    busy: Subscription;
    selectedSplit: SplitHouse;

    constructor(public dialogRef: MatDialogRef<EditSplitHouseComponent>, private adminService: AdmininstrationService,
        private toastr: ToastsManager,
        @Inject(MAT_DIALOG_DATA) public data: any) {

        this.selectedSplit = this.data.selectedSplit as SplitHouse;
    }

    ngOnInit() {
        this.editForm = new FormGroup({
            energoEfficienty: new FormControl('', [Validators.required]),
            image: new FormControl(''),
            model: new FormControl('', [Validators.required]),
            noise: new FormControl('', [Validators.required]),
            power: new FormControl('', [Validators.required]),
            powerRealty: new FormControl('', [Validators.required]),
            price: new FormControl('', [Validators.required]),
            sizeExternal: new FormControl('', [Validators.required]),
            sizeInternal: new FormControl('', [Validators.required]),
        });

        this.editForm.controls["energoEfficienty"].setValue(this.selectedSplit.energoEfficienty);
        this.editForm.controls["image"].setValue(this.selectedSplit.imageUrl);
        this.editForm.controls["model"].setValue(this.selectedSplit.model);
        this.editForm.controls["noise"].setValue(this.selectedSplit.noise);
        this.editForm.controls["power"].setValue(this.selectedSplit.power);
        this.editForm.controls["powerRealty"].setValue(this.selectedSplit.powerRealty);
        this.editForm.controls["price"].setValue(this.selectedSplit.price);
        this.editForm.controls["sizeExternal"].setValue(this.selectedSplit.sizeExternal);
        this.editForm.controls["sizeInternal"].setValue(this.selectedSplit.sizeInternal);
    }

    public hasError = (controlName: string, errorName: string) => {
        return this.editForm.controls[controlName].hasError(errorName);
    }

    editSplit(createForm: any) {
        if (this.editForm.valid) {
            var editSplit = createForm as SplitHouse;
            var fileName = this.fileNameToUpload;
            var fileData = this.fileToUpload;

            this.busy = this.adminService.editSplitHouse({
                id: this.selectedSplit.id,
                fileData: fileData,
                fileName: fileName,
                energoEfficienty: editSplit.energoEfficienty,
                model: editSplit.model,
                noise: createForm.noise,
                power: editSplit.power,
                powerRealty: editSplit.powerRealty,
                price: +createForm.price,
                sizeExternal: editSplit.sizeExternal,
                sizeInternal: editSplit.sizeInternal
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
