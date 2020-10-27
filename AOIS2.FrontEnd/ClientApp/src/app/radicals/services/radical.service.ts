import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Radical } from '../models/';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class RadicalService {

    constructor(private http: HttpClient) { }
    readonly  apiUrl : string  = `https://localhost:5001/api/radicals`;

    getAllRadicals () : Observable<Radical[]> {
        return this.http.get<Radical[]>(`${this.apiUrl}/getAllRadicals`);
    }
}