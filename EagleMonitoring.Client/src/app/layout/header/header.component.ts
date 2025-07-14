import { Component } from '@angular/core';
import { AuthService } from '../../shared/service/auth/auth.service';
import { RouterModule } from '@angular/router'; 
import { CommonModule } from '@angular/common';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule, NgbDropdownModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  isMobileMenuOpen = false;
  currentRole: string = 'keeper'; // Default role
  userName: string = 'John Doe'; // Replace with actual user name

  // Define access control for menu items
  menuAccess: { [key: string]: string[] } = {
    dashboard: ['admin', 'keeper'],
    animals: ['admin', 'keeper'],
    logs: ['admin', 'keeper'],
    reports: ['admin'],
    users: ['admin']
  };

  constructor(private authService: AuthService) {
    // Subscribe to role changes
    this.authService.currentRole$.subscribe(role => {
      this.currentRole = role;
    });
  }

  // Check if user has access to a menu item
  hasAccess(menuKey: string): boolean {
    return this.menuAccess[menuKey].includes(this.currentRole);
  }

  logout() {
    this.authService.logout();
  }
}