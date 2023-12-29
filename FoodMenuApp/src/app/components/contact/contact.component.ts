import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import emailjs from '@emailjs/browser';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css'
})
export class ContactComponent {

  constructor(private fb: FormBuilder) {}

  form: FormGroup = this.fb.group({
    from_name: '',
    from_email: '',
    message: '',
    to_name: 'Ajay'
  });


  async sendEmail(){
    emailjs.init("42M0g3OYjlnptgXMS");
    let response = await emailjs.send("service_lebrkb6","template_5idl7l2",{
      from_name: this.form.value.from_name,
      from_email: this.form.value.from_email,
      message: this.form.value.message,
      reply_to: "ad",
      });

      alert("A message has been sent");
      this.form.reset();
  }
}
