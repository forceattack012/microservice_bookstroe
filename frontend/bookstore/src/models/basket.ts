import { Book } from "./book";

export class Basket{
    username: string = '';
    books: Array<Book> = [];
    count: Number = 0;
    total: Number = 0;
}