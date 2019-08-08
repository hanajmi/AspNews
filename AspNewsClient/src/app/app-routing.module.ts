import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


// Component
import { MatterIndexComponent } from './components/admin/matters/matter-index/matter-index.component';
import { MatterShowComponent } from './components/admin/matters/matter-show/matter-show.component';
import { MatterCreateComponent } from './components/admin/matters/matter-create/matter-create.component';
import { MatterEditComponent } from './components/admin/matters/matter-edit/matter-edit.component';
import { MatterDeleteComponent } from './components/admin/matters/matter-delete/matter-delete.component';


const routes: Routes = [
	{ path: '', component: MatterIndexComponent },
	{ path: 'matter', component: MatterIndexComponent },
	{ path: 'matter/index', component: MatterIndexComponent },
	{ path: 'matter/show/:id', component: MatterShowComponent },
	{ path: 'matter/create', component: MatterCreateComponent },
	{ path: 'matter/edit/:id', component: MatterEditComponent},
	{ path: 'matter/delete/:id/', component: MatterDeleteComponent},
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})


export class AppRoutingModule { }
