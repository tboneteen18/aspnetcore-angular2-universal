import { Component, OnInit } from '@angular/core';
import {DataSource} from '@angular/cdk/collections';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { CurrencyPipe } from '@angular/common';
import { IService } from '../../models/Service';
import { ServiceService } from '../../shared/service.service';

@Component({
  selector: 'app-services',
 
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss']
})
export class ServicesComponent implements OnInit {

  services: IService[];
  selectedService: IService;
  displayedColumns = ['Name', 'Description', 'Price'];
  dataSource = new ExampleDataSource();

   // Use "constructor"s only for dependency injection
    constructor(private serviceService: ServiceService) { }

  ngOnInit() {
    this.serviceService.getServices().subscribe(result => {
        console.log('Get service result: ', result);
        console.log('TransferHttp [GET] /api/services/allresult', result);
        this.services = result as IService[];
    });
  }

  onSelect(service: IService): void {
        this.selectedService = service;
    }

}
    
    const data: IService[] = this.services;

    /**
     * Data source to provide what data should be rendered in the table. The observable provided
     * in connect should emit exactly the data that should be rendered by the table. If the data is
     * altered, the observable should emit that new set of data on the stream. In our case here,
     * we return a stream that contains only one set of data that doesn't change.
     */
    export class ExampleDataSource extends DataSource<any> {
      /** Connect function called by the table to retrieve one stream containing the data to render. */
      connect(): Observable<IService[]> {
    return Observable.of(data);
  }

      disconnect() {}
    }
