import {Injectable} from '@angular/core';
import {HotelDto} from '../entities/HotelDto';
import {Observable, of} from 'rxjs';

@Injectable()
export class HotelService {

  ELEMENT_DATA: HotelDto[] = [
    {Id: 1, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 2, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 3, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 4, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 5, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1}
  ];
  categories = [
    {value: 'Web-Development', viewValue: 'Web Development'},
    {value: 'Android-Development', viewValue: 'Android Development'},
    {value: 'IOS-Development', viewValue: 'IOS Development'}
  ];

  constructor() {
  }

  getData(): Observable<HotelDto[]> {
    return of<HotelDto[]>(this.ELEMENT_DATA);
  }

  getCategories() {
    return this.categories;
  }

  addPost(data:HotelDto) {
    this.ELEMENT_DATA.push(data);
  }

  deletePost(index:number) {
    this.ELEMENT_DATA = [...this.ELEMENT_DATA.slice(0, index), ...this.ELEMENT_DATA.slice(index + 1)];
  }

  dataLength() {
    return this.ELEMENT_DATA.length;
  }
}