import {Component} from '@angular/core';
import {TestClient, TestDto} from "../../apis/web-api-client";


@Component({
  selector: 'app-tests',
  templateUrl: './tests.component.html',
  styleUrls: ['./tests.component.css']
})
export class TestsComponent {

  constructor(private testClient: TestClient) {

  }
}
