import { Directive, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';

@Directive({
  selector: '[button-size]'
})
export class ButtonSizeDirective implements OnInit {

  @Input()
  size: string;

  constructor(
    private element: ElementRef,
    private renderer: Renderer2
  ) {
  }

  ngOnInit() {
    if(this.size) {
      this.renderer.setStyle(this.element.nativeElement, 'height', this.size);
      this.renderer.setStyle(this.element.nativeElement, 'width', this.size);
      this.renderer.setStyle(this.element.nativeElement, 'line-height', this.size);
    }
  }
}
