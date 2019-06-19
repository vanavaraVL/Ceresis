import { ISettings } from './i.setting';

export class Settings implements ISettings {
    BaseUrlAPI: string = "http://localhost:3322/";
    ProductionMode: boolean = false;

    constructor() {
        window.settings = this;
    }
}

new Settings();