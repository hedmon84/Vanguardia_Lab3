import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ContactService } from '../contact.service';
import { Contact } from '../models/contacts';


@Component({
  selector: 'app-add-contacts',
  templateUrl: './add-contacts.component.html',
  styleUrls: ['./add-contacts.component.css']

})
export class AddContactsComponent implements OnInit {

  form: FormGroup;

  //filterContactList: Array<Contact>;

  constructor(private contactService: ContactService, private router: Router) { }


  ngOnInit(): void {

    this.form = this.initForm();

  }



  initForm(): FormGroup {
    return new FormGroup({

      title: new FormControl("", Validators.required),
      name: new FormControl("", Validators.required),
      email: new FormControl("", Validators.email),
      phone: new FormControl("", Validators.required),


    });
  }

  get formControls() {
    return this.form.controls;
  }



  onSubmit() {
    console.log("Hello");
    const result: Contact = this.form.value;
    console.log(result.name);
    console.log("Hello");
    //this.contactService.addContact(new Contact(this.contactService.getContacts().length + 1, result.title, result.name, result.email, result.phone));
    //this.contactService.addContact({ id: this.contactService.getContacts().length + 1, title: result.title, name: result.name, email: result.email, phone: result.phone });
    this.contactService.addContact({ ...result, id: this.contactService.getContacts().length + 1 });
    this.form.reset();
    this.router.navigate(['/home']);


  }

}
