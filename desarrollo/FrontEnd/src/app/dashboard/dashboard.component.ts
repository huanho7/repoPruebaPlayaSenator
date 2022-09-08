import {Component} from '@angular/core';
import {HotelDto} from '../entities/HotelDto';
import {DataSource} from '@angular/cdk/table';
import {Observable} from 'rxjs';
import { HotelService } from '../services/hotelservice';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  constructor(/*private dataService: HotelService*/) {
  }

  displayedColumns = ['name', 'category', 'status', 'action'];
  dataSource = [
    {Id: 1, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 2, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 3, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 4, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1},
    {Id: 5, Name: 'Post One', Category: 1, Description: 'Description', Image: 'Body 1', Comment: '', Status: 1}
  ];
  //dataSource = new PostDataSource(this.dataService);
}

// export class PostDataSource extends DataSource<any> {
//   constructor(private dataService: HotelService) {
//     super();
//   }

//   connect(): Observable<HotelDto[]> {
//     return this.dataService.getData();
//   }

//   disconnect() {
//   }
// }