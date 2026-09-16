import { Service, inject } from '@angular/core';
import { User } from './user';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { AuthUser } from './auth-user';
import { Observable, BehaviorSubject } from 'rxjs';
import { CurentUser } from './curent-user';

@Service()
export class UserService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl;
  private currentUser = new BehaviorSubject<CurentUser>({
    name: '',
    isAuthenticated: false,
  });

  currentUser$ = this.currentUser.asObservable();

  setCurrentUser(user: CurentUser) {
    this.currentUser.next(user);
  }

  registerUser(user: AuthUser) {
    return this.http.post<User>(
      `${this.apiUrl}/register`,
      { email: user.email, password: user.password },
      { withCredentials: true },
    );
  }

  loginUser(user: AuthUser) {
    return this.http.post<User>(
      `${this.apiUrl}/login?useCookies=true`,
      { email: user.email, password: user.password },
      {
        withCredentials: true,
      },
    );
  }

  logoutUser() {
    return this.http.post(`${this.apiUrl}/api/users/logout`, {}, { withCredentials: true });
  }

  getCurrentUser() {
    return this.http.get<CurentUser>(`${this.apiUrl}/api/users/me`, {
      withCredentials: true,
    });
  }
}
