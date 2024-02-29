import { Component } from '@angular/core';
import { RomanCalculatorService } from './roman-calculator.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'roman-calculator';
  numeral1: string = '';
  numeral2: string = '';
  result: string = '';

  constructor(private romanCalculatorService: RomanCalculatorService) { }

  calculate(): void {
    this.result = this.romanCalculatorService.calculateSum(this.numeral1, this.numeral2);
  }
}