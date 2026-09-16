import { Component, inject, signal } from '@angular/core';
import { TaskService } from '../task.service';
import { CreateTask } from '../create-task';
import { CategoryService } from '../../categories/category.service';
import { Category } from '../../categories/category';
import { Router } from '@angular/router';

@Component({
  selector: 'app-task-creator',
  standalone: false,
  styleUrl: './task-creator.css',
  templateUrl: './task-creator.html',
})
export class TaskCreator {
  private taskService = inject(TaskService);
  private categoryService = inject(CategoryService);

  constructor() {
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

  protected router = inject(Router);

  protected categories = signal<Category[]>([]);

  protected isLoading = signal(false);
  protected errorMessage = signal<string | null>(null);

  protected task: CreateTask = {
    title: '',
    description: '',
    categoryId: 0,
  };

  createTask(form: any) {
    this.isLoading.set(true);
    this.errorMessage.set(null);

    const newTask: CreateTask = {
      title: this.task.title,
      description: this.task.description,
      categoryId: this.task.categoryId,
    };

    console.log('Creating task:', newTask);

    this.taskService.createTask(newTask).subscribe({
      next: () => {
        this.isLoading.set(false);
        form.resetForm();
        this.router.navigate(['/']);
      },

      error: (error) => {
        this.isLoading.set(false);
        this.errorMessage.set(
          'Failed to create task' + (error?.message ? `: ${error.message}` : ''),
        );
      },
    });
  }
}
