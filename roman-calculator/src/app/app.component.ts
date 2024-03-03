import { Component, OnDestroy } from '@angular/core';
import { RomanCalculatorService } from './roman-calculator.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnDestroy {
  title = 'roman-calculator';
  numeral1: string = '';
  numeral2: string = '';
  calculationResult: string | undefined;
  errorMessage: string | undefined;
  private subscription: Subscription | undefined;

  constructor(private romanCalculatorService: RomanCalculatorService) { }

  calculate() {
    // Call the service method only if both input fields are non-empty
    if (this.numeral1 && this.numeral2) {
      // Invoke the endpoint
      this.subscription = this.romanCalculatorService.calculateSum(this.numeral1, this.numeral2)
        .subscribe({
          next: result => {
            console.log('Result:', result);
            this.calculationResult = result;
          },
          error: error => {
            console.error('Error:', error);
          }
        });
    } else {
      // Handle case where one or both input fields are empty
      this.errorMessage = 'Please enter values in both input fields.';
    }
  }

  isValidInput(input: string): boolean {
    // Regular expression to match a single valid Roman numeral
    const regex = /^(M{0,3})(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$/;
  
    // Check if the input contains any lowercase letters or integers
    const containsInvalidChars = /[a-z0-9]/.test(input);
  
    // Return true if the input doesn't contain any lowercase letters or integers, and it matches the Roman numeral pattern
    return !containsInvalidChars && regex.test(input) && input.length > 0;
}
    
  ngOnDestroy() {
    // Unsubscribe from the observable when the component is destroyed
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
