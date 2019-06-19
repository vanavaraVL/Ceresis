import { ISettings } from './i.setting';

export class Settings implements ISettings {
    BaseUrlAPI: string = "http://kit-service56.ru/";
    ProductionMode: boolean = true;

    constructor() {
        window.settings = this;
    }
}

new Settings();