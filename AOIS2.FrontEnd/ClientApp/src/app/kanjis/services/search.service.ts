import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Kanji } from '../models/';
import { SearchModel } from '../../radicals';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class SearchService {

    constructor(private http: HttpClient) { }
    readonly  apiUrl : string  = `https://localhost:5001/api/search`;

    searchForKanji (searchModel : SearchModel) : Observable<Kanji[]> {
        return this.http.post<Kanji[]>(`${this.apiUrl}/searchForKanji`, searchModel);
    }
}