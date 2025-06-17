import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { FilterComponent } from '../Comps/filter/filter.component';
import { HomeComponent } from '../Comps/home/home.component';
import { LoginComponent } from '../Comps/login/login.component';
import { SignUpComponent } from '../Comps/sign-up/sign-up.component';
import { DetailsComponent } from '../Comps/details/details.component';
import { ShoppingCartComponent } from '../Comps/shopping-cart/shopping-cart.component';
import { PaymentComponent } from '../Comps/payment/payment.component';

export const routes: Routes = [
    {path: '', component:HomeComponent,title:'CrownBeef -  בשר הכתר'},
    {path:'filter/:codeCategory',component:FilterComponent,title:'CrownBeef -  בשר הכתר',
        children: [
            { path: 'details', component: DetailsComponent, title: 'פרטים' },]
    },
    {path:'login',component:LoginComponent,title:'CrownBeef -  בשר הכתר'},
    {path:'signUp',component:SignUpComponent,title:'CrownBeef -  בשר הכתר'},
    {path:'shoppingCart',component:ShoppingCartComponent,title:'CrownBeef -  בשר הכתר'},
    {path:'payment',component:PaymentComponent,title:'CrownBeef -  בשר הכתר'}
];

