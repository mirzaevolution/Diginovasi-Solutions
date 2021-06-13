import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Diginovasi Solutions';
  menuCollapse: boolean = true;
  toggleMenuCollapse(): void{
    this.menuCollapse = !this.menuCollapse;
  }
  closeCollapse(): void{
      this.menuCollapse = true;
  }
  onCollapseChanged():void{
    console.log(this.menuCollapse);
  }
}
