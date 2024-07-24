import { AbstractControl } from '@angular/forms';

export class CustomValidators {
  static VerifyDate(control: AbstractControl) {
    const selectedDate = new Date(control.get('birth')?.value);
    const maxDate = new Date('2006-01-01');
    const minDate = new Date('1935-01-01');
    if (selectedDate < minDate || selectedDate > maxDate) {
      return { invalidDate: true };
    }
    return null;
  }
}
