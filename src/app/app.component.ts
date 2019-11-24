import { Component, OnInit } from '@angular/core';
import * as SignalR from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements  OnInit {

  ngOnInit(): void {
    const connection = new SignalR.HubConnectionBuilder()
      .configureLogging(SignalR.LogLevel.Information)
      .withUrl("http://localhost:5627/notify")
      .build();

    connection.start().then(() => {
      console.log('Connected!');
    }).catch((err) => {
      return console.error(err.toString());
    });
  }
}
