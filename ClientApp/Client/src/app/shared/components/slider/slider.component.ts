import { Component, Input, OnInit } from '@angular/core';
import { Movies } from '../../models/movies';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.scss']
})
export class SliderComponent implements OnInit {
  @Input() public sliderConfig; 
  @Input() public movies : Movies; 
  @Input() public title: string;

  constructor() { }

  ngOnInit(): void {
  }

}
