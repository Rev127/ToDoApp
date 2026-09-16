import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { provideHttpClient } from '@angular/common/http';
import { TaskList } from './tasks/task-list/task-list';
import { Header } from './header/header';
import { Footer } from './footer/footer';
import { Register } from './users/auth/register/register';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Login } from './users/auth/login/login';
import { TaskCreator } from './tasks/task-creator/task-creator';
import { TaskEditer } from './tasks/task-editer/task-editer';

@NgModule({
  declarations: [App, TaskList, Header, Footer, Register, Login, TaskCreator, TaskEditer],
  imports: [BrowserModule, AppRoutingModule, FormsModule, CommonModule],
  providers: [provideBrowserGlobalErrorListeners(), provideHttpClient()],
  bootstrap: [App],
})
export class AppModule {}
