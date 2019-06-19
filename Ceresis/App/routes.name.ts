
export enum RoutesEnum {
    Home = 10,
    Contacts = 20,
    Goszakaz = 30,
    Production = 40,
    Work = 50,
    Split = 60,
    Window = 70,
    Portfolio = 80,
    HouseHold = 90,
    Cart = 100, 
    Admin = 110,
    AdminEditWorkplace = 120,
    AdminEditCatalog = 130,
    AdminEditWindow = 140, 
    AdminEditSplit = 150,
    AdminEditWorkprice = 160,
    AdminEditLogos = 170
}


export module RoutesName {
    export const CONTACTS: string = "contacts";
    export const HOME: string = "home";
    export const GOSZAKAZ: string = "goszakaz";
    export const PRODUCTION: string = "production";
    export const WORK: string = "work";
    export const SPLIT: string = "split";
    export const WINDOW: string = "window";
    export const PORTFOLIO: string = "portfolio";
    export const HOUSEHOLD: string = "household";
    export const CART: string = "cart";

    export module Admin {
        export const ADMIN: string = "admin";
        export const EDITWORKSAMPLE: string = "editworksample";
        export const EDITCATALOG: string = "editcatalog";
        export const EDITWINDOW: string = "editwindow";
        export const EDITSPLIT: string = "editsplit";
        export const EDITWORKPRICE: string = "editworkprice";
        export const EDITLOGOS: string = "editlogos";
    }
}
