import { Component } from '@angular/core';

@Component({
  selector: 'app-geometry',
  standalone: true,
  imports: [],
  templateUrl: './geometry.component.html',
  styleUrl: './geometry.component.css'
})

export class GeometryComponent {

}


abstract class Square {
  height: number = 0;
  width : number = 0;
  constructor(height: number, width: number) {
    this.height = height;
    this.width = width;
}


  CalculateArea() {
      let area: number = Number(this.height) * Number(this.width);
      return area;
  }

  CalculateCircumference() {
    let circumference: number = Number(this.height) + Number(this.width)
    circumference = circumference * 2;
    return circumference;
  }
}

export class Rectangle extends Square{
  Calculate() {
      console.log(this.CalculateArea());
      console.log(this.CalculateCircumference());
  }
}

export class Quadrant extends Square{
  Calculate() {
    console.log(this.CalculateArea());
    console.log(this.CalculateCircumference());
  }
}
