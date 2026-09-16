import { Service, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Category } from './category';

@Service()
export class CategoryService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl + '/api/categories';

  getCategories() {
    return this.http.get<Category[]>(`${this.apiUrl}/get-all`, { withCredentials: true });
  }

  getCategoryById(id: number) {
    return this.http.get<Category>(`${this.apiUrl}/get/${id}`, { withCredentials: true });
  }
}
