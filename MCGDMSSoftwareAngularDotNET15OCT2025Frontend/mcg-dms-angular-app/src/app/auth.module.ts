// File: src/app/modules/auth.module.ts
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

// Keep this module if you want to group auth-related declarations later.
// Right now we don't redeclare LoginComponent here to avoid double-declaration.
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class AuthModule {}