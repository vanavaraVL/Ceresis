import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Subject, Subscription } from 'rxjs';
import { AdmininstrationService } from '../../../Services/administration.service';
import { ToastsManager } from 'ng6-toastr';

@Component({
    selector: 'add-worksample-modal',
    templateUrl: 'add.worksample.component.html',
    styleUrls: ['./add.worksample.component.scss']
})
export class AddWorksampleComponent implements OnInit {

    createWorksampleForm: FormGroup;
    fileToUpload: string = "";
    fileNameToUpload: string = "";

    busy: Subscription;

    constructor(public dialogRef: MatDialogRef<AddWorksampleComponent>, private adminService: AdmininstrationService,
        private toastr: ToastsManager) {

    }

    ngOnInit() {
        this.createWorksampleForm = new FormGroup({
            name: new FormControl('', [Validators.required]),
            image: new FormControl('', [Validators.required]),
            description: new FormControl(''),
        });
    }

    public hasError = (controlName: string, errorName: string) => {
        return this.createWorksampleForm.controls[controlName].hasError(errorName);
    }

    addWorksample(createWorksampleValue: any) {
        if (this.createWorksampleForm.valid) {
            var name = createWorksampleValue.name;
            var fileName = this.fileNameToUpload;
            var fileData = this.fileToUpload;
            var description = createWorksampleValue.description;

            this.busy = this.adminService.createWorksample({
                description: description,
                fileData: fileData,
                fileName: fileName,
                name: name
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
