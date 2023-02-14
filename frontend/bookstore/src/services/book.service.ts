import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseResponse } from 'src/models/baseResponse';
import { Book } from 'src/models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getBookList(page: Number = 1,size: Number = 20): Observable<BaseResponse<Book[]>> {
    return this.http.get<BaseResponse<Book[]>>(`/api/book?page=${page}&pageSize=${size}`)
  }
}
