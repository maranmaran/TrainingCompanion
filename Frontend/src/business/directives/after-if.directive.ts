import { Directive, AfterContentInit, Output, EventEmitter } from "@angular/core";

@Directive({selector: '[after-if]'})
export class AfterIfDirective implements AfterContentInit {
    
    @Output()
    public after: EventEmitter<void> = new EventEmitter<void>();

    public ngAfterContentInit(): void {
       // timeout helps prevent unexpected change errors
       setTimeout(()=> this.after.next());
    }
}