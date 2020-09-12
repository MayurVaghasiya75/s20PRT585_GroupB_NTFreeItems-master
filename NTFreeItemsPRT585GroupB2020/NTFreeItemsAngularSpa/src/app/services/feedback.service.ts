import { ClientFeedback } from './../Models/feedback-info';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

Injectable({
    providedIn: 'platform'
})

export class CustomerFeedbackService {
     apiUrl = 'https://127.0.0.1:5001';
    constructor(
       private http: HttpClient,
      // private @Inject('BASE_URL') baseUrl: string
    ){}

    getUserComments(){
     return this.http.get<ClientFeedback>(`apiUrl/feedback`);
    }
    postUserFeedbacks() {
      return this.http.put<ClientFeedback>(`apiUrl/feedback`, {responseType: JSON});
    }
}