import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public requestForm: FormGroup;

    constructor(fb: FormBuilder) {
      this.requestForm = fb.group(
        {
          name: [null],
          email: [null, [Validators.required, Validators.email]],
          size: null
        }
      );
    }
    get email() {
      return this.requestForm.get('email') as FormControl;
    }

    getErrorMessage() {
      return this.email.hasError('required') ? 'You must enter a value' : this.email.hasError('email') ? 'Not a valid email' : '';
    }

    submit() {
      console.log(this.requestForm.value);
    }

    reset() {
      this.requestForm.reset();
    }
}
