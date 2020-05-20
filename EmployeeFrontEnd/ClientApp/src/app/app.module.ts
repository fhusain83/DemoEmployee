import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './Components/app.component';
import { HomeComponent } from './Components/home/home.component';
import { SortableColumnComponent } from './Components/sortable-column/sortable-column.component';
import { FetchDataComponent } from './Components/fetch-data/fetch-data.component';
import { LoaderService } from './services/loader.service';
import { EmployeeService } from './services/employee.service';

import { LoaderInterceptor } from './interceptors/loader-interceptor.service';
import { MyLoaderComponent } from './Components/my-loader/my-loader.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FetchDataComponent,
    MyLoaderComponent,
    SortableColumnComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch:'full'},
      { path: 'fetch-data', component: FetchDataComponent }
    ])
  ],
  providers: [LoaderService,EmployeeService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
