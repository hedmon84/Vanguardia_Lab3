import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms' 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RootComponent } from './root/root.component';
import { FilterContactsComponent } from './filter-contacts/filter-contacts.component';
import { AddContactsComponent } from './add-contacts/add-contacts.component';
import { ContactService } from './contact.service';

@NgModule({
  declarations: [
    AppComponent,
    RootComponent,
    FilterContactsComponent,
    AddContactsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ContactService],
  bootstrap: [AppComponent]
})
export class AppModule { }
