import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TaskEditer } from './task-editer';

describe('TaskEditer', () => {
  let component: TaskEditer;
  let fixture: ComponentFixture<TaskEditer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TaskEditer],
    }).compileComponents();

    fixture = TestBed.createComponent(TaskEditer);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
