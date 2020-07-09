
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { NewVehicleFormComponent } from './new-vehicle-form/new-vehicle-form.component';
import { VehicleService } from './services/vehicle.service';
import { AppErrorHandler } from './app.error-handler';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import * as Sentry from "@sentry/browser";
import { VehicleComponent } from './vehicle/vehicle.component';
import { PaginationComponent } from './shared/pagination/pagination.component';

Sentry.init({
    dsn: "https://35456f6e39dc476385ca2663a2c9fb34@o412064.ingest.sentry.io/5288263",
    // TryCatch has to be configured to disable XMLHttpRequest wrapping, as we are going to handle
    // http module exceptions manually in Angular's ErrorHandler and we don't want it to capture the same error twice.
    // Please note that TryCatch configuration requires at least @sentry/browser v5.16.0.
    integrations: [new Sentry.Integrations.TryCatch({
        XMLHttpRequest: false,
    })],
});


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        NewVehicleFormComponent,
        VehicleComponent,
        PaginationComponent
    ],
    imports: [

        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        BrowserAnimationsModule,
        ToastrModule.forRoot(),
        RouterModule.forRoot([
            { path: '', component: VehicleComponent, pathMatch: 'full' },
            { path: 'vehicles/new', component: NewVehicleFormComponent },
            { path: 'vehicles/:id', component: NewVehicleFormComponent},
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
        ])
    ],
    providers: [
        VehicleService,
        {
            provide: ErrorHandler,
            useClass: AppErrorHandler
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}
