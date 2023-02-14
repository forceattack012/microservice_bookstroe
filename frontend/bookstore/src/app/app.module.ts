import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { RightSizeBarComponent } from './components/right-size-bar/right-size-bar.component';
import { BasketListComponent } from './pages/user/basket-list/basket-list.component';
import { DashboardComponent } from './pages/admin/dashboard/dashboard.component';
import { HistoryComponent } from './pages/admin/history/history.component';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './components/basket/basket.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    BasketListComponent,
    DashboardComponent,
    HistoryComponent,
    BasketListComponent,
    RightSizeBarComponent,
    BasketComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
