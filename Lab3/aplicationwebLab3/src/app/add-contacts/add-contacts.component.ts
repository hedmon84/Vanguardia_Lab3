import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Contact } from '../models/contacts';


@Component({
  selector: 'app-add-contacts',
  templateUrl: './add-contacts.component.html',
  styleUrls: ['./add-contacts.component.css']
})
export class AddContactsComponent implements OnInit {

  form: FormGroup;
  //filterContactList: Array<Contact>;

  constructor() { }
  contacts: Contact[];
  ngOnInit(): void {

    this.form = this.initForm();

  }

  

  initForm() : FormGroup{
    return new FormGroup({

      name: new FormControl("", Validators.required),
      email: new FormControl("", Validators.email),
      phone: new FormControl("", Validators.required),


    });
  }

  get formControls(){
    return this.form.controls;
  }

  

  onSubmit(){ 
    const result : Contact = this.form.value;
    console.log(result.name);
    this.contacts.push(new Contact(result.id, result.phone, result.name, result.email,  result.title));
    this.form.reset();
 
  }

}
