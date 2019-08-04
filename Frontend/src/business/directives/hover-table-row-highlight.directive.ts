import { Directive, ElementRef, HostListener, Input, Renderer2, OnChanges, SimpleChanges } from '@angular/core';

@Directive({
  selector: '[highlightOnHover]'
})
export class HighlightTableRowOnHoverDirective {

  @Input()
  highlightClass: string = "highlighted-row"

  constructor(
    private element: ElementRef,
    private renderer: Renderer2
  ) {
  }

  @HostListener('mouseenter')
  onMouseEnter() {
    this.setHighlightBackground();
  }
  
  setHighlightBackground() {
    // add highlight class
    this.renderer.addClass(this.element.nativeElement, this.highlightClass);
  }

  @HostListener('mouseleave')
  onMouseLeave() {
    this.removeHighlightBackground();
  }

  removeHighlightBackground() {
    // add highlight class
    this.renderer.removeClass(this.element.nativeElement, this.highlightClass);
  }
}