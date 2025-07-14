import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export type UserRole = 'admin' | 'keeper';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private currentRole = new BehaviorSubject<UserRole>('keeper'); // Default role
  
  currentRole$ = this.currentRole.asObservable();

  setRole(role: UserRole) {
    this.currentRole.next(role);
  }

  logout() {
    // Implement your logout logic
  }
}