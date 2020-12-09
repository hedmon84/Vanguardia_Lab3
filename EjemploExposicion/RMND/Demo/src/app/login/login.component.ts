import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms'
import { Router } from '@angular/router';
import { DataService } from '../Service/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private service : DataService, private route: Router) { }

  profileForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  ngOnInit(): void {
  }

  onSubmitLogin(){
    var username = this.profileForm.get("username").value;
    var password = this.profileForm.get("password").value;

    if(username == "holac"){
      if(password == "123"){
        console.log("activate")
        this.service.verification();
        this.route.navigate(["/home"])
      }
    }

  }

}
