import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Radical } from '../../models';


@Component({
  selector: 'app-radical',
  templateUrl: './radical.component.html',
  styleUrls: ['./radical.component.css']
})
export class RadicalComponent implements OnInit {

  constructor() { }
  @Input() radical : Radical;
  ngOnInit() {
  }
  @Output() radicalClicked = new EventEmitter<Radical>();
  public toggle = false;
  emit(radical : Radical){
    this.toggle = !this.toggle;
    this.radicalClicked.emit(radical);
  }
}
