import { Injectable } from '@angular/core';
import { allContacts } from './mocks/contacts';
import { Contact } from './models/contacts';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private readonly contacts: Contact[] = allContacts;

  constructor() { }

  getContacts() : Contact[] {
    return this.contacts;
  }


  addContact(contact : Contact) : void {
    console.log("Hello2");
    this.contacts.push(contact);

  }


}
