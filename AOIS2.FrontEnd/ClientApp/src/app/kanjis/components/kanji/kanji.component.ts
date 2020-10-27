import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Kanji } from '../../';
import { Radical } from 'src/app/radicals';
@Component({
  selector: 'app-kanji',
  templateUrl: './kanji.component.html',
  styleUrls: ['./kanji.component.css']
})
export class KanjiComponent implements OnInit {
  public radicalString : string;

  constructor() { 
  }
    
  @Input() kanji : Kanji;
  ngOnInit() {    

  }
  getRadicals() : string{
    let radicalString = '';
    for (let radical of this.kanji.radicals){
      radicalString = radicalString.concat(radical.character);
    }
    return radicalString;
  }
}
