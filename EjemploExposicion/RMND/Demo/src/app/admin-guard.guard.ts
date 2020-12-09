import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { DataService } from './Service/data.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuardGuard implements CanActivate {

  constructor(private _auth: DataService, private route: Router) {}

  canActivate(): boolean {
    if(this._auth.validUser())
    {
      return true;
    }
    else
    {
      this.route.navigate(["/login"])
      return false;
    }
  }
  
}
