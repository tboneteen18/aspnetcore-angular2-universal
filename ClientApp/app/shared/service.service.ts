import { Http, URLSearchParams } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { ORIGIN_URL } from './constants/baseurl.constants';
import { IService } from '../models/Service';
import { TransferHttp } from '../../modules/transfer-http/transfer-http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ServiceService {
    constructor(
        private transferHttp: TransferHttp, // Use only for GETS that you want re-used between Server render -> Client render
        private http: Http, // Use for everything else
        @Inject(ORIGIN_URL) private baseUrl: string) {

    }

    getServices(): Observable<IService[]> {
        // ** TransferHttp example / concept **
        //    - Here we make an Http call on the server, save the result on the window object and pass it down with the SSR,
        //      The Client then re-uses this Http result instead of hitting the server again!

        //  NOTE : transferHttp also automatically does .map(res => res.json()) for you, so no need for these calls
        return this.transferHttp.get(`${this.baseUrl}/api/Services`);
    }

    getService(service: IService): Observable<IService> {
        return this.transferHttp.get(`${this.baseUrl}/api/services/` + service.serviceId);
    }

    deleteService(service: IService): Observable<any> {
        return this.http.delete(`${this.baseUrl}/api/services/` + service.serviceId);
    }

    updateService(service: IService): Observable<any> {
        return this.http.put(`${this.baseUrl}/api/services/` + service.serviceId, service);
    }

    addService(newService: string): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/services`, { name: newService })
    }
}

