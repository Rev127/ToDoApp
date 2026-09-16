import { Component, signal, inject } from '@angular/core';
import { AuthUser } from '../../auth-user';
import { UserService } from '../../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {
  protected userService = inject(UserService);
  protected router = inject(Router);

  protected errorMessage = signal<string | null>(null);
  protected isLoading = signal(false);

  protected authUser = signal<Partial<AuthUser>>({
    email: '',
    password: '',
  });

  loginUser(form: any) {
    this.isLoading.set(true);
    this.errorMessage.set(null);

    const user: AuthUser = {
      email: this.authUser().email || '',
      password: this.authUser().password || '',
    };

    this.userService.loginUser(user).subscribe({
      next: () => {
        this.isLoading.set(false);
        this.userService.getCurrentUser().subscribe({
          next: (curentUser) => {
            this.userService.setCurrentUser(curentUser);
            console.log('Current user set:', curentUser);
            this.router.navigate(['/']);
          },
          error: (error) => {
            console.error('Error fetching current user:', error);
          },
        });
      },
      error: (error) => {
        this.isLoading.set(false);
        this.errorMessage.set('Login failed. Please check your email and password and try again.');
      },
    });
  }
}
