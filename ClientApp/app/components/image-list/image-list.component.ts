import { Component, OnInit } from '@angular/core';

/**
 * @title Radios with ngModel
 */

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.scss']
})
export class ImageListComponent implements OnInit {

    tiles = [
      { text: 'One', image: 'https://www.w3schools.com/images/colorpicker.gif'},
      { text: 'Two', image: 'https://www.w3schools.com/images/colorpicker.gif'},
      { text: 'Three', image: 'https://www.w3schools.com/images/colorpicker.gif'},
      { text: 'Four', image: 'https://www.w3schools.com/images/colorpicker.gif'},
      { text: 'Four', image: 'https://www.w3schools.com/images/colorpicker.gif' },
      ];
  constructor() { }

  ngOnInit() {
  }

}
