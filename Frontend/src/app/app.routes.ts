import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CreateComponent } from './components/create/create.component.14227';
import { EditComponent } from './components/edit/edit.component.14227';
import { DetailsComponent } from './components/details/details.component.14227';
import { DeleteComponent } from './components/delete/delete.component.14227';


export const routes: Routes = [
    {
        path: "",
        component: HomeComponent
    },
    {
        path: "home",
        component: HomeComponent
    },
    {
        path: "create",
        component: CreateComponent
    },
    {
        path: "edit/:id",
        component: EditComponent
    },
    {
        path: "details/:id",
        component: DetailsComponent
    },
    {
        path: "delete/:id",
        component: DeleteComponent
    }
];
