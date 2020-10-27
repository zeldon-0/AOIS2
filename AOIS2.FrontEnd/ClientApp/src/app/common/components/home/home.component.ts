import { Component, OnInit } from '@angular/core';
import { RadicalService, Radical, SearchModel } from '../../../radicals';
import { SearchService, Kanji} from '../../../kanjis';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private query : SearchModel;
  constructor(
    private radicalService : RadicalService,
    private searchService : SearchService) {
      this.query = new SearchModel();
     }
  public radicals : Radical[];
  
  public kanji : Kanji;
  ngOnInit() {
    this.radicalService.getAllRadicals()
      .subscribe(radicals => {this.radicals = radicals});
  }
  onRadicalClicked(radical : Radical){

    if (this.query.radicals.some(r => r.id === radical.id)){

      this.query.radicals = this.query.radicals.filter( r => r.id != radical.id);
    }
    else{
      this.query.radicals.push(radical);
    }

  }
  search(){
    this.kanji=null;
    this.searchService.searchForKanji(this.query)
      .subscribe(kanjis => this.kanji = kanjis[0]);
  }
}
