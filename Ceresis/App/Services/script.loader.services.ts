import { Injectable } from "@angular/core";

declare var document: any;

@Injectable()
export class ScriptLoaderService {

    private scripts: any = {};

    constructor() {
    }

    load(...scripts: string[]) {
        var promises: any[] = [];
        scripts.forEach((script) => promises.push(this.loadScript(script)));
        return Promise.all(promises);
    }

    loadScript(name: string) {
        return new Promise((resolve, reject) => {

            var hashName = name.split("").reduce((a, b) => { a = ((a << 5) - a) + b.charCodeAt(0); return a & a }, 0).toString();
            
            //resolve if already loaded
            if (this.scripts[hashName] && this.scripts[hashName].loaded) {
                resolve({ script: name, loaded: true, status: 'Already Loaded' });
            }
            else {
            
                this.scripts[hashName] = {};

                //load script
                let script = document.createElement('script');
                script.type = 'text/javascript';
                script.src = name;

                if (script.readyState) {  //IE
                    script.onreadystatechange = () => {
                        if (script.readyState === "loaded" || script.readyState === "complete") {
                            script.onreadystatechange = null;
                            this.scripts[hashName].loaded = true;
                            resolve({ script: name, loaded: true, status: 'Loaded' });
                        }
                    };
                } else {  //Others
                    script.onload = () => {
                        this.scripts[hashName].loaded = true;
                        resolve({ script: name, loaded: true, status: 'Loaded' });
                    };
                }
                script.onerror = (error: any) => resolve({ script: name, loaded: false, status: 'Loaded' });
                document.getElementsByTagName('head')[0].appendChild(script);
            }
        });
    }

}