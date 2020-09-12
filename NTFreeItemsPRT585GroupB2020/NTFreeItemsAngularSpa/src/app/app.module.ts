import { HttpClientModule } from '@angular/common/http';
import { NgModule} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { BooksComponent } from './components/books/books.component';
import { ContactComponent } from './components/contact/contact.component';
import { FeedbacksComponent } from './components/feedbacks/feedbacks.component';
import { FooterComponent } from './components/footer/footer.component';
import { ForumComponent } from './components/forum/forum.component';
import { GuidelinesComponent } from './components/guidelines/guidelines.component';
import { HomeComponent } from './components/home/home.component';
import { JobsComponent } from './components/jobs/jobs.component';
import { MaterialModule } from './material.module';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { WeatherDataComponent } from './components/weather/weather.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FooterComponent,
    WeatherDataComponent,
    BooksComponent,
    ForumComponent,
    GuidelinesComponent,
    JobsComponent,
    ContactComponent,
    BooksComponent,
    FeedbacksComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'weather', component: WeatherDataComponent },
      {path: 'forum', component: ForumComponent},
      {path: 'books', component: BooksComponent},
      {path: 'jobs', component: JobsComponent},
      {path: 'contact', component: ContactComponent},
      {path: 'guidelines', component: GuidelinesComponent},
      {path: 'feedback', component: FeedbacksComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
