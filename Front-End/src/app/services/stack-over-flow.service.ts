import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../constant/environment';

@Injectable({
  providedIn: 'root'
})
export class StackOverFlowService {

  constructor(private http: HttpClient) { }
  getRecentQuestions(): Observable<any> {
    return this.http.get<any>(`${API.stackapi}/questions?order=desc&sort=activity&site=stackoverflow`);
  }

  getQuestionDetails(questionId: number): Observable<any> {
    return this.http.get<any>(`${API.stackapi}/questions/${questionId}?order=desc&sort=activity&site=stackoverflow&filter=withbody`);
  }
}
