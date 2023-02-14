import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookListComponent } from './book-list/book-list.component';


const routes: Routes = [
  {
    path: 'books',
    component: BookListComponent
  },
  {
    path: '',
    redirectTo: '',
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }