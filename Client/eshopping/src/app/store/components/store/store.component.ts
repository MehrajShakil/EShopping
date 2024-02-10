import { Component, OnInit } from '@angular/core';
import { StoreService } from '../../services/store.service';
import { IProduct } from '../../../core/models/Product';
import { PageItemsRequest } from '../../../core/models/PageItemsRequest';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrl: './store.component.scss'
})
export class StoreComponent implements OnInit {

  products: Array<IProduct> = [];
  pageIndex = 1; // first page.
  pageSize = 20;

  constructor(private storeService: StoreService){}

  ngOnInit(): void {
    this.getProducts();
  }

  private getProducts(): any{
    this.storeService.getProducts(this.getPageItemsRequest()).subscribe(response => {
      this.products = response.items;
      console.log(this.products);
    })
  }

  private getPageItemsRequest(): PageItemsRequest{
    const request: PageItemsRequest = {
      pageIndex: this.pageIndex,
      startIndex: (this.pageSize * (this.pageIndex-1)),
      endIndex: (this.pageSize * (this.pageIndex)) - 1,
      pageSize: this.pageSize
    }
    return request;
  }

}
