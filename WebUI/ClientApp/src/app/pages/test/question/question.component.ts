import {ChangeDetectorRef, Component, OnInit, TemplateRef} from '@angular/core';
import {AnswerClient, AnswerDto, QuestionClient, QuestionDto} from "../../../../api-clients/web-api-client";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";


@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  isLoading: boolean = true;
  questions!: QuestionDto[];
  currentQuestion: QuestionDto = new QuestionDto();
  answers: AnswerDto[] = [new AnswerDto()];


  constructor(private questionClient: QuestionClient,
              private answerClient: AnswerClient,
              private changeDetector: ChangeDetectorRef,
              private modalService: NgbModal
  ) {
  }


  ngOnInit() {
    this.loadData()
  }

  loadData() {
    this.isLoading = true;
    this.questionClient.getAll().subscribe(data => {
      this.questions = data;
      this.isLoading = false;
    });
  }

  open(template: TemplateRef<any>) {
    return this.modalService.open(template, {size: "xl", centered: true, scrollable: true}).result;
  }

  addAnswerField() {
    if (this.answers.length < 3)
      this.answers.push(new AnswerDto());
  }

  save(modal: any) {
    debugger
    this.questionClient.add(this.currentQuestion).subscribe(x => {
      console.log("success")
    });
    modal.close("closed");
  }
}
