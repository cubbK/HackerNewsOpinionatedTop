import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { PostComponent } from './post.component';
import { AdminListComponent } from './pages/admin-list/admin-list.component';
import { AdminAddComponent } from './pages/admin-add/admin-add.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: 'admin/add', component: AdminAddComponent },
  { path: 'admin', component: AdminListComponent },
];

@NgModule({
  declarations: [
    AdminAddComponent,
    AdminListComponent,
    AppComponent,
    PostComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
