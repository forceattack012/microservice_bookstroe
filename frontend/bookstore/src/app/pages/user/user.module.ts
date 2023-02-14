import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RightSizeBarComponent } from "src/app/components/right-size-bar/right-size-bar.component";
import { BookListComponent } from "./book-list/book-list.component";
import { UserRoutingModule } from "./user-routing.module";

@NgModule({
    imports:[
        CommonModule,
        UserRoutingModule
    ],
    declarations:[
        BookListComponent
    ]
})

export class UserModule{}