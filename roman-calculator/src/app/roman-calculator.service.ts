import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RomanCalculatorService {

  constructor(private http: HttpClient) { }

  calculateSum(numeral1: string, numeral2: string): Observable<string> {
    const requestBody = { numeral1, numeral2 };
    return this.http.post<string>('https://localhost:7131/RomanCalculator/sum', requestBody);
  }
}