import { Component } from "@angular/core";
import { FeedBackRequest, FeedBackResponse, FeedBackDTO } from '../DTO/feedback.dto';
import { FeedbackService } from '../Services/feedback.service';
import { ToastsManager } from 'ng6-toastr';
import { Subscription } from 'rxjs/Subscription';

@Component({
    templateUrl: './contacts.component.html',
    styleUrls: ['./contacts.component.scss']
})
export class ContactsComponent {

    private feedback: FeedBackRequest = new FeedBackRequest();
    private busy: Subscription;

    constructor(private feedbackService: FeedbackService, private toastr: ToastsManager) { }

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