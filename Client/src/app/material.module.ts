import { NgModule } from '@angular/core';
import {MatCardModule, MatButtonModule, MatToolbarModule} from '@angular/material';

@NgModule({
  imports: [MatCardModule, MatButtonModule, MatToolbarModule],
  exports: [MatCardModule, MatButtonModule, MatToolbarModule],
})
export class MaterialModule { }
