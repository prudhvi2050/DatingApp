import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { TabHeadingDirective } from 'ngx-bootstrap';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router, private alertify: AlertifyService) {}
  canActivate(): boolean {
    if (this.authService.loggedin()) {
      return true;
    }

    this.alertify.error('Unauthorized!');
    this.router.navigate(['/home']);
    return false;
  }
}
