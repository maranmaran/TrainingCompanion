import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.scss']
})
export class ConfirmDialogComponent implements OnInit, OnDestroy {
 
  private goToRoute: string;

  constructor(
    private router: Router,
    protected dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { message: string, allowConfirm: boolean, allowCancel: boolean, confirmLabel: string, title: string}) { }

  ngOnInit() {
  }

  navigateToRoute(event) {
    this.goToRoute = event.target.getAttribute('data-link');
    console.log(this.goToRoute);
    if(this.goToRoute)
      this.dialogRef.close();
  }

  ngOnDestroy(): void {
    this.goToRoute && this.router.navigate([this.goToRoute]);
  }
}
