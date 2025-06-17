import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../Classes/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(public catServer:HttpClient) { }
  allCategory: Array<Category> = new Array<Category>()
  basicUrl:string="https://localhost:7076/api/Category/"
  getC():Observable<Array<Category>>
  {
    return this.catServer.get<Array<Category>>(`${this.basicUrl}`)
  }
}

