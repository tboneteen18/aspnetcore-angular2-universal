import { Component, OnInit } from '@angular/core';
import {DataSource} from '@angular/cdk/collections';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-services',
 
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss']
})
export class ServicesComponent implements OnInit {

  displayedColumns = ['name', 'description', 'price'];
  dataSource = new ExampleDataSource();
  constructor() { }

  ngOnInit() {
  }

}

    export interface Service {
      name: string;
      description: string;
      price: number;
    }

    const data: Service[] = [
      {name: 'Micro Blade', description: 'Hydrogen', price: 10.00},
      {name: 'Kids Cut', description: 'Helium', price: 10.00},
      {name: 'Eye Lash Extensions', description: 'Lithium', price: 10.00},
      {name: 'temp', description: 'Beryllium', price: 9.00},
      {name: 'temp', description: 'Boron', price: 10.81},
      {name: 'temp', description: 'Carbon', price: 12.01},
      {name: 'temp', description: 'Nitrogen', price: 14.00},
    ];

    /**
     * Data source to provide what data should be rendered in the table. The observable provided
     * in connect should emit exactly the data that should be rendered by the table. If the data is
     * altered, the observable should emit that new set of data on the stream. In our case here,
     * we return a stream that contains only one set of data that doesn't change.
     */
    export class ExampleDataSource extends DataSource<any> {
      /** Connect function called by the table to retrieve one stream containing the data to render. */
      connect(): Observable<Service[]> {
        return Observable.of(data);
      }

      disconnect() {}
    }
