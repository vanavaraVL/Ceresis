import { Routes, Route } from "@angular/router";

import { RoutesName } from "./routes.name";
import { HomeComponent } from "./Home/home.component";
import { ContactsComponent } from "./Contacts/contacts.component";
import { GoszakazComponent } from "./GosZakaz/goszakaz.component";
import { ProductionComponent } from "./Production/production.component";
import { WorkComponent } from "./Work/work.component";
import { SplitComponent } from "./Production/Split/split.component";
import { WindowComponent } from "./Production/Windows/window.component";
import { PortfolioComponent } from "./Portfolio/portfolio.component";
import { HouseHoldComponent } from "./Production/HouseHold/house-hold.component";
import { CartComponent } from "./Cart/cart.component";
import { AdminHomeComponent } from "./Admin/General/admin.home.component";
import { ListWorksampleComponent } from "./Admin/Worksample/List/list.worksample.component";
import { ListWindowsComponent } from "./Admin/Window/List/list.window.component";
import { ListSplitComponent } from "./Admin/SplitSystem/List/list.split.component";
import { ListWorkpriceComponent } from "./Admin/Workprice/List/list.workprice.component";
import { ListLogotypesComponent } from "./Admin/LogoTypes/List/list.logotypes.component";

let adminRoutes: Routes = [
    { path: '', redirectTo: RoutesName.Admin.EDITWORKSAMPLE, pathMatch: 'full'},
    { path: RoutesName.Admin.EDITWORKSAMPLE, component: ListWorksampleComponent },
    { path: RoutesName.Admin.EDITWINDOW, component: ListWindowsComponent },
    { path: RoutesName.Admin.EDITSPLIT, component: ListSplitComponent },
    { path: RoutesName.Admin.EDITWORKPRICE, component: ListWorkpriceComponent },
    { path: RoutesName.Admin.EDITLOGOS, component: ListLogotypesComponent }
];

let appRoutes: Routes = [
    { path: "", redirectTo: `/${RoutesName.HOME}`, pathMatch: "full" },
    { path: RoutesName.HOME, component: HomeComponent },
    { path: RoutesName.CONTACTS, component: ContactsComponent },
    { path: RoutesName.GOSZAKAZ, component: GoszakazComponent },
    { path: RoutesName.PRODUCTION, component: ProductionComponent },
    { path: RoutesName.WORK, component: WorkComponent },
    { path: RoutesName.SPLIT, component: SplitComponent },
    { path: RoutesName.WINDOW, component: WindowComponent },
    { path: RoutesName.PORTFOLIO, component: PortfolioComponent },
    { path: RoutesName.HOUSEHOLD, component: HouseHoldComponent },
    { path: RoutesName.CART, component: CartComponent },
    { path: RoutesName.Admin.ADMIN, component: AdminHomeComponent, children: adminRoutes },
    { path: "**", redirectTo: RoutesName.HOME },
];

export default appRoutes;