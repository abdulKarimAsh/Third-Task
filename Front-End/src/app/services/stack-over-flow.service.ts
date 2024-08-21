import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { API } from '../constant/environment';


const headers = new HttpHeaders({
  'Content-Type': 'application/json'
});

@Injectable({
  providedIn: 'root'
})
export class StackOverFlowService {

  constructor(private http: HttpClient) { }
  getRecentQuestions(): Observable<any> {
    return this.http.get<any>(`${API.api}${API.methods.StackOverFlow}/recent-questions`, { headers: headers })
      .pipe(
        map(res => {
          // نتأكد أولاً أن res يحتوي على القائمة التي نتوقعها
          if (res && res.items) {
            // نعدل كل عنصر في قائمة الأسئلة
            res.items = res.items.map((item: any) => ({
              ...item,
              creation_date: new Date(item.creation_date * 1000)
            }));
          }
          return res;
        })
      );
  }

  getQuestionDetails(questionId: number): Observable<any> {
    return this.http.get<any>(`${API.api}${API.methods.StackOverFlow}/question-details/${questionId}`, { headers: headers })
      .pipe(
        map(res => {
          // نتأكد أولاً أن res يحتوي على القائمة التي نتوقعها
          if (res && res.items) {
            // نعدل كل عنصر في قائمة الأسئلة
            res.items = res.items.map((item: any) => ({
              ...item,
              creation_date: new Date(item.creation_date * 1000)
            }));
          }
          return res;
        })
      );
  }
}
