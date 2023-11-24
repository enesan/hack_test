import {NgModule} from "@angular/core";
import {TestComponent} from "./test.component";
import {QuestionComponent} from "./question/question.component";
import {AngularEditorModule} from '@kolkov/angular-editor'
import {EditorModule} from '@tinymce/tinymce-angular'
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import {NgForOf} from "@angular/common";


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
      {path: 'test', component: TestComponent}
    ]),
    NgForOf
  ]
})

export class TestModule {}
