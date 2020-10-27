import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Kanji } from '../../';
@Component({
  selector: 'app-kanji',
  templateUrl: './kanji.component.html',
  styleUrls: ['./kanji.component.css']
})
export class KanjiComponent implements OnInit {

  constructor() { }
  @Input() kanji : Kanji;
  ngOnInit() {
  }

}
