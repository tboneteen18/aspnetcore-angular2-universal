import { Component, OnInit } from '@angular/core';

/**
 * @title Radios with ngModel
 */
@Component({
  selector: 'app-my-new-component',
  templateUrl: './my-new-component.component.html',
  styleUrls: ['./my-new-component.component.scss'],
})

export class MyNewComponentComponent implements OnInit {
  favoriteSeason: string;

  seasons = [
    'Winter',
    'Spring',
    'Summer',
    'Autumn',
  ];
  constructor() { }

  ngOnInit() {
  }
}
