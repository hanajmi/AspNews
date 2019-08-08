import { Component, OnInit } from '@angular/core';
import { MatterService } from '../../../../services/admin/matter.service';

@Component({
	selector: 'app-matter-index',
	templateUrl: './matter-index.component.html',
	styleUrls: ['./matter-index.component.css']
})
export class MatterIndexComponent implements OnInit {

	title = 'ورود اطلاعات';
	matters:any = [];

	constructor(private service: MatterService) {
		// Load External Script
		this.loadExternalScript('../../../../../assets/js/custom.js').then(() => { }).catch(() => { });
		this.getAll();
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


	getAll() {
		this.service.index().subscribe( (data) => {
			console.log(data);
			this.matters = data;
		});
	}
}



