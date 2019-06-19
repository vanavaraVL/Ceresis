/*
    ---------------------- REF: Components -----------------------
*/
import { AppComponent } from "./App/app.component";
import { RequestInterceptor } from "./Services/globalHandlerRequest.services";
import { AppHeaderComponent } from "./App/AppHeader/app.header.component";
import { AppFooterComponent } from "./App/AppFooter/app.footer.component";
import { HomeComponent } from "./Home/home.component";
import { ContactsComponent } from "./Contacts/contacts.component";
import { GoszakazComponent } from "./GosZakaz/goszakaz.component";
import { ProductionComponent } from "./Production/production.component";
import { WorkComponent } from "./Work/work.component";
import { ProductSelectComponent } from "./Production/ProductSelect/product.select.component";
import { SplitComponent } from "./Production/Split/split.component";
import { WindowComponent } from "./Production/Windows/window.component";
import { AboutComponent } from "./About/about.component";
import { FeedbackComponent } from "./Feedback/feedback.component";
import { PortfolioComponent } from "./Portfolio/portfolio.component";
import { HouseHoldComponent } from "./Production/HouseHold/house-hold.component";
import { LoginComponent } from "./Admin/Login/login.component";
import { CartComponent } from "./Cart/cart.component";
import { AdminHomeComponent } from "./Admin/General/admin.home.component";
import { ListWorksampleComponent } from "./Admin/Worksample/List/list.worksample.component";
import { AddWorksampleComponent } from "./Admin/Worksample/Add/add.worksample.component";
import { AddWindowComponent } from "./Admin/Window/Add/add.window.component";
import { ListWindowsComponent } from "./Admin/Window/List/list.window.component";
import { EditWindowComponent } from "./Admin/Window/Edit/edit.window.component";
import { AddSplitComponent } from "./Admin/SplitSystem/Add/add.split.component";
import { EditSplitHouseComponent } from "./Admin/SplitSystem/Edit/edit.split.component";
import { ListSplitComponent } from "./Admin/SplitSystem/List/list.split.component";
import { AddWorkpriceComponent } from "./Admin/Workprice/Add/add.workprice.component";
import { EditWorkpriceComponent } from "./Admin/Workprice/Edit/edit.workprice.component";
import { ListWorkpriceComponent } from "./Admin/Workprice/List/list.workprice.component";
import { AddLogosComponent } from "./Admin/LogoTypes/Add/add.logotypes.component";
import { ListLogotypesComponent } from "./Admin/LogoTypes/List/list.logotypes.component";

/*
    ---------------------- REF: Services - -----------------------
*/
import { ScriptLoaderService } from "./Services/script.loader.services";
import { FeedbackService } from "./Services/feedback.service";
import { AdmininstrationService } from "./Services/administration.service";
import { CustomerService } from "./Services/customer.service";
import { AuthService } from "./Services/auth.service";
import { WorksampleService } from "./Services/worksample.service";
import { CatalogService } from "./Services/catalog.service";

/*
    ---------------------- REF: Consts ---------------------------
*/
import routes from "./routes";

/*
    ---------------------- REF: Angular section ------------------
*/
import { enableProdMode } from '@angular/core';
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule  } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";
import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { BusyModule } from 'angular2-busy';
import { ToastModule } from 'ng6-toastr';
import { CookieService } from 'ngx-cookie-service';
import { NgxMaskModule } from 'ngx-mask'
import { FlexLayoutModule } from "@angular/flex-layout";

import {
    MatTabsModule, MatSidenavModule, MatToolbarModule, MatIconModule, MatButtonModule, MatListModule, MatMenuModule,
    MatTableModule, MatSortModule, MatFormFieldModule, MatInputModule, MatPaginatorModule, MatProgressBarModule, MatCheckboxModule,
    MatProgressSpinnerModule, MatCardModule, MatSelectModule, MatExpansionModule, MatDatepickerModule, MatNativeDateModule,
    MatDialogModule
} from '@angular/material';

@NgModule({
    declarations: [
        AppComponent,
        AppHeaderComponent,
        AppFooterComponent,
        HomeComponent,
        ContactsComponent,
        GoszakazComponent,
        ProductionComponent,
        WorkComponent,
        ProductSelectComponent,
        SplitComponent,
        AdminHomeComponent,
        WindowComponent,
        AboutComponent,
        FeedbackComponent,
        PortfolioComponent,
        HouseHoldComponent,
        LoginComponent,
        CartComponent,
        ListWorksampleComponent,
        AddWorksampleComponent,
        AddWindowComponent,
        AddSplitComponent,
        ListWindowsComponent,
        ListSplitComponent,
        EditWindowComponent,
        EditSplitHouseComponent,
        AddWorkpriceComponent,
        EditWorkpriceComponent,
        ListWorkpriceComponent,
        ListLogotypesComponent,
        AddLogosComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule ,
        HttpClientModule,
        BrowserAnimationsModule,
        RouterModule.forRoot(routes),
        BusyModule,
        ToastModule.forRoot(),
        NgxMaskModule.forRoot(),
        MatDialogModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatExpansionModule,
        MatSelectModule,
        MatCardModule,
        MatProgressSpinnerModule,
        MatCheckboxModule,
        MatProgressBarModule,
        MatPaginatorModule,
        MatFormFieldModule,
        MatInputModule,
        MatSortModule,
        MatTableModule,
        MatMenuModule,
        MatListModule,
        MatButtonModule,
        MatIconModule,
        MatToolbarModule,
        MatTabsModule,
        MatSidenavModule,
        FlexLayoutModule
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true },
        ScriptLoaderService,
        FeedbackService,
        AdmininstrationService,
        CookieService,
        CustomerService,
        AuthService,
        WorksampleService,
        CatalogService
    ],
    entryComponents: [AddWorksampleComponent, AddWindowComponent, EditWindowComponent,
        AddSplitComponent, EditSplitHouseComponent, AddWorkpriceComponent,
        EditWorkpriceComponent, AddLogosComponent],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule {
}

if (window.settings.ProductionMode === true) {
    enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule).catch(err => console.log(err));