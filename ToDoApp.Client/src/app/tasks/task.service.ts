import { Service, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Task } from './task';
import { CreateTask } from './create-task';
import { EditTask } from './edit-task';

@Service()
export class TaskService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl + '/api/tasks';

  getTasks() {
    return this.http.get<Task[]>(`${this.apiUrl}/get-all`, { withCredentials: true });
  }

  getTaskById(taskId: number) {
    return this.http.get<Task>(`${this.apiUrl}/get/${taskId}`, { withCredentials: true });
  }

  createTask(task: CreateTask) {
    return this.http.post<Task>(
      `${this.apiUrl}/create`,
      { title: task.title, description: task.description, categoryId: task.categoryId },
      { withCredentials: true },
    );
  }

  updateTask(task: EditTask) {
    return this.http.patch<Task>(
      `${this.apiUrl}/update/${task.id}`,
      {
        id: task.id,
        title: task.title,
        description: task.description,
        categoryId: task.categoryId,
        isCompleted: task.isCompleted,
      },
      { withCredentials: true },
    );
  }

  deleteTask(taskId: number) {
    return this.http.delete(`${this.apiUrl}/delete/${taskId}`, { withCredentials: true });
  }
}
