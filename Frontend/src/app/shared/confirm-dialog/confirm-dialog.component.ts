import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.scss']
})
export class ConfirmDialogComponent implements OnInit, OnDestroy {

  private goToRoute: string;

  constructor(
    private router: Router,
    private dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { config: ConfirmDialogConfig }) { }

  ngOnInit() {
  }

  navigateToRoute(event) {
    this.goToRoute = event.target.getAttribute('data-link');
    if (this.goToRoute)
      this.dialogRef.close();
  }

  onClose() {
    this.dialogRef.close(ConfirmResult.Reject);
  }

  onConfirm() {
    this.dialogRef.close(ConfirmResult.Confirm);
  }

  ngOnDestroy(): void {
    this.goToRoute && this.router.navigate([this.goToRoute]);
  }
}
