import { allContacts } from './../mocks/contacts';
import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contacts';
import { ContactService } from '../contact.service';


@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css'],

})
export class RootComponent implements OnInit {

  constructor(private contactService: ContactService) { }
  

  show: boolean = true;
  contacts: Contact[];
  filterContactList: Array<Contact>;
  detailContact: Contact;

  ngOnInit(): void {
    this.contacts = this.contactService.getContacts();
    this.filterContactList = this.contactService.getContacts();
    //this.contacts.push(new Contact(1,"Mr","Lewis Hamilton","lewisOne@gmail.com","+1 323-342-4324"));
  }

  //FILTER DATA FROM SEARCH INPUT (BY NAME, EMAIL & PHONE)

  filter(data: string) {
    if (data) {
      this.filterContactList = this.contacts.filter((contact: Contact) => contact.name.toLowerCase().indexOf(data.toLowerCase()) > -1
        || contact.email.toLowerCase().lastIndexOf(data.toLocaleLowerCase()) > -1
        || contact.phone.toLowerCase().lastIndexOf(data.toLocaleLowerCase()) > -1)
    }
    else {
      this.filterContactList = this.contacts;
    }
  }

  //FILTER BY CATEGORY OR ID NUMBER

  filterContact(dataId: number) {
    if (dataId == 0) {
      this.filterContactList = this.contactService.getContacts();
    } else {
      this.filterContactList = this.contacts.filter((contact: Contact) => contact.id == dataId)
    }
  }

  onClickDetail(contact_detail : Contact) : void{
    this.show = true;
    this.detailContact = contact_detail;
  }

  Delete(contact_id) {
    this.filterContactList = this.filterContactList.filter((con) => con.id !== contact_id);
    this.contacts = this.filterContactList;
    this.show = false;

  }

}
