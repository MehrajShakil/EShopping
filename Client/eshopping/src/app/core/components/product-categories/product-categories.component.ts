import { Component, OnInit } from '@angular/core';
import { ProductCategoriesService } from '../../services/product-categories.service';

@Component({
  selector: 'app-product-categories',
  templateUrl: './product-categories.component.html',
  styleUrl: './product-categories.component.scss'
})
export class ProductCategoriesComponent implements OnInit {

  constructor(private productCategoriesService: ProductCategoriesService){}
  categories: any = [];

  ngOnInit(): void {
    this.productCategoriesService.getProductCategories().subscribe((response: { categories: any; })=> {
      this.categories = response.categories;
    })
  }
}
