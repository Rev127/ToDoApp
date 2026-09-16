import { Component, inject } from '@angular/core';
import { UserService } from '../users/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: false,
  styleUrl: './header.css',
  templateUrl: './header.html',
})
export class Header {
  private userService = inject(UserService);
  protected user$ = this.userService.currentUser$;
  protected router = inject(Router);

  ngOnInit() {
    this.userService.getCurrentUser().subscribe({
      next: (user) => {
        this.userService.setCurrentUser(user);
        console.log('Current user fetched successfully:', this.user$);
      },
      error: (error) => {
        console.error('Error fetching current user:', error);
      },
    });
  }

  logout() {
    this.userService.logoutUser().subscribe({
      next: () => {
        this.userService.setCurrentUser({ name: '', isAuthenticated: false });
        console.log('User logged out successfully');
        this.router.navigate(['/login']);
      },
      error: (error) => {
        console.error('Error logging out:', error);
      },
    });
  }
}
