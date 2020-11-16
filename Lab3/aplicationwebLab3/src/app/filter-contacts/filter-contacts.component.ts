import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-filter-contacts',
  templateUrl: './filter-contacts.component.html',
  styleUrls: ['./filter-contacts.component.css']
})
export class FilterContactsComponent implements OnInit {

  constructor() { }

  private _filter : string

  set filter(value:string){
    this._filter = value;
    console.log(value)
    this.change.emit(value);
  }

  ngOnInit(): void {
  }

  @Output() change = new EventEmitter<string>();

}
