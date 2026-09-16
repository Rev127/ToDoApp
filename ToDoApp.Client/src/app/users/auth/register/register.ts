import { Component, signal } from '@angular/core';
import { UserService } from '../../user.service';
import { AuthUser } from '../../auth-user';

@Component({
  selector: 'app-register',
  standalone: false,
  styleUrl: './register.css',
  templateUrl: './register.html',
})
export class Register {
  constructor(private userService: UserService) {}

  protected errorMessage = signal<string | null>(null);
  protected isLoading = signal(false);

  protected authUser = signal<Partial<AuthUser>>({
    email: '',
    password: '',
    confirmPassword: '',
  });

  registerUser(form: any) {
    this.isLoading.set(true);
    this.errorMessage.set(null);
    if (this.authUser().password !== this.authUser().confirmPassword) {
      this.errorMessage.set('Passwords do not match');
      return;
    }
    const user: AuthUser = {
      email: this.authUser().email || '',
      password: this.authUser().password || '',
    };
    this.userService.registerUser(user).subscribe({
      next: () => {
        this.isLoading.set(false);
        this.authUser.set({ email: '', password: '', confirmPassword: '' });
        form.resetForm();
      },
      error: (error) => {
        this.isLoading.set(false);
        this.errorMessage.set('Error registering user: ' + error.message);
      },
    });
  }
}
