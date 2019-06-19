import { Component } from '@angular/core';
import { FeedbackService } from '../Services/feedback.service';
import { FeedBackRequest, FeedBackResponse, FeedBackDTO } from '../DTO/feedback.dto';
import { Subscription } from 'rxjs/Subscription';
import { ToastsManager } from 'ng6-toastr';

@Component({
    selector: 'app-feedback',
    templateUrl: './feedback.component.html',
    styleUrls: ['./feedback.component.scss']
})
export class FeedbackComponent {

    private feedback: FeedBackRequest = new FeedBackRequest();
    private busy: Subscription;

    constructor(private feedbackService: FeedbackService, private toastr: ToastsManager) {

    }

    sendMessage() {
        this.busy = this.feedbackService.sendQuestion(this.feedback).subscribe((response) => {

            if (response.isError) {
                this.toastr.error(response.message);
                return;
            }

            this.toastr.success("Ваше обращение успешно отправлено");
            this.toastr.success("Мы свяжемся с Вами в ближайшее время");
        });
    }
}