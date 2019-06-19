import { Injectable } from '@angular/core';
import { UserInfo } from '../DTO/user.dto';

@Injectable()
export class AuthService {
    constructor() {
    }

    public info(): UserInfo {
        const currentUser = localStorage.getItem('currentUser');
        const result = new UserInfo();

        try {
            if (currentUser != null) {
                const jsonClass = JSON.parse(currentUser);
                result.token = jsonClass.token;
                result.id = jsonClass.id;
                result.email = jsonClass.email;
                result.roles = jsonClass.roles;
            }
        } catch (e) {
            console.log('ERROR: Get info user ', e);
        }

        return result;
    }

    public getId(): number {
        return this.info().id;
    }

    public isAdmin(): boolean {
        return (this.info().roles || []).filter(r => r.toLocaleLowerCase() === "admin").length > 0;
    }
    
    public getEmail(): string {
        return this.info().email;
    }
}