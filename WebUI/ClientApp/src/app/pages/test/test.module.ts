import {NgModule} from "@angular/core";
import {TestComponent} from "./test.component";
import {QuestionComponent} from "./question/question.component";
import {AngularEditorModule} from '@kolkov/angular-editor'
import {EditorModule} from '@tinymce/tinymce-angular'
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import {CommonModule, NgForOf} from "@angular/common";
import {QuestionClient} from "../../../api-clients/web-api-client";
import {HttpClientModule} from "@angular/common/http";


@NgModule({
  declarations: [
    TestComponent,
    QuestionComponent
  ],
    imports: [
        AngularEditorModule,
        EditorModule,
        FormsModule,
        RouterModule.forRoot([
          {path:'', component: QuestionComponent}
        ]),
        NgForOf,
        CommonModule,
      HttpClientModule,

    ]
})

export class TestModule {}
