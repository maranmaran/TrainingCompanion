import { Directive, ElementRef, HostListener, Input, Renderer2, OnChanges, SimpleChanges, AfterViewInit } from '@angular/core';

@Directive({
  selector: '[showHidePassword]'
})
export class ShowHidePasswordDirective implements AfterViewInit {

  @Input()
  shownIcon: string = "fa-eye"

  @Input()
  hiddenIcon: string = "fa-eye-slash"

  @Input()
  passwordInput: ElementRef;

  @Input()
  passwordIcon: ElementRef;

  constructor(
    private renderer: Renderer2
  ) {
  }

  ngAfterViewInit() {
    this.hidePassword();
  }

  @HostListener('mousedown')
  onMouseEnter() {
    this.revealPassword();
  }

  @HostListener('mouseup')
  onMouseLeave() {
    this.hidePassword();
  }

  revealPassword() {
    this.renderer.removeClass(this.passwordIcon, this.hiddenIcon);
    this.renderer.addClass(this.passwordIcon, this.shownIcon);
    (this.passwordInput as unknown as HTMLInputElement).type = 'text';
  }

  hidePassword() {
    
    this.renderer.removeClass(this.passwordIcon, this.shownIcon);
    this.renderer.addClass(this.passwordIcon, this.hiddenIcon);
    (this.passwordInput as unknown as HTMLInputElement).type = 'password';
  }
}