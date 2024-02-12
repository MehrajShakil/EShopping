import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfig } from '../constants.ts/appConfig';

@Injectable({
  providedIn: 'root',
})
export class ProductCategoriesService {
  hostUrl = '';
  constructor(private httpClient: HttpClient) 
  {
    this.hostUrl = AppConfig.getHostUrl(); 
  }

  public getProductCategories(): any{
    /// need to implement into server side.
    return this.httpClient.get(`${this.hostUrl}api/Catalog/ProductCategories`)
  }

}
