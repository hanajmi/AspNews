import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class MatterService {

	// Define Propertys
	baseUrl = 'http://localhost:3368/admin/matter/';
	headers = new HttpHeaders().set('Content-Type', 'application/json');

	constructor(private http: HttpClient) {

	}

	// Define Methods

	/**
	 * index
	 */
	index() {
		return this.http.get(this.baseUrl + 'index');
	}

	/**
	 * Show
	 */

	/**
	 * create
	 */
	
	
	/**
	 * edit
	 */
	
	
	/**
	 * delete
	 */
	
	
}
