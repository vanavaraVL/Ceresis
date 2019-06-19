/// <reference path="../node_modules/@types/jquery/index.d.ts"/>

import { ISettings } from './Settings/i.setting';

declare global {
    interface Window {
        settings: ISettings;
    }
}