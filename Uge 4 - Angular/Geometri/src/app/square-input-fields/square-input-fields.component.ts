import { Rectangle, Quadrant } from './../geometry/geometry.component'; // Get the Rectangle and Quadrant classes from the geometry.component.ts file
import { FormsModule } from '@angular/forms'; // Import the FormsModule to use ngModel
import { Component } from '@angular/core'; // *


@Component({
  selector: 'app-square-input-fields',
  standalone: true,
  imports: [SquareInputFieldsComponent,FormsModule], // Import the SquareInputFieldsComponent and FormsModule
  templateUrl: './square-input-fields.component.html',
  styleUrl: './square-input-fields.component.css'
})

export class SquareInputFieldsComponent {
  squareHeight: number = 0; // The height of the square - Input field
  squareWidth: number = 0; // The width of the square - Input field
  resultSquareArea : number = 0; // The area of the square - Output field
  resultSquareCircumference : number = 0; // The circumference of the square - Output field


  whenClicked(Height: number, Width: number) {

    if(Height != Width) {
      let rectangle = new Rectangle(Height, Width); // Create a new instance of Rectangle class
      this.resultSquareArea = rectangle.CalculateArea(); // Call the CalculateArea method of the Rectangle class. This will return the area of the rectangle.
      this.resultSquareCircumference = rectangle.CalculateCircumference(); // Call the CalculateCircumference method of the Rectangle class. This will return the circumference of the rectangle.
      rectangle.Calculate();  // Call the Calculate method of the Rectangle class - This will print the area and circumference of the rectangle in the console.
    }
    else if(Height == Width) {
      let quadrant = new Quadrant(Height, Width);
      this.resultSquareArea = quadrant.CalculateArea();
      this.resultSquareCircumference = quadrant.CalculateCircumference();
    }
  }
}
