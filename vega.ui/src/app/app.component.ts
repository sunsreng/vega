import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  visible = true;
  navList = [
    { name: 'Home', icon: 'home', urls: '/' },
    { name: 'Claim', icon: 'home', urls: '/' },
    { name: 'Product', icon: 'date_range', urls: '/' },
    { name: 'Admin', icon: 'account_circle', urls: '/' }
  ];
  step = 0;
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
  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  showInfo(link) {
    console.log('log');
  }

}
