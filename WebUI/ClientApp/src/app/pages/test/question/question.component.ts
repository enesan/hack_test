import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {QuestionClient, QuestionDto} from "../../../../api-clients/web-api-client";

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  isLoading: boolean = true;
  questions!: QuestionDto[];

  constructor(private questionClient: QuestionClient,
              private changeDetector: ChangeDetectorRef) {
  }


  ngOnInit() {
  }

  loadData() {
    this.isLoading = true;

  }

}
