import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'euDate'
})

export class DateFormatPipe implements PipeTransform {
    transform(value: any): string {
      const dateObject = new Date(value);
      return dateObject.toLocaleDateString('en-GB');
    }
}