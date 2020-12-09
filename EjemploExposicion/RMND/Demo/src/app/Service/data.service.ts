import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  baseUrl: string = "https://localhost:44356";

  login : boolean = false;

  constructor(private httpClient : HttpClient) { }
  
  verification(){
      this.login = true;
  }

  validUser() : boolean{
      var result;
      if(this.login == true)
        result = true;
      else
        result = false;

      return result
  }
}