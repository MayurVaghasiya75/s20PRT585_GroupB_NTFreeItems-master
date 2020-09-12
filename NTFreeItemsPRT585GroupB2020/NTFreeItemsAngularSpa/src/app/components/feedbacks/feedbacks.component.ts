import { Component, OnInit, Renderer2, ElementRef} from '@angular/core';

@Component({
  selector: 'app-feedbacks',
  templateUrl: './feedbacks.component.html',
  styleUrls: ['./feedbacks.component.scss']
})
export class FeedbacksComponent implements OnInit {
  feedbackFormOpened = false;

  constructor(
    private renderer: Renderer2,
    private el: ElementRef
  ) { }

  ngOnInit(): void {
  }

  formOpened(): void {
    const element = document.getElementsByClassName('footer');
    this.el = this.el.nativeElement;
   // this.renderer.setStyle(this.el, 'position', 'relative');
  }

  userFeedbackAction(): void {
    this.feedbackFormOpened = !this.feedbackFormOpened;
  }

}
