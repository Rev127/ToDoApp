import { Component, inject, signal } from '@angular/core';
import { TaskService } from '../task.service';
import { CategoryService } from '../../categories/category.service';
import { Category } from '../../categories/category';
import { EditTask } from '../edit-task';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-task-editer',
  standalone: false,
  styleUrl: './task-editer.css',
  templateUrl: './task-editer.html',
})
export class TaskEditer {
  private taskService = inject(TaskService);
  private categoryService = inject(CategoryService);

  protected task: EditTask = {
    title: '',
    description: '',
    categoryId: 0,
  };

  protected router = inject(Router);

  protected categories = signal<Category[]>([]);

  private activatedRoute = inject(ActivatedRoute);

  protected isLoading = signal(false);
  protected errorMessage = signal<string | null>(null);

  private taskId: number | null = null;

  ngOnInit() {
    this.taskId = this.activatedRoute.snapshot.params['id'];

    if (this.taskId) {
      this.loadTask(this.taskId);
    }

    this.loadCategories();
  }

  private loadCategories() {
    this.categoryService.getCategories().subscribe({
      next: (categories) => {
        this.categories.set(categories);
      },
      error: (error) => {
        console.error('Error loading categories:', error);
      },
    });
  }

  loadTask(taskId: number) {
    this.taskService.getTaskById(taskId).subscribe({
      next: (taskDetails) => {
        this.task = {
          title: taskDetails.title,
          description: taskDetails.description,
          categoryId: taskDetails.category?.id,
          isCompleted: taskDetails.isCompleted,
        };
      },
      error: (error) => {
        console.error('Error loading task:', error);
      },
    });
  }

  editTask(form: any) {
    this.isLoading.set(true);

    const updatedTask: EditTask = {
      id: this.taskId!,
      title: this.task.title,
      description: this.task.description,
      categoryId: this.task.categoryId,
      isCompleted: this.task.isCompleted,
    };

    this.taskService.updateTask(updatedTask).subscribe({
      next: () => {
        this.isLoading.set(false);
        this.router.navigate(['/']);
      },
      error: (error) => {
        this.isLoading.set(false);
        this.errorMessage.set(
          'Failed to update task' + (error?.message ? `: ${error.message}` : ''),
        );
      },
    });
  }
}
