import { Component, inject, signal, computed } from '@angular/core';
import { TaskService } from '../task.service';
import { Task } from '../task';
import { CategoryService } from '../../categories/category.service';
import { Category } from '../../categories/category';

@Component({
  selector: 'app-task-list',
  standalone: false,
  styleUrl: './task-list.css',
  templateUrl: './task-list.html',
})
export class TaskList {
  private categoryService: CategoryService = inject(CategoryService);
  private taskService: TaskService = inject(TaskService);

  protected tasks = signal<Task[]>([]);
  protected searchTerm = signal<string>('');
  protected categories = signal<Category[]>([]);
  protected categoryId = signal<number | null>(null);

  protected currentPage = signal<number>(1);
  private itemsPerPage = 3;

  protected paginatedTasks = computed(() => {
    const startIndex = (this.currentPage() - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.tasks().slice(startIndex, endIndex);
  });

  get totalPages() {
    return Math.ceil(this.tasks().length / this.itemsPerPage);
  }

  get pageNumbers() {
    return [...Array(this.totalPages).keys()];
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage.set(page);
    }
  }

  ngOnInit() {
    this.loadCategories();
    this.loadTasks();
  }

  loadTasks() {
    this.taskService.getTasks().subscribe({
      next: (tasks) => {
        if (this.searchTerm().trim() !== '') {
          const term = this.searchTerm().toLowerCase();
          tasks = tasks.filter((task) => {
            return task.title.toLowerCase().includes(term);
          });
        }
        if (this.categoryId() !== null) {
          tasks = tasks.filter((task) => task.category.id === this.categoryId());
        }
        this.tasks.set(tasks);
      },
      error: (error) => {
        console.error('Failed to load tasks:', error);
      },
    });
  }

  deleteTask(taskId: number) {
    this.taskService.deleteTask(taskId).subscribe({
      next: () => {
        this.loadTasks();
      },
      error: (error) => {
        console.error(`Failed to delete task with ID ${taskId}:`, error);
      },
    });
  }

  completeTask(taskId: number) {
    const task = this.tasks().find((t) => t.id === taskId);
    if (task) {
      const updatedTask = { ...task, isCompleted: !task.isCompleted };
      this.taskService.updateTask(updatedTask).subscribe({
        next: () => {
          this.loadTasks();
        },
        error: (error) => {
          console.error(`Failed to complete task with ID ${taskId}:`, error);
        },
      });
    }
  }

  loadCategories() {
    this.categoryService.getCategories().subscribe({
      next: (categories) => {
        this.categories.set(categories);
      },
      error: (error) => {
        console.error('Failed to load categories:', error);
      },
    });
  }
}
