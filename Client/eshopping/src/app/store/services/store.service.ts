import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PageItemsRequest } from '../../core/models/PageItemsRequest';
import { Observable } from 'rxjs';
import { PaginatedResponse } from '../../core/models/PaginatedResponse';
import { IProduct } from '../../core/models/Product';
import { AppConfig } from '../../core/constants.ts/appConfig';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  
  hostUrl: string = '';
  constructor(private httpClient: HttpClient) { 
    this.hostUrl = AppConfig.getHostUrl();
    if(!this.hostUrl.endsWith('/')){
      this.hostUrl+='/';
    }
  }

  public getProducts(pageItemsRequest: PageItemsRequest): Observable<PaginatedResponse<IProduct>>{
    return this.httpClient.post<PaginatedResponse<IProduct>>(`${this.hostUrl}api/1.0/Catalog/GetAllProducts`, pageItemsRequest);
  }

  public createProduct(product: IProduct): any{
    return this.httpClient.post(`${this.hostUrl}api/1.0/Catalog/CreateProduct`, product);
  }

}
