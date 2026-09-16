import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Register } from './users/auth/register/register';
import { TaskList } from './tasks/task-list/task-list';
import { Login } from './users/auth/login/login';
import { TaskCreator } from './tasks/task-creator/task-creator';
import { TaskEditer } from './tasks/task-editer/task-editer';

const routes: Routes = [
  {
    path: 'register',
    component: Register,
  },
  {
    path: 'login',
    component: Login,
  },
  {
    path: '',
    component: TaskList,
  },
  {
    path: 'task/create',
    component: TaskCreator,
  },
  {
    path: 'task/edit/:id',
    component: TaskEditer,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
