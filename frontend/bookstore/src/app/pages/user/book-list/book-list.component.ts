import { Component, OnInit } from '@angular/core';
import { Basket } from 'src/models/basket';
import { Book } from 'src/models/book';
import { BasketService } from 'src/services/basket.service';
import { BookService } from 'src/services/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Array<Book>
  userName: string = "test";
  basket: Basket;

  constructor(private bookService: BookService, 
    private basketService: BasketService) { 
  }

  ngOnInit(): void {
    this.bookService.getBookList(0, 20).subscribe(books => {
      this.books = books.data
      console.log(this.books)
    })

    if(this.userName !== '' || this.userName !== null){
      this.basketService.getBasketByUsername(this.userName).subscribe(response => {
        console.log(response)
        let basket = response.data
        this.basket = basket;
      })
    }
  }

  addBasket(book: Book): void {
    let basket: Basket = new Basket
    this.userName = localStorage.getItem('username')
    console.log('step 2 ' + this.userName)
    if(this.userName === null || this.userName === ''){
      this.userName = 'test'
      console.log('step 1 ' + this.userName)
      localStorage.setItem('username', this.userName);
    }

    basket.username = this.userName;
    basket.books.push(book);

    this.basketService.createBasket(basket).subscribe(basket => {
      console.log(basket)
    })
  }

}
