import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutes } from './app.routing';
import { RouterModule, Routes } from '@angular/router';
import { MenuModule } from './pages/menu/menu.module';
import { RolModule } from './pages/rol/rol.module';
import { SetModule } from './pages/set/set.module';
import { LayoutModule } from './pages/layout/layout.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/menu',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    LayoutModule,
    MenuModule,
    RolModule,
    SetModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
