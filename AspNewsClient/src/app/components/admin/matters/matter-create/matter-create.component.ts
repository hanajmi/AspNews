import { Component, OnInit } from '@angular/core';

@Component({
	selector: 'app-matter-create',
	templateUrl: './matter-create.component.html',
	styleUrls: ['./matter-create.component.css']
})
export class MatterCreateComponent implements OnInit {

	constructor() {
		// Load External Script
		this.loadExternalScript('../../../../../assets/js/validator.js').then(() => { }).catch(() => { });
		this.loadExternalScript('../../../../../assets/js/custom.js').then(() => { }).catch(() => { });
	}

	ngOnInit() {
	}

	private loadExternalStyles(styleUrl: string) {
		return new Promise((resolve, reject) => {
			const styleElement = document.createElement('link');
			styleElement.href = styleUrl;
			styleElement.onload = resolve;
			document.head.appendChild(styleElement);
		});
	}


	private loadExternalScript(scriptUrl: string) {
		return new Promise(resolve => {
			const scriptElement = document.createElement('script');
			scriptElement.src = scriptUrl;
			scriptElement.onload = resolve;
			document.body.appendChild(scriptElement);
		});
	}
}
