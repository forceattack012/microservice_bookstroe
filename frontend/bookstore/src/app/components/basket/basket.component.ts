import { Component, OnInit } from '@angular/core';
import { Basket } from 'src/models/basket';
import { BasketService } from 'src/services/basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  baskets: Basket[] = []

  constructor(private basketService: BasketService) { 
  }

  ngOnInit(): void {
    setTimeout(async() => {
      await this.getBasketList()
      console.log(this.baskets)
    }, 5000);
  }

  async getBasketList()  {
    const userName = localStorage.getItem('username')
    this.basketService.getBasketByUsername(userName).subscribe(result => {
      this.baskets = result.data
    })
  }

}
