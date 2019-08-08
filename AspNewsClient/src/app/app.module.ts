import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

// Routing
import { AppRoutingModule } from './app-routing.module';

// Component
import { AppComponent } from './app.component';
import { MatterIndexComponent } from './components/admin/matters/matter-index/matter-index.component';
import { MatterShowComponent } from './components/admin/matters/matter-show/matter-show.component';
import { MatterCreateComponent } from './components/admin/matters/matter-create/matter-create.component';
import { MatterEditComponent } from './components/admin/matters/matter-edit/matter-edit.component';
import { MatterDeleteComponent } from './components/admin/matters/matter-delete/matter-delete.component';
import { HeaderComponent } from './components/admin/header/header.component';
import { FooterComponent } from './components/admin/footer/footer.component';

// Services
import { HttpClientModule } from '@angular/common/http';
import { MatterService } from './services/admin/matter.service';

@NgModule({
	declarations: [
		AppComponent,

		HeaderComponent,
		FooterComponent,

		// Matter Component		
		MatterIndexComponent,
		MatterShowComponent,
		MatterCreateComponent,
		MatterEditComponent,
		MatterDeleteComponent,
	],
	imports: [
		BrowserModule,

		// Routing: app-routing.module.ts  ---> Directive
		AppRoutingModule,

		// Send And Receive Data
		HttpClientModule,
	],
	providers: [
		// Register Services
		MatterService
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
